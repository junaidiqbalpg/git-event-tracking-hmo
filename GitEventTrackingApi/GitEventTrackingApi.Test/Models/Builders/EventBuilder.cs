using GitEventTrackingApi.Data.Domain;
using System;

namespace GitEventTrackingApi.Test.Models.Builders
{
    public class EventBuilder
    {
        private Int64 _id = 123456;
        private string _type = "EventType";
        private Actor _actor = new Actor();
        private Repo _repo = new Repo();
        private DateTime _createdAt = DateTime.Now;
        public Event Build()
        {
            return new Event
            {
                id = _id,
                type = _type,
                actor = _actor,
                repo = _repo,
                created_at = _createdAt
            };
        }

        public EventBuilder WithId(Int64 id)
        {
            _id = id;
            return this;
        }

        public EventBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public EventBuilder WithActor(Actor actor)
        {
            _actor = actor;
            return this;
        }

        public EventBuilder WithRepo(Repo repo)
        {
            _repo = repo;
            return this;
        }

        public EventBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
    }
}
