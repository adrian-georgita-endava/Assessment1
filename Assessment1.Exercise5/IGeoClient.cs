using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise5
{
    public interface IGeoClient
    {
        public Task<GeoCoords?> GetGeoCoordinatesAsync(string location);
    }
}
