using GitEventTrackingApi.Data.Domain;

namespace GitEventTrackingApi.Test.Models.Builders
{
    public class RepoBuilder
    {
        private int _id = 1;
        private string _name = "testname";
        private string _url = "https://test.com";

        public Repo Build()
        {
            return new Repo
            {
                id = _id,
                name = _name,
                url = _url
            };
        }

        public RepoBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public RepoBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public RepoBuilder WithUrl(string url)
        {
            _url = url;
            return this;
        }
    }
}
