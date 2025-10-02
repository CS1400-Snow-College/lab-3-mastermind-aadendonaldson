// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Formats.Asn1;

// Aaden Donaldson, 10/1/25, MasterMind
Console.WriteLine("Welcome kind sir, we have have a game for you. This game is made by making many loops and nesting other loops inside of them. There is also some conditional statements. We also make some characters and variables.");
Console.WriteLine("I have chosen 4 letters between 'a' and 'g'; they are also ranged in a particular order. Your job is to guess the letters and put them in the right order.");
string secretCode = "adec";
const int length = 4;
const string lettersAllowed = "abcdefg";
int timesAround = 1;

while (true)
{
    Console.WriteLine("Guess " + timesAround + ": Please, guess a sequence of 4 lowercase letters with no repeats.");
    string guess = Console.ReadLine()!;
    if (guess == null || guess.Length != length || !IsValidGuess(guess, lettersAllowed))
    {
        Console.Write("That guess does not work amigo. Remeber, it is 4 different letters between a and g.");
        continue;
    }
    if (guess == secretCode)
    {
        Console.Write("You got it!!! Hip, hip, hooray. It took you " + timesAround + " times to get it! Now get out a here");
        break;
    }

    int rightSpot = 0;
    int rightLetterWrongSpot = 0;

    bool[] secretMatch = new bool[length];
    bool[] guessedMatch = new bool[length];

    for (int i = 0; i < length; i++)
    {
        if (guess[i] == secretCode[i])
        {
            rightSpot++;
            secretMatch[i] = true;
            guessedMatch[i] = true;
        }
    }
    for (int i = 0; i < length; i++)
    {
        if (secretMatch[i]) continue;

        for (int j = 0; j < length; j++)
        {
            if (secretMatch[j]) continue;
            if (guess[i] == secretCode[j])
            {
                rightLetterWrongSpot++;
                secretMatch[j] = true;
                break;
            }
        }
    }
    Console.WriteLine($" {rightSpot} in the correct position");
    Console.WriteLine($" {rightLetterWrongSpot} is in the wrong position");
    timesAround++;
}
static bool IsValidGuess(string guess, string allowed)
{
    HashSet<char> seen = new HashSet<char>();
    foreach (char c in guess)
    {
        if (!allowed.Contains(c) || !seen.Add(c))
            return false;
    }
    return true;
}