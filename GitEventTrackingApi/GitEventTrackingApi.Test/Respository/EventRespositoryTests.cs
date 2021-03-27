using AutoMapper;
using GitEventTrackingApi.Data;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Test.Helper;
using GitEventTrackingApi.Test.Models.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GitEventTrackingApi.Test.Respository
{
    public class EventRespositoryTests
    {
        private EventRespository _eventRespository;

        private Mock<ILogger<EventRespository>> _eventRepositoryLogger;

        private IMapper _mapper;

        private GitEventTrackingContext _context = new SqliteDbContext().CreateContext();

        private Event _event;
        private Actor _actor;
        private Repo _repo;

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Startup).Assembly));
            _mapper = config.CreateMapper();

            _eventRepositoryLogger = new Mock<ILogger<EventRespository>>();

            _eventRespository = new EventRespository(_context, _eventRepositoryLogger.Object);

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
        public void SeedDatabaseWithDuplicateEventResultsInException()
        {
            //Act
            var result1 = _eventRespository.AddEvent(_event);

            //Assert            
            Assert.Throws<DbUpdateException>(() => _eventRespository.AddEvent(_event));
        }
    }
}
