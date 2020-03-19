using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTful_API.Contracts;
using RESTful_API.Contracts.v1.Requests;
using RESTful_API.Contracts.v1.Responses;
using RESTful_API.Services;

namespace RESTful_API.Controllers.v1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(template: ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistractionRequest request)
        {
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if(!authResponse.Success)
            {
                return BadRequest (new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse 
            { 
                Token = authResponse.Token
            });
        }
    }
}