using RESTful_API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.Services
{
    public interface ITripService
    {
        Task<List<Trip>> GetTripsAsync();

        Task<Trip> GetTripByIdAsync(Guid postId);

        Task<bool> CreateTripAsync(Trip trip);

        Task<bool> UpdateTripAsync(Trip postToUpdate);

        Task<bool> DeleteTripAsync(Guid tripId);

        Task<bool> UserOwnsTripAsync(Guid tripId, string getUserId);
    }
}
