
using System.Text.RegularExpressions;

public class Day03
{
    public static int PartA()
    {

        return Regex.Matches(File.ReadAllText(@"Day03\input.txt"), @"mul\((-?\d+),(-?\d+)\)").Select(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)).Sum();
    }

    public static int PartB()
    {

        var retVal = 0;
        var enabled = true;
        var text = File.ReadAllText(@"Day03\input.txt");
        for (int i = 0; i < text.Length; i++)
        {
            if (i < text.Length -7 && text.Substring(i, 7) == "don't()")
                enabled = false;
            else if (i < text.Length - 4 && text.Substring(i, 4) == "do()")
                enabled = true;

            if (enabled)
            {
                var match = Regex.Match(text.Substring(i), @"^mul\((-?\d+),(-?\d+)\)");
                if (match.Success)
                    retVal += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }
        }
        return retVal;
    }
}
