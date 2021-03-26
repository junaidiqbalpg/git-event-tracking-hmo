using GitEventTrackingApi.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.Controller
{
    public class EventControllerTest
    {
        private EventController _eventController;

        [SetUp]
        public void Init()
        {
            _eventController = new EventController();
        }

        [Test]
        public void ShouldReturnA200OkResult()
        {
            //Act

            //Act

            //Assert
        }

    }
}
