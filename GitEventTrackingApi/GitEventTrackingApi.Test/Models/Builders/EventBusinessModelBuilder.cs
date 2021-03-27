using GitEventTrackingApi.Data.Domain;
using GitEventTrackingApi.Service.BusinessModel;
using System;

namespace GitEventTrackingApi.Test.Models.Builders
{
    public class EventBusinessModelBuilder
    {
        private Int64 _id = 123456;
        private string _type = "EventType";
        private Actor _actor;
        private int _actorId = 1;
        private Repo _repo;
        private int _repoId = 1;
        private DateTime _createdAt = DateTime.Now;
        public EventBusinessModel Build()
        {
            return new EventBusinessModel
            {
                id = _id,
                type = _type,
                actor = _actor,
                actorId = _actorId,
                repo = _repo,
                repoId = _repoId,
                created_at = _createdAt
            };
        }

        public EventBusinessModelBuilder WithId(Int64 id)
        {
            _id = id;
            return this;
        }

        public EventBusinessModelBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public EventBusinessModelBuilder WithActor(Actor actor)
        {
            _actor = actor;
            return this;
        }

        public EventBusinessModelBuilder WithActorId(int id)
        {
            _actorId = id;
            return this;
        }

        public EventBusinessModelBuilder WithRepo(Repo repo)
        {
            _repo = repo;
            return this;
        }

        public EventBusinessModelBuilder WithRepoId(int id)
        {
            _repoId = id;
            return this;
        }

        public EventBusinessModelBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }
    }
}
