using AutoMapper;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Service.BindingModel;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitEventTrackingApi.Test.MappingConfigurations
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventBindingModel, EventBusinessModel>();

            CreateMap<EventBusinessModel, Event>();

            CreateMap<Event, EventBusinessModel>();

            CreateMap<EventBusinessModel, EventViewModel>();
        }
    }
}
