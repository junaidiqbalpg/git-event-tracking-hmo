using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.Respository
{
    public class ActorRespositoryTests
    {
        private ActorRepository _actorRepository;

        [SetUp]
        public void Init()
        {
            _actorRepository = new ActorRepository();
        }

        [Test]
        public void ReturnAllActors()
        {
            //Arrange
            List<Actor> actors = new List<Actor>();

            //Act
            var result = _actorRepository.GetAllActors();

            //Assert
            Assert.That(result.Count, Is.EqualTo(actors.Count));
        }
    }
}
