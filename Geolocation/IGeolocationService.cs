using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SBData.Entities;

namespace Geolocation
{
    public interface IGeolocationService
    {
        public Task<double> GetDistance(Address start, Address end);
    }
}
