using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек. А это веселая птица синица, Которая часто ворует пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

        Dictionary<string, int> wordCount = CountWords(text);

        Console.WriteLine("Статистика по тексту:");
        DisplayStatistics(wordCount);
    }

    static Dictionary<string, int> CountWords(string text)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        // Разделить текст на слова
        string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Подсчитать количество вхождений каждого слова
        foreach (string word in words)
        {
            string cleanedWord = word.ToLower(); // Привести слово к нижнему регистру для учета регистра
            if (wordCount.ContainsKey(cleanedWord))
            {
                wordCount[cleanedWord]++;
            }
            else
            {
                wordCount[cleanedWord] = 1;
            }
        }

        return wordCount;
    }

    static void DisplayStatistics(Dictionary<string, int> wordCount)
    {
        Console.WriteLine("{0,-15} {1,-5}", "Слово", "Количество");
        Console.WriteLine("---------------------");

        foreach (var pair in wordCount.OrderByDescending(x => x.Value))
        {
            Console.WriteLine("{0,-15} {1,-5}", pair.Key, pair.Value);
        }
    }
}
