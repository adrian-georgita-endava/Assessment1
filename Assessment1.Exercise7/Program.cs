using Assessment1.Exercise7;

Console.WriteLine("Welcome to the Number Guesser");

Console.WriteLine("Think of a number between 0 and 1,000,000");

IGuesser<int> numberGuesser = new NumberGuesser(0, 1_000_000);

int currentGuess;

do
{
    currentGuess = numberGuesser.GetGuess();
    Console.WriteLine($"Is your number: {currentGuess}?");
} while(!numberGuesser.ReadUserResponse());

Console.WriteLine($"The computer has guessed your number in: {numberGuesser.Guesses} guessses");
