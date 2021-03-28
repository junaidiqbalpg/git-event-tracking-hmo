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
using Microsoft.Extensions.Options;
using GitEventTracking.Web.Config;
using GitEventTracking.Web.Services;
using static GitEventTracking.Web.Helper.Common;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Net;
using GitEventTrackingApi.ViewModel;
using Newtonsoft.Json;

namespace GitEventTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppSettings _appSettings;
        private readonly IApiClient _apiClient;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings, IApiClient apiClient)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
            _apiClient = apiClient;
        }

        public IActionResult Index(ViewModel.EventViewModel eventViewModel)
        {
            return View(eventViewModel);
        }

        [HttpPost]
        [Route("Submit")]
        public IActionResult Submit(ViewModel.EventViewModel eventViewModel)
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
                repo.url = eventViewModel.repoLink;
                eventBindingModel.repo = repo;

                eventBindingModel.created_at = eventViewModel.createdAt;

                string url = string.Format("{0}Event", _appSettings.APIUrl);

                string response = string.Empty;

                try
                {
                    response = _apiClient.InvokeApi(ApiMethods.POST, url, eventBindingModel);

                    JObject result = JObject.Parse(response);

                    eventViewModel.message = "Event added successfully!!!";
                }
                catch(WebException e)
                {
                    eventViewModel.message = e.Message;
                }

            }
            return View("Index", eventViewModel);
        }

        [HttpPost]
        [Route("CalculateMaxStreakActor")]
        public IActionResult CalculateMaxStreakActor()
        {
            ViewModel.EventViewModel eventViewModel = new ViewModel.EventViewModel();
            string url = string.Format("{0}Actor/streak", _appSettings.APIUrl);

            string response = string.Empty;

            try
            {
                response = _apiClient.InvokeApi(ApiMethods.GET, url);

                List<ActorViewModel> actors = JsonConvert.DeserializeObject<List<ActorViewModel>>(response);

                eventViewModel.maxStreakActorViewModel.actors = actors;
            }
            catch (WebException e)
            {
                eventViewModel.message = e.Message;
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
