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
        private readonly IQueryLogger _logger;

        public DistanceService(ICityRepository cityRepo, IQueryLogger logger)
        {
            _cityRepo = cityRepo;
            _logger = logger;
        }

        public DistanceResponse CalculateDistance(DistanceRequest request)
        {
            _logger.Log($"CalcDistance | CityId={request.CityId}, Lat={request.Latitude}, Lon={request.Longitude}");

            var city = _cityRepo.GetById(request.CityId);  // lanza KeyNotFoundException si no existe

            // Fórmula de Haversine
            const double R = 6371; // radio de la Tierra en km
            double dLat = ToRadians(request.Latitude - city.Latitude);
            double dLon = ToRadians(request.Longitude - city.Longitude);
            double lat1 = ToRadians(city.Latitude);
            double lat2 = ToRadians(request.Latitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2) *
                       Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;

            // Área de un círculo de radio = distance
            double area = Math.PI * Math.Pow(distance, 2);

            var response = new DistanceResponse
            {
                Distance = distance,
                Area = area
            };

            _logger.Log($"Result       | CityId={request.CityId}, Distance={response.Distance:F2}km");

            return response;
        }

        private static double ToRadians(double angle) => angle * (Math.PI / 180);
    }
}
