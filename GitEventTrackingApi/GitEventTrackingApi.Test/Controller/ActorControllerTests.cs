using AutoMapper;
using GitEventTrackingApi.Controllers;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.Service.Services;
using GitEventTrackingApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GitEventTrackingApi.Test.Controller
{
    public class ActorControllerTests
    {
        private ActorController _actorController;

        private Mock<IActorService> _mockActorService;

        private List<ActorBusinessModel> _actorBusinessModel;

        private IMapper _mapper;

        [SetUp]
        public void Init()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Startup).Assembly));
            _mapper = config.CreateMapper();

            _mockActorService = new Mock<IActorService>();
            _actorController = new ActorController(_mockActorService.Object, _mapper);

            _actorBusinessModel = new List<ActorBusinessModel>();
        }

        [Test]
        public void ShouldReturnA200GetStreakResult()
        {
            //Arrange
            _mockActorService.Setup(actorService => actorService.GetActorsWithMaximumStreak())
                .Returns(_actorBusinessModel);

            //Act
            ActionResult<List<ActorViewModel>> actionResult = _actorController.GetStreak();

            //Assert
            var result = (OkObjectResult)actionResult.Result;
            Assert.AreEqual(result.StatusCode, 200);
        }
    }
}
