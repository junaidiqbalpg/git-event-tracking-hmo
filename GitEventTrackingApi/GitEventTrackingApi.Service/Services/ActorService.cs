using AutoMapper;
using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Data.Repository;
using GitEventTrackingApi.Service.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitEventTrackingApi.Service.Services
{
    public class ActorService : IActorService
    {
        private readonly IEventRespository _eventRespository;
        private readonly IMapper _mapper;
        public ActorService(IEventRespository eventRespository, IMapper mapper)
        {
            _eventRespository = eventRespository;
            _mapper = mapper;
        }

        public List<ActorBusinessModel> GetActorsWithMaximumStreak()
        {
            var allEvents = _eventRespository.GetAllEvents();

            var actorsWithMaximumStreak = new List<Actor>();

            if (allEvents.Count > 0)
            {
                actorsWithMaximumStreak = GetActorsRecordByMaximumStreak(allEvents);
            }

            return _mapper.Map<List<ActorBusinessModel>>(actorsWithMaximumStreak);
        }

        private List<Actor> GetActorsRecordByMaximumStreak(List<Event> events)
        {
            List<Actor> actors = new List<Actor>();

            events = events.OrderBy(e => e.created_at).ToList();
            //this will hold the resulted groups
            var groups = new List<List<DateTime>>();
            // the group for the first element
            var group1 = new List<DateTime>() { events[0].created_at };
            groups.Add(group1);

            DateTime lastDate = events[0].created_at;

            var allActors = events.Select(e => e.actor).Distinct().ToList();

            Dictionary<Actor, int> actorEventsCounts = new Dictionary<Actor, int>();

            foreach (var actor in allActors)
            {
                var eventsPerActor = events.Where(e => e.actor.id == actor.id).ToList();

                groups = new List<List<DateTime>>();
                group1 = new List<DateTime>() { eventsPerActor[0].created_at };
                groups.Add(group1);

                lastDate = eventsPerActor[0].created_at;

                for (int i = 1; i < eventsPerActor.Count; i++)
                {
                    DateTime currDate = eventsPerActor[i].created_at;
                    TimeSpan timeDiff = currDate - lastDate;
                    //should we create a new group?
                    bool isNewGroup = timeDiff.Days > 1;
                    if (isNewGroup)
                    {
                        groups.Add(new List<DateTime>());
                    }
                    groups.Last().Add(currDate);
                    lastDate = currDate;
                }

                var total = groups.OrderByDescending(x => x.Count()).ToList();

                if (total != null)
                {
                    int max = total[0].Count;
                    actorEventsCounts.Add(actor, max);
                }
            }

            actors = actorEventsCounts.OrderByDescending(ae => ae.Value).Select(ae => ae.Key).ToList();

            return actors;
        }
    }
}
