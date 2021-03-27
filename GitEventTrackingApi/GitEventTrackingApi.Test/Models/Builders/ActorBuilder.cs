using GitEventTrackingApi.Data.Domain;

namespace GitEventTrackingApi.Test.Models.Builders
{
    public class ActorBuilder
    {
        private int _id = 1;
        private string _login = "testlogin";
        private string _avatar_url = "https://avatar.com";

        public Actor Build()
        {
            return new Actor
            {
                id = _id,
                login = _login,
                avatar_url = _avatar_url
            };
        }

        public ActorBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public ActorBuilder WithLogin(string login)
        {
            _login = login;
            return this;
        }

        public ActorBuilder WithAvatarUrl(string avatarUrl)
        {
            _avatar_url = avatarUrl;
            return this;
        }
    }
}
