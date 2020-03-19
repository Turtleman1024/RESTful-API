using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.Contracts.v1.Requests
{
    public class UserRegistractionRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
