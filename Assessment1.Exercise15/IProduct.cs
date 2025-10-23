using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise15
{
    public interface IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; init; }
        public int Stock {  get; set; }
        public decimal BasePrice { get; set; }
        public void AddPromotion(IPromotion promotion);
        public void RemovePromotion(IPromotion promotion);
        public decimal GetPrice();
        public int GetStorageUnitWeight();

        public string ToString();
    }
}
