using AutoMapper;
using GitEventTrackingApi.Service.BindingModel;
using GitEventTrackingApi.Service.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitEventTrackingApi.MappingConfigurations
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventBindingModel, EventBusinessModel>();
        }
    }
}
