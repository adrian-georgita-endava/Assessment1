using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise7
{
    public class NumberGuesser : IGuesser<int>
    {
        private int _minNumber;
        private int _maxNumber;
        private int _currentGuess;

        private Random _random;
        public int Guesses { get; private set; }

        private string[] _validResponses = ["too high", "too low", "correct"];

        public NumberGuesser(int minNumber, int maxNumber)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;
            _random = new Random();
            Guesses = 0;
        }

        int IGuesser<int>.GetGuess()
        {
            _currentGuess = _random.Next(_minNumber, _maxNumber);
            Guesses++;

            return _currentGuess;
        }

        bool IGuesser<int>.ReadUserResponse()
        {
            Console.Write("Correct/Too High/Too Low: ");
            string? userResponse = Console.ReadLine();

            while (String.IsNullOrEmpty(userResponse) || !_validResponses.Contains(userResponse.ToLower()))
            {
                Console.WriteLine("Invalid Response. Please type one of the following values: 'Correct', 'Too High', 'Too Low'");
                Console.Write("Response: ");
                userResponse = Console.ReadLine();
            }

            userResponse = userResponse.ToLower();

            switch (userResponse)
            {
                case "too high":
                    _maxNumber = _currentGuess - 1;
                    return false;
                case "too low":
                    _minNumber = _currentGuess + 1;
                    return false;
                case "correct":
                    return true;
                default:
                    return false;
            }
        }
    }
}
