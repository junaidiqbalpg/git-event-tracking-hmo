using System;

namespace GitEventTracking.Web.ViewModel
{
    public class EventViewModel
    {
        public string eventId { get; set; }
        public string eventType { get; set; }
        public string actorId { get; set; }
        public string actorLogin { get; set; }
        public string avatarUrl { get; set; }
        public string repoId { get; set; }
        public string repoName { get; set; }
        public string repoLink { get; set; }
        public DateTime createdAt { get; set; }

        public string message { get; set; }

        public MaxStreakActorViewModel maxStreakActorViewModel { get; set; }

        public EventViewModel()
        {
            maxStreakActorViewModel = new MaxStreakActorViewModel();
        }
    }
}
