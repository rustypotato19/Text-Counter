using System.IO;
using System;
using System.Diagnostics.Metrics;


int wordCount = 0;
int letterCount = 0;
int lowerCase = 0;
int upperCase = 0;
int other = 0;

char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
int[] alphaCount = new int[26];


try {
    StreamReader sr = new StreamReader(@"C:\Users\Konrad\source\repos\ConsoleApp2\ConsoleApp2\sampletext.txt");
    string[] words = sr.ReadToEnd().Split(" ");

    for (int i = 0; i < words.Length; i++)
    {

        wordCount++;

        //Console.WriteLine(words[i]);

        foreach (char letter in words[i])
        {
            letterCount++;

            if (Char.IsLower(letter))
            {
                lowerCase += 1;
            }
            else if (Char.IsUpper(letter))
            {
                upperCase += 1;
            }
            else if (Char.IsPunctuation(letter) || Char.IsDigit(letter))
            {
                other += 1;
            }
            
            for (int j = 0; j < alphabet.Length; j++)
            {

                char lowLetter = Char.ToLower(letter);

                if (lowLetter == alphabet[j])
                {
                    alphaCount[j] += 1;
                }
            }

        }

    }

    Console.WriteLine("Total Words: " + wordCount);
    Console.WriteLine("Total Letters: " + (lowerCase + upperCase + other));
    Console.WriteLine("Lowercase: " + lowerCase);
    Console.WriteLine("Uppercase: " + upperCase);
    Console.WriteLine("Other Characters: " + other);

    for (int i = 0;i < alphabet.Length;i++)
    {
        Console.WriteLine("Letter '" + alphabet[i] + "': " + alphaCount[i]);
    }
    

    sr.Close();
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}