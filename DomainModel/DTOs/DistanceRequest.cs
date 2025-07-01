using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOs
{
    public class DistanceRequest
    {
        public int CityId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
