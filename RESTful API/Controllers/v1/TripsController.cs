using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTful_API.Contracts;
using RESTful_API.Contracts.v1.Requests;
using RESTful_API.Contracts.v1.Responses;
using RESTful_API.DomainModels;
using RESTful_API.Services;

namespace RESTful_API.Controllers
{

    public class TripsController : Controller
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService postService)
        {
            _tripService = postService;
        }

        #region Get
        [HttpGet(ApiRoutes.Trips.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_tripService.GetTrips());
        }

        [HttpGet(ApiRoutes.Trips.Get)]
        public IActionResult Get([FromRoute] Guid tripId)
        {
            var trip = _tripService.GetTripById(tripId);

            if(trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }
        #endregion

        #region Put
        [HttpPut(ApiRoutes.Trips.Update)]
        public IActionResult Update([FromRoute] Guid tripId, [FromBody] UpdateTripRequest request)
        {
            var trip = new Trip 
            { 
                Id = tripId,
                Name = request.Name
            };

            var updated = _tripService.UpdateTrip(trip);
            
            if(updated)
            {
                return Ok(trip);
            }

            return NotFound();
        }
        #endregion

        #region Post
        [HttpPost(ApiRoutes.Trips.Create)]
        public IActionResult Create([FromBody] CreateTripRequest tripRequest)
        {
            var trip = new Trip { Id = tripRequest.Id };

            if(trip.Id != Guid.Empty)
            {
                trip.Id = Guid.NewGuid();
            }

            _tripService.GetTrips().Add(trip);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUri = baseUrl + "/" + ApiRoutes.Trips.Get.Replace("{tripId}", trip.Id.ToString());

            var response = new TripResponse { Id = trip.Id };

            return Created(locationUri, response);
        }
        #endregion
    }
}