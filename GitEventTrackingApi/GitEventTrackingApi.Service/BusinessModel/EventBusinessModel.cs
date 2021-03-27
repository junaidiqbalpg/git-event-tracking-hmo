using GitEventTrackingApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Service.BusinessModel
{
    //AGAIN LIKE BINDING MODEL, IF WE ARE NOT PASSING CREATED_AT ATTRIBUTE FROM INTERFACE, WE CAN REMOVE IT FROM THIS CLASS AND WE ONLY PASS
    //THAT INFORMATION WHICH IS NEED (WITH NO EXTRA ATTRIBUTE), BUT IN OUR EXAMPLE, WE WILL PASS CREATED_AT FROM INTERFACE.
    public class EventBusinessModel
    {
        public Int64 id { get; set; }
        public string type { get; set; }
        public Actor actor { get; set; }
        public Repo repo { get; set; }
        public DateTime created_at { get; set; }
    }
}
