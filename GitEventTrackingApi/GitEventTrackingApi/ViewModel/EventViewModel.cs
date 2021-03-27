using GitEventTrackingApi.Data.Domain;
using System;

namespace GitEventTrackingApi.ViewModel
{
    public class EventViewModel
    {
        public Int64 id { get; set; }
        public string type { get; set; }
        public Actor actor { get; set; }
        public Repo repo { get; set; }
        public DateTime created_at { get; set; }
    }
}
