using RESTful_API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.Services
{
    public interface ITripService
    {
        List<Trip> GetTrips();

        Trip GetTripById(Guid postId);

        bool UpdateTrip(Trip postToUpdate);
    }
}
