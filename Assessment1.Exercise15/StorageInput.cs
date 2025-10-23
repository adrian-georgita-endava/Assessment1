using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise15
{
    public class StorageInput
    {
        private IStorageFacility _facility;
        private string[] _validProductTypes = { "physical", "virtual" };

        public StorageInput(IStorageFacility facility) => _facility = facility;

        public void PerformOperation(OperationsEnum operation)
        {
            IProduct? product;
            switch (operation)
            {
                case OperationsEnum.Display:
                    _facility.DisplayProducts();
                    break;
                case OperationsEnum.AddProduct:
                    product = ReadProduct();
                    _facility.AddProduct(product);
                    break;
                case OperationsEnum.AddUnits:
                    AddUnitsOperation();
                    break;
                case OperationsEnum.RemoveProduct:
                    RemoveProductOperation();
                    break;
                case OperationsEnum.RemoveUnits:
                    RemoveUnitsOperation();
                    break;
                default: throw new Exception("Invalid Operation!");
            }
        }

        public OperationsEnum ReadOperation()
        {
            Console.WriteLine("Enter the type of operation you want to perform (AddProduct/AddUnits/RemoveProduct/RemoveUnits/Display)");
            OperationsEnum operation;
            Console.Write("Operation: ");
            while (!Enum.TryParse(Console.ReadLine(), ignoreCase: true, out operation))
            {
                Console.WriteLine("Please enter a valid operation: 'AddProduct' / 'AddUnits' / 'RemoveProduct' / 'RemoveUnits' / 'Display' ");
                Console.Write("Operation: ");
            }

            return operation;
        }

        private void RemoveUnitsOperation()
        {
            int productId = ReadInteger("Product ID");
            IProduct? product = _facility.GetProduct(productId);
            if (product == null)
            {
                throw new Exception("There is no product with that id!");
            }

            int units = ReadInteger("Units to Remove");
            _facility.RemoveUnits(product, units);
        }

        private void RemoveProductOperation()
        {
            int productId = ReadInteger("Product ID");
            IProduct? product = _facility.GetProduct(productId);
            if (product == null)
            {
                throw new Exception("There is no product with that id!");
            }

            _facility.RemoveProduct(product);
        }

        private void AddUnitsOperation()
        {
            int productId = ReadInteger("Product ID");
            IProduct? product = _facility.GetProduct(productId);
            if (product == null)
            {
                throw new Exception("There is no product with that id!");
            }

            int units = ReadInteger("Units to Add");
            _facility.AddUnits(product, units);
        }

        private IProduct ReadProduct() 
        {
            string? productType;

            Console.Write("Product Type (Phyisical / Virtual): ");
            productType = Console.ReadLine();
            while(string.IsNullOrEmpty(productType) || !_validProductTypes.Contains(productType.ToLower()))
            {
                Console.WriteLine("Invalid Type. Please enter 'Physical' or 'Virtual'");
                Console.Write("Product Type: ");
                productType = Console.ReadLine();
            }

            string prodName = ReadProductName();
            int stock = ReadInteger("Stock");
            decimal price = ReadPrice();

            switch(productType.ToLower())
            {
                case "physical":
                    int weight = ReadInteger("Weight");
                    return new PhysicalProduct(prodName, "No Description", stock, price, weight);
                case "virtual":
                    return new VirtualProduct(prodName, "No Description", stock, price);
                default: throw new Exception("Invalid Type");
            }
        }

        private string ReadProductName()
        {
            Console.Write("Product name: ");
            string? productName = Console.ReadLine();
            while(string.IsNullOrEmpty(productName))
            {
                Console.WriteLine("Invalid name! Please enter a valid name!");
                Console.Write("Product Name: ");
                productName = Console.ReadLine();
            }

            return productName;
        }

        private decimal ReadPrice()
        {
            decimal value;
            Console.Write("Price: ");
            while (!decimal.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.WriteLine("Invalid Price! Please provide a positive number!");
                Console.Write("Price: ");
            }

            return value;
        }

        private int ReadInteger(string varName)
        {
            int value;
            Console.Write($"{varName}: ");
            while(!int.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.WriteLine("Invalid Value! Please provide a positive number!");
                Console.Write($"{varName}: ");
            }

            return value;
        }
    }
}
