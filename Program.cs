using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace Palindrom;

class Program {
    static void Main(string[] args) {
        // Vstupní info
        Console.WriteLine("V této aplikaci lze zadávat věty, které jsou ověřený jestli jsou palindromy");
        
        // Hlavní loop aplikace, kde probíha všechna logika
        while (true) {
            Console.Write("\nZadejte slovo nebo větu: ");
            
            string input = Console.ReadLine() ?? ""; // Získá napsaný řádek, pojistí proti null hodnotám
            string formated = Regex.Replace(input.Normalize(NormalizationForm.FormD), @"[^\p{L}0-9]", "").ToLower(); // Pužijeme regex pro zachování jen písmen a čísel a vše dame lower

            // Tady je pouze už jen vizuální stranka outputu
            if (IsPalindromeShort(formated)) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t=> Text \"{input}\" je palindrom");
                Console.ResetColor();
                
                continue;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\t=> Text \"{input}\" není palindrom");
            Console.ResetColor();
        }
    }

    static bool IsPalindromeShort(string input)
    {
        return input.SequenceEqual(input.Reverse());
    }
    
    // Metoda pro zjištění zda se jedná o palindrome
    static bool IsPalindrome(string input) {
        int length = input.Length;
        
        // Projedem první půlku textu a porovná jej z druhou
        for (int i = 0; i < length / 2; i++) {
            // Jestli že písmena sedí pokračujeme dál, jestliže ne tak se nejdná o palindrome
            if (input[i] == input[length - i - 1]) {
                continue;
            }
            
            return false;
        }
        
        return true;
    }
}