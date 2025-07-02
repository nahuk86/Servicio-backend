using DomainModel.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Repository.Implementations
{
    public class CityRepository : ICityRepository
    {
        private readonly List<City> _cities;

        public CityRepository(IConfiguration configuration)
        {
            // Lee y deserializa la sección "Cities" de appsettings.json
            _cities = configuration
                .GetSection("Cities")
                .Get<List<City>>()
                ?? new List<City>();
        }

        public IEnumerable<City> GetAll() => _cities;

        public City GetById(int id) =>
            _cities.FirstOrDefault(c => c.Id == id)
            ?? throw new KeyNotFoundException("Ciudad no encontrada.");
    }
}
