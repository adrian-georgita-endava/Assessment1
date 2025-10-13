Console.WriteLine("Welcome to the Text Analyzer");

Console.Write("Please enter the text to analyze: ");
string? text = Console.ReadLine();
while(String.IsNullOrEmpty(text))
{
    Console.Write("Please enter the text to analyze: ");
    text = Console.ReadLine();
}

char[] vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

int numberOfChars = text.Length;
int numberOfWords = text.Split(' ').Length;
int numberOfVowels = 0;
int numberOfConsonants = 0;

foreach (char c in text)
{
    if (vowels.Contains(c))
    {
        numberOfVowels++;
    }
    else if (!vowels.Contains(c) && char.IsLetter(c))
    {
        numberOfConsonants++;
    }
}

Console.WriteLine($"Number of characters: {numberOfChars}");
Console.WriteLine($"Number of words: {numberOfWords}");
Console.WriteLine($"Number of vowels: {numberOfVowels}");
Console.WriteLine($"Number of consonants: {numberOfConsonants}");