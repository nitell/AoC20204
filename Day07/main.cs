using System.Data;

public class Day07
{
    public static long PartA() => File.ReadAllLines(@"Day07\input.txt").Sum(l => Solve(l, false));

    public static long PartB() => File.ReadAllLines(@"Day07\input.txt").Sum(l => Solve(l, true));

    private static long Solve(string l, bool allowConcat)
    {
        var target = long.Parse(l.Split(":")[0]);
        var numbers = l.Split(": ")[1].Split(" ").Select(long.Parse).ToArray();
        var chars = allowConcat ? new[] { '+', '*', '|' } : new[] { '+', '*' };

        var permutations = Enumerable.Repeat(chars, numbers.Length - 1)
            .Aggregate(new[] { "" }, (acc, next) => acc.SelectMany(s => next, (s, c) => s + c).ToArray());

        return permutations
            .Select(permutation => Evaluate(numbers, permutation))
            .FirstOrDefault(res => res == target);
    }

    private static long Evaluate(long[] numbers, string permutation)
    {
        var res = numbers[0];
        for (int i = 0; i < permutation.Length; i++)
            res = permutation[i] switch
            {
                '+' => res + numbers[i + 1],
                '*' => res * numbers[i + 1],
                '|' => long.Parse($"{res}{numbers[i + 1]}"),
                _ => res
            };
        return res;
    }
}
