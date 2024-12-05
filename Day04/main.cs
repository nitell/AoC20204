
using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;

public class Day04
{

    public static int PartA()
    {

        var input = File.ReadAllLines(@"Day04\input.txt").ToArray();
        var dirs = new int[] { -1, 0, 1 };
        var directions = dirs.SelectMany(x => dirs.Select(y => new { x, y })).ToArray();
        var count = 0;
        for (int x = 0; x < input[0].Length; x++)
        {
            for (int y = 0; y < input.Length; y++)
            {
                foreach (var direction in directions)
                {
                    var word = new String(Enumerable.Range(0, 4).Select(i => new { x = x + direction.x * i, y = y + direction.y*i }).Select(
                        o => (o.x >= 0 && o.x < input[0].Length && o.y >= 0 && o.y < input.Length) ? input[o.x][o.y] : '.'
                        ).ToArray());
                    if (word == "XMAS")
                        count++;

                }
            }
        }
        return count;             
    }

    public static int PartB()
    {

        var input = File.ReadAllLines(@"Day04\input.txt").ToArray();
        var dirs = new int[] { -1, 0, 1 };
        var directions = dirs.SelectMany(x => dirs.Select(y => new { x, y })).ToArray();
        var count = 0;
        for (int x = 1; x < input[0].Length-1; x++)
        {
            for (int y = 1; y < input.Length-1; y++)
            {
               if (((input[y-1][x-1] == 'M' && input[y][x] == 'A' && input[y+1][x+1] == 'S')
                    || (input[y-1][x-1] == 'S' && input[y][x] == 'A' && input[y+1][x + 1] == 'M'))
                    && ((input[y-1][x+1] == 'M' && input[y][x] == 'A' && input[y + 1][x - 1] == 'S')
                         || (input[y-1][x+1] == 'S' && input[y][x] == 'A' && input[y + 1][x - 1] == 'M')))
                    count++;
                         
            }
        }
        return count;

    }
}
