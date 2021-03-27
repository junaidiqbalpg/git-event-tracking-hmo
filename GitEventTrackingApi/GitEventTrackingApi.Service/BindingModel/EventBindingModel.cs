using GitEventTrackingApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Service.BindingModel
{
    //IN BINDING MODEL, THERE CAN BE SOME CLASS ATTRIBUTES WHICH ARE NOT NEEDED TO BE PASSED FROM THE FRONTEND LIKE ID (BUT IN OUR EXAMPLE,
    //WE NEED TO PASS THE ID TO CHECK THE DUPLICATION OF EVENT. SO WE ONLY PASS THAT INFORMATION IN BINDING MODEL WHICH IS NEEDED. 
    //NO EXTRA INFORMATION WILL BE PASSED. 
    public class EventBindingModel
    {
        public Int64 id { get; set; }
        public string type { get; set; }
        public Actor actor { get; set; }
        public Repo repo { get; set; }
        public DateTime created_at { get; set; }
    }
}
