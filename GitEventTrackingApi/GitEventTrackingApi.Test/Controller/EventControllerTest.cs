using AutoMapper;
using GitEventTrackingApi.Controllers;
using GitEventTrackingApi.Service.BindingModel;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.Controller
{
    public class EventControllerTest
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
        public void ShouldReturnA200OkResult()
        {
            //Arrange
            Int64 expectedEventId = 1234567;

            _mockEventService.Setup(eventService => eventService.AddGitEvent(_eventBusinessModel))
                .Returns(expectedEventId);

            //Act
            var result = _eventController.AddNewEvent(_eventBindingModel);

            //Assert
            var okResult = result as CreatedAtActionResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(201));
        }

    }
}
