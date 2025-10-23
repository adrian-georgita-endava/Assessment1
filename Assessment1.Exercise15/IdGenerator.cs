using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise15
{
    public static class IdGenerator
    {
        private static int _currentProductId = 0;
        private static int _currentFacilityId = 0;

        public static int GetNextProductId() => _currentProductId++;
        public static int GetNextFacilityId() => _currentFacilityId++;
    }
}
