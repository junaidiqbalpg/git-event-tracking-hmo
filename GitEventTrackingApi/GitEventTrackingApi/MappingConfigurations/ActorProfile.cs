using AutoMapper;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Service.BusinessModel;
using GitEventTrackingApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitEventTrackingApi.MappingConfigurations
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorBusinessModel, Actor>();

            CreateMap<Actor, ActorBusinessModel> ();

            CreateMap<ActorBusinessModel, ActorViewModel>();
        }
    }
}
