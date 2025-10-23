using Assessment1.Exercise10;

Console.WriteLine("Welcome to the Text Analyzer");

Console.Write("Please enter the text to analyze: ");
string? text = Console.ReadLine();
while(String.IsNullOrEmpty(text))
{
    Console.Write("Please enter the text to analyze: ");
    text = Console.ReadLine();
}

ITextAnalyzer romanianTextAnalyzer = new RomanianTextAnalyzer();

Console.WriteLine($"Number of characters: {romanianTextAnalyzer.GetCharactersCount(text)}");
Console.WriteLine($"Number of words: {romanianTextAnalyzer.GetWordsCount(text)}");
Console.WriteLine($"Number of vowels: {romanianTextAnalyzer.GetVowelsCount(text)}");
Console.WriteLine($"Number of consonants: {romanianTextAnalyzer.GetConsonantsCount(text)}");