using AutoMapper;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.ViewModel;

namespace GitEventTrackingApi.MappingConfigurations
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorBusinessModel, Actor>();

            CreateMap<Actor, ActorBusinessModel> ();

            CreateMap<ActorBusinessModel, ActorViewModel>();

            CreateMap<ActorViewModel, ActorBusinessModel>();
        }
    }
}
