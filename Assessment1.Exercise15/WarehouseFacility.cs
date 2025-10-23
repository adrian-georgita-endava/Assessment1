using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise15
{
    public class WarehouseFacility : IStorageFacility
    {
        public string Name { get; set; }
        public int FacilityId { get; init; }
        public int Capacity { get; set; }
        public int Units { get; set; }
        private List<IProduct> _products;

        public WarehouseFacility(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            _products = new();
            FacilityId = IdGenerator.GetNextFacilityId();
        }

        public IProduct? GetProduct(int productId) => _products.FirstOrDefault(p => p.ProductId == productId);

        public void AddProduct(IProduct product) => _products.Add(product);

        public void AddUnits(IProduct product, int units)
        {
            if (!_products.Contains(product))
            {
                throw new Exception("The product does not exist in the facility!");
            }

            if (Units +  units * product.GetStorageUnitWeight() > Capacity)
            {
                throw new Exception("Not enough space for the units in the facility!");
            }

            _products.First(p => p == product).Stock += units;
        }
        public void RemoveProduct(IProduct product)
        {
            if(!_products.Remove(product))
            {
                throw new Exception("The product does not exist in the facility!");
            }
        }
        public void RemoveUnits(IProduct product, int units)
        {
            if (!_products.Contains(product))
            {
                throw new Exception("The product does not exist in the facility!");
            }

            if (units < 0)
            {
                throw new Exception("The units number must be positive!");
            }

            if(units > _products.First(p => p == product).Stock)
            {
                throw new Exception("Cannot remove more units than existent in stock");
            }

            _products.First(p => p == product).Stock -= units;
        }
        public decimal GetBaseTotal() => _products.Sum(p => p.BasePrice * p.Stock);
        public decimal GetTotal() => _products.Sum(p => p.GetPrice() * p.Stock);

        public void DisplayProducts()
        {
            Console.WriteLine($"Facility: {Name} Products: ");
            foreach(var product in _products)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine($"Total Value: {GetTotal()}");
        }
    }
}
