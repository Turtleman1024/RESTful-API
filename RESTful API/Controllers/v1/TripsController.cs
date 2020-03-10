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
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _tripService.GetTripsAsync());
        }

        [HttpGet(ApiRoutes.Trips.Get)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid tripId)
        {
            var trip = await _tripService.GetTripByIdAsync(tripId);

            if(trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }
        #endregion

        #region Put
        [HttpPut(ApiRoutes.Trips.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid tripId, [FromBody] UpdateTripRequest request)
        {
            var trip = new Trip 
            { 
                Id = tripId,
                Name = request.Name
            };

            var updated = await _tripService.UpdateTripAsync(trip);
            
            if(updated)
            {
                return Ok(trip);
            }

            return NotFound();
        }
        #endregion

        #region Post
        [HttpPost(ApiRoutes.Trips.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTripRequest tripRequest)
        {
            var trip = new Trip { Name = tripRequest.Name };

            await _tripService.CreateTripAsync(trip);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUri = baseUrl + "/" + ApiRoutes.Trips.Get.Replace("{tripId}", trip.Id.ToString());

            var response = new TripResponse { Id = trip.Id };

            return Created(locationUri, response);
        }
        #endregion

        #region Delete
        [HttpDelete(ApiRoutes.Trips.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid tripId)
        {
            var deleted = await _tripService.DeleteTripAsync(tripId);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
        #endregion
    }
}