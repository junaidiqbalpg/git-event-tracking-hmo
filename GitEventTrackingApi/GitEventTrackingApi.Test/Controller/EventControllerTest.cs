using GitEventTrackingApi.Controllers;
using GitEventTrackingApi.Service.BindingModel;
using Microsoft.AspNetCore.Mvc;
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
        [SetUp]
        public void Init()
        {
            _eventController = new EventController();
            _eventBindingModel = new EventBindingModel();
        }

        [Test]
        public void ShouldReturnA200OkResult()
        {
            //Act
            var result = _eventController.AddNewEvent(_eventBindingModel);

            //Assert
            var okResult = result as CreatedAtActionResult;
            Assert.That(okResult.StatusCode, Is.EqualTo(201));
        }

    }
}
