using AutoMapper;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Service.BindingModel;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.ViewModel;

namespace GitEventTrackingApi.MappingConfigurations
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
