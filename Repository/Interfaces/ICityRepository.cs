using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;

namespace Repository.Interfaces
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAll();
        City GetById(int id);
    }
}
