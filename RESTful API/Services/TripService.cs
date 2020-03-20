using Microsoft.EntityFrameworkCore;
using RESTful_API.Data;
using RESTful_API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_API.Services
{
    public class TripService : ITripService
    {
        private readonly DataContext _dataContext;

        public TripService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateTripAsync(Trip trip)
        {
            await _dataContext.Trips.AddAsync(trip);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteTripAsync(Guid tripId)
        {
            var trip = await GetTripByIdAsync(tripId);

            if(trip == null)
            {
                return false;
            }

            _dataContext.Trips.Remove(trip);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Trip> GetTripByIdAsync(Guid tripId)
        {
            return await _dataContext.Trips.SingleOrDefaultAsync(x => x.Id == tripId);
        }

        public async Task<List<Trip>> GetTripsAsync()
        {
            return await _dataContext.Trips.ToListAsync();
        }

        public async Task<bool> UpdateTripAsync(Trip tripToUpdate)
        {
            _dataContext.Trips.Update(tripToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> UserOwnsTripAsync(Guid tripId, string userId)
        {
            var trip = await _dataContext.Trips.AsNoTracking().SingleOrDefaultAsync(predicate: x => x.Id == tripId);

            if (trip == null)
            {
                return false;
            }

            if (trip.UserId != userId)
            {
                return false;
            }

            return true;

        }
    }
}
