using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.Services
{
    public class ActorServiceTests
    {
        private ActorService _actorService;

        [SetUp]
        public void Init()
        {
            _actorService = new ActorService();
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
