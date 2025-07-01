using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.DTOs;

namespace BusinessLayer.Interfaces
{
    public interface IDistanceService
    {
        DistanceResponse CalculateDistance(DistanceRequest request);
    }
}
