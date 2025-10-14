Console.WriteLine("Welcome to the Number Guesser");

Console.WriteLine("Think of a number between 0 and 1,000,000");

const int MAX_NUMBER = 1_000_000;

Random random = new Random();

int guesses = 0;
int guess;

string? userResponse = String.Empty;

string[] validResponses = ["too high", "too low", "correct"];

int minNumber = 0;
int maxNumber = MAX_NUMBER;

do
{
    guess = random.Next(minNumber, maxNumber);
    guesses++;

    Console.WriteLine($"Is your number: {guess}?");
    Console.Write("Correct/Too High/Too Low: ");
    userResponse = Console.ReadLine();
    
    while(String.IsNullOrEmpty(userResponse) || !validResponses.Contains(userResponse.ToLower()))
    {
        Console.WriteLine("Invalid Response. Please type one of the following values: 'Correct', 'Too High', 'Too Low'");
        Console.Write("Response: ");
        userResponse = Console.ReadLine();
    }

    userResponse = userResponse.ToLower();
    switch (userResponse)
    {
        case "too high":
            maxNumber = guess - 1;
            break;
        case "too low":
            minNumber = guess + 1;
            break;
        default:
            break;
    }


} while(userResponse !=  "correct");

Console.WriteLine($"The computer has guessed your number in: {guesses} guessses");