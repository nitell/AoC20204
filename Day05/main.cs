
using System.Text.RegularExpressions;

public class Day05
{

    class MyComparer(IEnumerable<string[]> rules) : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            foreach (var rule in rules)
            {
                if (rule[0] == x && rule[1] == y)
                    return -1;
                if (rule[0] == y && rule[1] == x)
                    return 1;                
            }
            return 0;
        }
    }    

    public static int PartA()
    {

        var input = File.ReadAllLines(@"Day05\input.txt").ToArray();        
        var breakIndex = Array.IndexOf(input, String.Empty);
        var rules = input.Take(breakIndex).Select(l => l.Split("|")).ToArray();
        var pagesToPrint = input.Skip(breakIndex+1).Select(l=>l.Split(",")).ToArray();

        var correct = pagesToPrint.Where(p => p.SequenceEqual(p.OrderBy(o=>o,new MyComparer(rules))));
        return correct.Sum(o => int.Parse(o[o.Length / 2]));        
    }

    public static int PartB()
    {

        var input = File.ReadAllLines(@"Day05\input.txt").ToArray();
        var breakIndex = Array.IndexOf(input, String.Empty);
        var rules = input.Take(breakIndex).Select(l => l.Split("|")).ToArray();
        var pagesToPrint = input.Skip(breakIndex + 1).Select(l => l.Split(",")).ToArray();

        var inCorrect = pagesToPrint.Where(p => !p.SequenceEqual(p.OrderBy(o => o, new MyComparer(rules))));
        //Sort them... again
        var sortedIncorrects = inCorrect.Select(o => o.OrderBy(o => o, new MyComparer(rules)).ToArray());
        return sortedIncorrects.Sum(o => int.Parse(o[o.Length / 2]));
    }
}
