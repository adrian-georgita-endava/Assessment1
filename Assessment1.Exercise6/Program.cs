using Assessment1.Exercise6;

Console.WriteLine("Welcome to the Multiplications Table");

int number;

Console.Write("Please enter a number: ");
while(!int.TryParse(Console.ReadLine(), out number) || number <= 0)
{
    Console.WriteLine("Invalid Number!");
    Console.Write("Please enter a valid positive number: ");
}

Console.WriteLine($"Mutliplications Table for X = {number}");
IMatrixOperationTable matrixMultiplicaitonTable = new MatrixMultiplicationTable();
matrixMultiplicaitonTable.Generate(number);
matrixMultiplicaitonTable.Show();
