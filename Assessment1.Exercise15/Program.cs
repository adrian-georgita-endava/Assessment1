using Assessment1.Exercise15;

Console.WriteLine("Welcome to the Stock Registration Program");

IStorageFacility storageFacility = new WarehouseFacility("Warehouse 1", 100);
List<IProduct> seedProducts = new List<IProduct>()
{
    new PhysicalProduct("Phy Prod 1", "Desc 1", 5, 10, 5),
    new PhysicalProduct("Phy Prod 2", "Desc 2", 2, 45, 10),
    new VirtualProduct("Vrt Prod 1", "Desc 3", 10, 20)
};

seedProducts[0].AddPromotion(new PercentagePromotion("Prom 1", 0.5M));

foreach (var product in seedProducts)
{
    storageFacility.AddProduct(product);
}

StorageInput input = new StorageInput(storageFacility);

string? cmd;
do
{
    try
    {
        input.PerformOperation(input.ReadOperation());
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }
    Console.Write("Continue? y/n: ");
    cmd = Console.ReadLine();
} while(cmd != "n");