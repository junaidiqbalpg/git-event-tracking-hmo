using System;

namespace GitEventTrackingApi.Data.Domain
{
    public class Event
    {
        public Int64 id { get; set; }
        public string type { get; set; }
        public Actor actor { get; set; }
        public Repo repo { get; set; }
        public DateTime created_at {get;set;}
    }
}
