using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Service.BusinessModel
{
    public class ActorBusinessModel
    {
        public int id { get; set; }
        public string login { get; set; }
        public string avatar_url { get; set; }
    }
}
