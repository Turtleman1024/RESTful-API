using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Trips
        {
            public const string GetAll = Base + "/trips";

            public const string Get = Base + "/trips/{tripId}";

            public const string Update = Base + "/trips/{tripId}";

            public const string Delete = Base + "/trips/{tripId}";

            public const string Create = Base + "/trips";
        }


        //Not really a RESTful way of doing this
        public static class Identity
        {
            public const string login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

        }
    }
}
