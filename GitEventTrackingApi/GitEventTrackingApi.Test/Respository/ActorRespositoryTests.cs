using AutoMapper;
using GitEventTrackingApi.Data;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Test.Helper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.Respository
{
    public class ActorRespositoryTests
    {
        private ActorRepository _actorRepository;

        private Mock<ILogger<ActorRepository>> _actorRepositoryLogger;

        private GitEventTrackingContext _context = new SqliteDbContext().CreateContext();

        [SetUp]
        public void Init()
        {
            _actorRepositoryLogger = new Mock<ILogger<ActorRepository>>();

            _actorRepository = new ActorRepository(_context, _actorRepositoryLogger.Object);
        }

        [Test]
        public void ReturnAllActors()
        {
            //Arrange
            int expectedActors = 0;

            //Act
            var result = _actorRepository.GetAllActors();

            //Assert
            Assert.That(result.Count, Is.GreaterThanOrEqualTo(expectedActors));
        }
    }
}
