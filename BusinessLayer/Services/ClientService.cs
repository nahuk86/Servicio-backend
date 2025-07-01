using BusinessLayer.Interfaces;
using DomainModel.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ClientService : IClientService
    {
        private readonly ICityRepository _cityRepo;

        public ClientService(ICityRepository cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public IEnumerable<City> GetAllCities() => _cityRepo.GetAll();
    }
}
