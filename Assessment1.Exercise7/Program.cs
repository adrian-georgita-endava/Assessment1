Console.WriteLine("Welcome to the Number Guesser");

Random random = new Random();
int number = random.Next(0, 1000);

int guess = -1;
int guesses = 0;
Console.WriteLine("Guess the random number");
Console.Write("Please enter your guess (0 - 1000): ");
while(guess != number)
{
    Console.Write("Please enter your guess (0 - 1000): ");
    while (!int.TryParse(Console.ReadLine(), out guess) || guess < 0 || guess > 1000) {
        Console.WriteLine("Invalid number");
        Console.Write("Please enter a valid positive number for your guess: ");
    }

    guesses++;
    if(guess > number)
    {
        Console.WriteLine("Too high");
    }
    else if(guess < number)
    {
        Console.WriteLine("Too low");
    }
    else
    {
        Console.WriteLine("Correct!");
    }
}

Console.WriteLine($"You have guessesed the number in: {guesses} guessses");