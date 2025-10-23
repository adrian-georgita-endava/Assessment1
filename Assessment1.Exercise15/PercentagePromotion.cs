using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise15
{
    public class PercentagePromotion : IPromotion
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal DiscountRate { get; set; }

        public PercentagePromotion(string name, decimal discountRate)
        {
            Name = name;
            DiscountRate = discountRate;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MaxValue;
        }

        public PercentagePromotion(string name, decimal discountRate, DateTime startDate)
        {
            Name = name;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = DateTime.MaxValue;
        }

        public PercentagePromotion(string name, decimal discountRate, DateTime startDate, DateTime endDate)
        {
            Name = name;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsApplicable(IProduct product) => DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate;
        public decimal GetDiscount(IProduct product) => product.BasePrice * DiscountRate;

        public override string ToString()
        {
            return $"{Name} Discount of: {DiscountRate * 100}%, valid from {StartDate} to {EndDate}";
        }
    }
}
