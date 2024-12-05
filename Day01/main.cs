
public class Day01
{
    public static int PartA()
    {

        var lines = File.ReadAllLines(@"Day01\input.txt")
             .Select(l => l.Split("   "))
             .Select(parts => new { a = int.Parse(parts[0]), b = int.Parse(parts[1]) });

        return lines.OrderBy(x => x.a).Zip(lines.OrderBy(x => x.b), (a, b) =>Math.Abs(a.a-b.b)).Sum();
    }

    public static int PartB()
    {

        var lines = File.ReadAllLines(@"Day01\input.txt")
             .Select(l => l.Split("   "))
             .Select(parts => new { a = int.Parse(parts[0]), b = int.Parse(parts[1]) });

        return lines.Select(x => x.a * lines.Where(y => y.b == x.a).Count()).Sum();        
    }
}
