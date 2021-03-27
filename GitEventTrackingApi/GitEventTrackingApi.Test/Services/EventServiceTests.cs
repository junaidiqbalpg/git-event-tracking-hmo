using AutoMapper;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Services;
using GitEventTrackingApi.Test.Models.Builders;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.Services
{
    public class EventServiceTests
    {
        private EventService _eventService;
        private EventBusinessModel _eventBusinessModel;

        private Mock<IEventRespository> _mockEventRespository;
        private IMapper _mapper;
        private Mock<ILogger<EventService>> _eventServiceLogger;

        private Event _event;
        private Actor _actor;
        private Repo _repo;

        [SetUp]
        public void Init()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Startup).Assembly));
            _mapper = config.CreateMapper();

            _mockEventRespository = new Mock<IEventRespository>();
            _eventServiceLogger = new Mock<ILogger<EventService>>();

            _eventService = new EventService(_mockEventRespository.Object,
                _mapper, _eventServiceLogger.Object);
            
            _eventBusinessModel = new EventBusinessModel();

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
    }
}
