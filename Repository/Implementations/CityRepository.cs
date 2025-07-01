using DomainModel.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class CityRepository : ICityRepository
    {
        private static readonly List<City> Cities = new List<City>
        {
            new City { Id = 1, Name = "Buenos Aires", Latitude = -34.6037, Longitude = -58.3816 },
            new City { Id = 2, Name = "Cordoba",      Latitude = -31.4201, Longitude = -64.1888 },
            new City { Id = 3, Name = "Mendoza",       Latitude = -32.8895, Longitude = -68.8458 }
        };

        public IEnumerable<City> GetAll() => Cities;

        public City GetById(int id) => Cities.FirstOrDefault(c => c.Id == id);
    }
}
