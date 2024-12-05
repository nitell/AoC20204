
public class Day02
{

    static bool IsValid(IEnumerable<int> l)
    {
        return (l.SequenceEqual(l.OrderBy(o => o)) || l.SequenceEqual(l.OrderByDescending(o => o))) &&
            l.Zip(l.Skip(1), (a, b) => (Math.Abs(a - b) > 0 && Math.Abs(a - b) < 4) ? 0 : 1).Sum() == 0;
    }

    static IEnumerable<IEnumerable<int>> Permutations(IEnumerable<int> input)
    {
        return input.Select((_, index) => input.Where((_, i) => i != index));
    }

    public static int PartA()
    {

        return File.ReadAllLines(@"Day02\input.txt")
             .Select(l => l.Split(" "))
             .Select(l => l.Select(n => int.Parse(n)))
             .Where(l => IsValid(l))             
             .Count();
   }

    public static int PartB()
    {

        return File.ReadAllLines(@"Day02\input.txt")
             .Select(l => l.Split(" "))
             .Select(l => l.Select(n => int.Parse(n)))
             .Where(l => Permutations(l).Any(p=>IsValid(p)))
             .Count();
    }
}
