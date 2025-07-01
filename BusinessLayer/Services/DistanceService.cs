using BusinessLayer.Interfaces;
using DomainModel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;

namespace BusinessLayer.Services
{
    public class DistanceService : IDistanceService
    {
        private readonly ICityRepository _cityRepo;

        public DistanceService(ICityRepository cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public DistanceResponse CalculateDistance(DistanceRequest request)
        {
            var city = _cityRepo.GetById(request.CityId)
                       ?? throw new ArgumentException("Ciudad no encontrada.");

            double R = 6371; // Earth radius in kilometers
            double dLat = ToRadians(request.Latitude - city.Latitude);
            double dLon = ToRadians(request.Longitude - city.Longitude);
            double lat1 = ToRadians(city.Latitude);
            double lat2 = ToRadians(request.Latitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2) *
                       Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;

            double area = Math.PI * Math.Pow(distance, 2);

            return new DistanceResponse { Distance = distance, Area = area };
        }

        private double ToRadians(double angle) => angle * (Math.PI / 180);
    }
}
