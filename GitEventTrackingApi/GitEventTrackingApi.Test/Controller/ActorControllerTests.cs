using GitEventTrackingApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.Controller
{
    public class ActorControllerTests
    {
        private ActorController _actorController;

        [SetUp]
        public void Init()
        {

            _actorController = new ActorController();
        }

        [Test]
        public void ShouldReturnA201CreateResult()
        {
            //Act
            var result = _actorController.GetStreak();

            //Assert
            var ok = result as OkResult;
            Assert.That(ok.StatusCode, Is.EqualTo(200));
        }
    }
}
