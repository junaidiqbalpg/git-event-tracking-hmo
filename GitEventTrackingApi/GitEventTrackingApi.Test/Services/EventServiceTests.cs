using AutoMapper;
using GitEventTrackingApi.Data;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Services;
using GitEventTrackingApi.Test.Helper;
using GitEventTrackingApi.Test.Models.Builders;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace GitEventTrackingApi.Test.Services
{
    public class EventServiceTests
    {
        private EventService _eventService;
        private EventService _eventServiceWithoutMoq;

        private EventBusinessModel _eventBusinessModel;

        private Mock<IEventRespository> _mockEventRespository;
        private EventRespository _eventRespository;

        private IMapper _mapper;
        private Mock<ILogger<EventService>> _eventServiceLogger;
        private Mock<ILogger<EventRespository>> _eventRespositoryLogger;

        private Event _event;
        private Actor _actor;
        private Repo _repo;

        private GitEventTrackingContext _context = new SqliteDbContext().CreateContext();

        [SetUp]
        public void Init()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Startup).Assembly));
            _mapper = config.CreateMapper();

            _mockEventRespository = new Mock<IEventRespository>();
            _eventRespositoryLogger = new Mock<ILogger<EventRespository>>();
            
            _eventRespository = new EventRespository(_context, _eventRespositoryLogger.Object);
            _eventServiceLogger = new Mock<ILogger<EventService>>();

            _eventService = new EventService(_mockEventRespository.Object,
                _mapper, _eventServiceLogger.Object);

            _eventServiceWithoutMoq = new EventService(_eventRespository,
                _mapper, _eventServiceLogger.Object);

            _actor = new ActorBuilder()
                .Build();

            _repo = new RepoBuilder()
                .Build();

            _event = new EventBuilder()
                .WithActor(_actor)
                .WithRepo(_repo)
                .Build();

            _eventBusinessModel = new EventBusinessModelBuilder()
                .Build();
        }

        [Test]
        public void ReturnEventBusinessModelForAddGitEvent()
        {
            Int64 expectedId = 123456;
            //Arrange
            _mockEventRespository.Setup(eventRespository => eventRespository.AddEvent(It.IsAny<Event>()))
                .Returns(_event);

            //Act
            var result = _eventService.AddGitEvent(_eventBusinessModel);

            //Assert
            Assert.That(result.id, Is.EqualTo(expectedId));
        }

        [Test]
        public void ReturnValidationExceptionWhenDuplicateGitEventAdded()
        {
            //Arrange
            var _eventBusinessModel = new EventBusinessModelBuilder()
                .WithActor(_actor)
                .WithRepo(_repo)
                .Build();

            //Act
            var result = _eventServiceWithoutMoq.AddGitEvent(_eventBusinessModel);

            //Add same Git Event again which result in valiation exception
            Assert.Throws<ValidationException>(() =>  _eventServiceWithoutMoq.AddGitEvent(_eventBusinessModel));
        }
    }
}
