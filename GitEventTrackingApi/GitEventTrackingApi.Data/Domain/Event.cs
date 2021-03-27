using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GitEventTrackingApi.Data.Domain
{
    public class Event
    {
        public Int64 id { get; set; }
        public string type { get; set; }
        [NotMapped]
        public Actor actor { get; set; }
        public int actorId { get; set; }
        public Repo repo { get; set; }
        public int repoId { get; set; }
        public DateTime created_at {get;set;}
    }
}
