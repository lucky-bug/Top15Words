using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Top15Words
{
    static void Main(string[] args) {
        string text = File.ReadAllText(args[0]);
        Dictionary<string, int> words = new Dictionary<string, int>();

        var pattern = new Regex(@"\w+");

        foreach(Match match in pattern.Matches(text)) {
            words[match.Value] = words.GetValueOrDefault(match.Value, 0) + 1;
        }

        foreach(KeyValuePair<string, int> kvp in words.OrderByDescending(kvp => kvp.Value).Take(15)) {
            Console.WriteLine(kvp.Key + " " + kvp.Value);
        }
    }
}
