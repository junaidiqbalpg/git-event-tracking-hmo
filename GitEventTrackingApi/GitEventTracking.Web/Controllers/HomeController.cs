using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GitEventTracking.Web.Models;
using GitEventTracking.Web.ViewModel;
using GitEventTrackingApi.Service.BindingModel;

namespace GitEventTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit(EventViewModel eventViewModel)
        {
            if (ModelState.IsValid)
            {
                EventBindingModel eventBindingModel = new EventBindingModel();
                eventBindingModel.id = eventViewModel.eventId;
                eventBindingModel.type = eventViewModel.eventType;

                GitEventTrackingApi.Data.Domain.Actor actor = new GitEventTrackingApi.Data.Domain.Actor();
                actor.id = eventViewModel.actorId;
                actor.login = eventViewModel.actorLogin;
                actor.avatar_url = eventViewModel.avatarUrl;
                eventBindingModel.actor = actor;

                GitEventTrackingApi.Data.Domain.Repo repo = new GitEventTrackingApi.Data.Domain.Repo();
                repo.id = eventViewModel.repoId;
                repo.name = eventViewModel.repoName;
                repo.url = eventViewModel.avatarUrl;
                eventBindingModel.repo = repo;

                eventBindingModel.created_at = eventViewModel.createdAt;

            }
            return View("Index", eventViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
