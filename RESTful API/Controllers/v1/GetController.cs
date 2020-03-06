﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTful_API.Contracts;
using RESTful_API.DomainModels;

namespace RESTful_API.Controllers
{

    public class GetController : Controller
    {
        private List<Get> _post;

        public GetController()
        {
            _post = new List<Get>();
            for (int i = 0; i < 5; i++)
            {
                _post.Add(new Get
                {
                    Id = Guid.NewGuid().ToString()
                });
            }
        }
        
        [HttpGet(ApiRoutes.Gets.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_post);
        }
    }
}