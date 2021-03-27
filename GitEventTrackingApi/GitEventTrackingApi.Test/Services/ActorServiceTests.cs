using AutoMapper;
using GitEventTrackingApi.Data;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Services;
using GitEventTrackingApi.Test.Helper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.Services
{
    public class ActorServiceTests
    {
        private ActorService _actorService;
        private ActorRepository _actorRespository;
        private IMapper _mapper;

        private Mock<ILogger<ActorRepository>> _actorRepositoryLogger;

        private GitEventTrackingContext _context = new SqliteDbContext().CreateContext();

        [SetUp]
        public void Init()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Startup).Assembly));
            _mapper = config.CreateMapper();

            _actorRepositoryLogger = new Mock<ILogger<ActorRepository>>();
            _actorRespository = new ActorRepository(_context, _actorRepositoryLogger.Object);

            _actorService = new ActorService(_actorRespository, _mapper);
        }

        [Test]
        public void ReturnActorBusinessModelForAddGitEvent()
        {
            //Arrange
            List<ActorBusinessModel> actorBusinessModels = new List<ActorBusinessModel>();

            //Act
            var result = _actorService.GetActorsWithMaximumStreak();

            //Assert
            Assert.That(result.Count, Is.EqualTo(actorBusinessModels.Count));
        }
    }
}
