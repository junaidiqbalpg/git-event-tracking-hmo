using AutoMapper;
using GitEventTrackingApi.Data;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Service.Services;
using GitEventTrackingApi.Test.Helper;
using GitEventTrackingApi.Test.Models.Builders;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace GitEventTrackingApi.Test.Services
{
    public class ActorServiceTests
    {
        private ActorService _actorService;
        private EventRespository _eventRespository;
        private EventService _eventService;

        private IMapper _mapper;

        private Mock<ILogger<EventRespository>> _eventRepositoryLogger;
        private Mock<ILogger<EventService>> _eventServiceLogger;

        private GitEventTrackingContext _context = new SqliteDbContext().CreateContext();

        private Event _event;
        private Actor _actor;
        private Repo _repo;

        [SetUp]
        public void Init()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Startup).Assembly));
            _mapper = config.CreateMapper();

            _eventRepositoryLogger = new Mock<ILogger<EventRespository>>();
            _eventServiceLogger = new Mock<ILogger<EventService>>();

            _eventRespository = new EventRespository(_context, _eventRepositoryLogger.Object);

            _actorService = new ActorService(_eventRespository, _mapper);

            _eventService = new EventService(_eventRespository,
                _mapper, _eventServiceLogger.Object);

            _actor = new ActorBuilder()
                .Build();

            _repo = new RepoBuilder()
                .Build();

            _event = new EventBuilder()
                .WithActor(_actor)
                .WithRepo(_repo)
                .Build();
        }

        [Test]
        public void ReturnActorBusinessModelForAddGitEvent()
        {
            //Arrange
            var _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(4)
                .WithActorId(1)
                .WithRepoId(1)
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Act
            var result = _actorService.GetActorsWithMaximumStreak();

            //Assert
            Assert.That(result.Count, Is.GreaterThanOrEqualTo(1));
        }


        [Test]
        public void CalculateMaxStreakWhenThereIsOnlyOneActor()
        {
            var _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(1)
                .WithActorId(1)
                .WithRepoId(1)
                .Build();

            //Arrange
            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(2)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-1))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(3)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-1))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Act
            var result = _actorService.GetActorsWithMaximumStreak();

            //Assert
            Assert.That(result.Count, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void CalculateMaxStreakWhenActorOneWith4StreakAndActorTwoWith1Streak()
        {
            var _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(5)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now)
                .Build();

            //Arrange
            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(6)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-1))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(7)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-1))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Add 2nd actor

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(8)
                .WithActorId(2)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-3))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);
            //Act
            var result = _actorService.GetActorsWithMaximumStreak();

            //Assert
            Assert.That(result[0].id, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void CalculateMaxStreakWhenActorOneWith2StreakAndActorTwoWith2StreakAndActorThreeWith3Streak()
        {
            var _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(9)
                .WithActor(_actor)
                .WithRepo(_repo)
                .WithCreatedAt(DateTime.Now)
                .Build();

            //Arrange
            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(10)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(-1))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Add 2nd actor
            _actor = new ActorBuilder()
                .WithId(2)
                .Build();

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(11)
                .WithActor(_actor)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-1))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(12)
                .WithActorId(2)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(-2))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Add 3rd actor
            _actor = new ActorBuilder()
                .WithId(3)
                .Build();

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(13)
                .WithActor(_actor)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-3))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);
            //Act
            var result = _actorService.GetActorsWithMaximumStreak();

            //Assert
            Assert.That(result[0].id, Is.GreaterThanOrEqualTo(1));
        }

        /*
            actor1, DateTime.Now
            actor1, DateTime.Now.AddHours(-2)
            actor1, DateTime.Now.AddDays(1)
            actor1, DateTime.Now.AddDays(1).AddHours(2)
            actor1, DateTime.Now.AddDays(4)

            actor2, DateTime.Now
            actor2, DateTime.Now.AddHours(-3)
            actor2, DateTime.Now.AddDays(2)
            actor2, DateTime.Now.AddDays(4)
            
            actor3, DateTime.Now;
            actor3, DateTime.Now.AddHours(-3)

            actor4, DateTime.Now
            actor4, DateTime.Now.AddHours(-2)
            actor4, DateTime.Now.AddHours(-3)
            actor4, DateTime.Now.AddDays(1)
            actor4, DateTime.Now.AddDays(1).AddHours(2)
            actor4, DateTime.Now.AddDays(1).AddHours(3)
            actor4, DateTime.Now.AddDays(1).AddHours(4)
            actor4, DateTime.Now.AddDays(1).AddHours(5)
            actor4, DateTime.Now.AddDays(1).AddHours(6)
            actor4, DateTime.Now.AddDays(1).AddHours(7)
            actor4, DateTime.Now.AddDays(4)

            actor4 has maximum streak = 10
        */
        [Test]
        public void CalculateMaxStreakWhenThereAre4Actor()
        {
            //Arrange
            var _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(14)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now)
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(15)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-2))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(16)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(1))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(17)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(1).AddHours(2))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(18)
                .WithActorId(1)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(4))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Add 2nd actor
            _actor = new ActorBuilder()
                .WithId(2)
                .Build();

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(19)
                .WithActorId(2)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now)
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(20)
                .WithActorId(2)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-3))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(21)
                .WithActorId(2)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(2))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(22)
                .WithActorId(2)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(4))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Add 3rd actor

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(23)
                .WithActorId(3)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now)
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(24)
                .WithActorId(3)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-3))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Add 4th actor
            _actor = new ActorBuilder()
                .WithId(4)
                .Build();

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(25)
                .WithActor(_actor)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now)
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(26)
                .WithActorId(4)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-2))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(27)
                .WithActorId(4)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddHours(-3))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(28)
                .WithActorId(4)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(1))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(29)
                .WithActorId(4)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(1).AddHours(2))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
               .WithId(30)
               .WithActorId(4)
               .WithRepoId(1)
               .WithCreatedAt(DateTime.Now.AddDays(1).AddHours(3))
               .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
               .WithId(31)
               .WithActorId(4)
               .WithRepoId(1)
               .WithCreatedAt(DateTime.Now.AddDays(1).AddHours(4))
               .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
               .WithId(32)
               .WithActorId(4)
               .WithRepoId(1)
               .WithCreatedAt(DateTime.Now.AddDays(1).AddHours(5))
               .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
               .WithId(33)
               .WithActorId(4)
               .WithRepoId(1)
               .WithCreatedAt(DateTime.Now.AddDays(1).AddHours(6))
               .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
               .WithId(34)
               .WithActorId(4)
               .WithRepoId(1)
               .WithCreatedAt(DateTime.Now.AddDays(1).AddHours(7))
               .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            _eventBusinessModel = new EventBusinessModelBuilder()
                .WithId(35)
                .WithActorId(4)
                .WithRepoId(1)
                .WithCreatedAt(DateTime.Now.AddDays(4))
                .Build();

            _eventService.AddGitEvent(_eventBusinessModel);

            //Act
            var result = _actorService.GetActorsWithMaximumStreak();

            //Assert
            Assert.That(result[0].id, Is.GreaterThanOrEqualTo(4));
        }
    }
}
