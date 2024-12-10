

using Microsoft.Win32.SafeHandles;
using System.Data.Common;
using System.Diagnostics.Metrics;
using static Day06;

public class Day06
{
    public record Pos(int Row, int Column)
    {
        public Pos Add(Heading other) => new Pos(Row + other.Row, Column + other.Column);
    }

  

    public record Heading(int Row, int Column, char Token);



    public static int PartA()
    {
                      
        var input = File.ReadAllLines(@"Day06\input.txt").Select(l => l.ToArray()).ToArray();     
        var (path, loop) = Traverse(input);
        return path.Distinct().Count();                
    }

    public static int PartB()
    {
        var input = File.ReadAllLines(@"Day06\input.txt").Select(l => l.ToArray()).ToArray();
        var path= Traverse(input).Item1.Distinct().Skip(1).ToArray();
        var loopCount = 0;

        var i = 0;
        Parallel.ForEach(path, p =>
        {
            i++;
            Console.WriteLine($"{i}/{path.Length}: {loopCount}");
            input = File.ReadAllLines(@"Day06\input.txt").Select(l => l.ToArray()).ToArray();
            input[p.Row][p.Column] = '#';
            var (_, isLoop) = Traverse(input);
            if (isLoop)
                Interlocked.Increment(ref loopCount);

        });

        return loopCount;
    }


    public static (Pos[], bool) Traverse(char[][] input)
    {
        var up = new Heading(-1, 0, 'u');
        var down = new Heading(1, 0, 'd');
        var right = new Heading(0, 1, 'r');
        var left = new Heading(0, -1, 'l');
        var directions = new[] { up, right, down, left };

        
        var pos = input.Select((l, i) => new Pos(i, Array.IndexOf(l.ToArray(), '^'))).First(p => p.Column != -1);
        Heading heading = up;
        var result = new List<(Pos, Heading)>();
        while (IsInGrid(input, pos))        
        {
            if (result.Contains((pos, heading)))
                return (result.Select(o=>o.Item1).ToArray(), true);
            
            result.Add((pos, heading));
            var nextPos = pos.Add(heading);                                            
            if (IsInGrid(input, nextPos) && input[nextPos.Row][nextPos.Column] == '#')            
            {
                heading = directions[(Array.IndexOf(directions, heading) + 1) % 4];
            }
            else
            {                                
                pos = nextPos;                
            }
        }
        return (result.Select(o => o.Item1).ToArray(), false);
    }

    private static bool IsInGrid(char[][] input, Pos pos)
    {
        return pos.Row >= 0 && pos.Row < input.Length && pos.Column >= 0 && pos.Column < input[0].Length;
    }
}