using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise15
{
    public interface IStorageFacility
    {
        public string Name { get; set; }
        public int FacilityId { get; init; }
        public int Capacity { get; set; }
        public int Units { get; set; }
        public IProduct? GetProduct(int productId);
        public void AddProduct(IProduct product);
        public void AddUnits(IProduct product, int units);
        public void RemoveProduct(IProduct product);
        public void RemoveUnits(IProduct product, int units);
        public decimal GetBaseTotal();
        public decimal GetTotal();

        public void DisplayProducts();
    }
}
