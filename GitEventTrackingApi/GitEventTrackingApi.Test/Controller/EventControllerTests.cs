using AutoMapper;
using GitEventTrackingApi.Controllers;
using GitEventTrackingApi.Service.BindingModel;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace GitEventTrackingApi.Test.Controller
{
    public class EventControllerTests
    {
        private EventController _eventController;
        private EventBindingModel _eventBindingModel;
        private EventBusinessModel _eventBusinessModel;

        private Mock<IEventService> _mockEventService;

        private IMapper _mapper;
        [SetUp]
        public void Init()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Startup).Assembly));
            _mapper = config.CreateMapper();

            _mockEventService = new Mock<IEventService>();

            _eventController = new EventController(_mockEventService.Object, _mapper);
            _eventBindingModel = new EventBindingModel();
            _eventBusinessModel = new EventBusinessModel();
        }

        [Test]
        public void ShouldReturnA201CreateResult()
        {

            _mockEventService.Setup(eventService => eventService.AddGitEvent(It.IsAny<EventBusinessModel>()))
                .Returns(_eventBusinessModel);

            //Act
            var result = _eventController.AddNewEvent(_eventBindingModel);

            //Assert
            var okResult = result as CreatedAtActionResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(201));
        }

    }
}
