using RESTful_API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.Services
{
    public class TripService : ITripService
    {
        private readonly List<Trip> _trips;

        public TripService()
        {
            _trips = new List<Trip>();
            for (int i = 0; i < 5; i++)
            {
                _trips.Add(new Trip
                {
                    Id = Guid.NewGuid(),
                    Name = $"Post Name: {i}"
                });
            }
        }

        public Trip GetTripById(Guid postId)
        {
            return _trips.SingleOrDefault(x => x.Id == postId);
        }

        public List<Trip> GetTrips()
        {
            return _trips;
        }

        public bool UpdateTrip(Trip postToUpdate)
        {
            var exists = GetTripById(postToUpdate.Id) != null;

            if(!exists)
            {
                return false;
            }

            var index = _trips.FindIndex(x => x.Id == postToUpdate.Id);

            _trips[index] = postToUpdate;

            return true;
        }
    }
}
