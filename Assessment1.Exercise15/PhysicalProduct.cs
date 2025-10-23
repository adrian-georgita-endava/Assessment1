using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise15
{
    public class PhysicalProduct : IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductId { get; init; }
        public int Stock { get; set; }
        public decimal BasePrice { get; set; }
        private int _weight;

        private List<IPromotion> _promotions;

        public PhysicalProduct(string name, string description, int stock, decimal basePrice, int weight)
        {
            Name = name;
            Description = description;
            Stock = stock;
            BasePrice = basePrice;
            ProductId = IdGenerator.GetNextProductId();
            _weight = weight;
            _promotions = new();
        }

        public void AddPromotion(IPromotion promotion) => _promotions.Add(promotion);
        public void RemovePromotion(IPromotion promotion) => _promotions.Remove(promotion);

        public decimal GetPrice() => ApplyPromotions(BasePrice);

        public int GetStorageUnitWeight() => _weight;

        private decimal ApplyPromotions(decimal basePrice)
        {
            decimal price = basePrice;
            foreach(var promotion in _promotions)
            {
                price -= promotion.IsApplicable(this) ? promotion.GetDiscount(this) : 0;
            }
            return Math.Max(price, 0);
        }

        public override string ToString()
        {
            return $"[{ProductId}] Product: {Name}, Description: {Description}, Stock: {Stock}, Price: ${GetPrice()}";
        }
    }
}
