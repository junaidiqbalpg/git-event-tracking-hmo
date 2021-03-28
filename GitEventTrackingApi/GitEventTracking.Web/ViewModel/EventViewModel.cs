using System;

namespace GitEventTracking.Web.ViewModel
{
    public class EventViewModel
    {
        public Int64 eventId { get; set; }
        public string eventType { get; set; }
        public int actorId { get; set; }
        public string actorLogin { get; set; }
        public string avatarUrl { get; set; }
        public int repoId { get; set; }
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
