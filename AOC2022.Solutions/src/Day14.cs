namespace AOC2022.Solutions;

public class Day14
{
    /*
    1) Parse scan trace
        - every line in the input file is a path
        - a path is made of multiple lines
        - stright lines only 
        - x0, y0 -> x1, y1
        -  
    2) Simulate the sand
        - sand is falling dawn from 500, 0
        - next unit of sand is produced when the current stops moving
        - Rules
            - down (y + 1)
            - (if blocked) left-down  (x-1, y+1)
            - (if blocked) right-down (x+1, y+1)
            - (if blocked) stop and create new unit of sand
    
    3) Q: how many units of sand had stopped the sand before flowing into the abyss below?
    */

    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        // process
        List<List<(int, int)>> scans = new();
        foreach (var line in lines)
        {
            var tokens = line.Split(" -> ");
            List<(int, int)> t = new();
            scans.Add(t);
            foreach (var token in tokens)
            {
                var tmp = token.Split(',');
                var origin = int.Parse(tmp[0]);
                var dir = int.Parse(tmp[1]);
                t.Add((origin, dir));
            }
        }

        var realMinX = int.MaxValue;
        var realMaxX = 0;
        var maxY = 0;

        foreach (var scan in scans)
        {
            foreach (var idk in scan)
            {
                realMinX = int.Min(realMinX, idk.Item1);
                realMaxX = int.Max(realMaxX, idk.Item1);
                maxY = int.Max(maxY, idk.Item2);
            }
        }

        var maxX = realMaxX - realMinX;
        // var minX = 0;

        var width = maxX + 1;
        var height = maxY + 1;

        List<List<char>> grid = new();
        for (int y = 0; y < height; y++)
        {
            grid.Add(new List<char>());
            for (int x = 0; x < width; x++)
            {
                grid[y].Add('.');
            }
        }


        foreach (var scan in scans)
        {
            var cursorX = scan[0].Item1 - realMinX;
            var cursorY = scan[0].Item2;

            for (var i = 1; i < scan.Count; i++)
            {
                var endCursorX = scan[i].Item1 - realMinX;
                var endCursorY = scan[i].Item2;

                var points = GetPoints(cursorX, cursorY, endCursorX, endCursorY);
                AddRocks(points, grid);

                cursorX = endCursorX;
                cursorY = endCursorY;
            }
        }

        var sandOrigin = 500 - realMinX;

        //Simulate
        var ticks = 0;
        var uos = 0;
        var overflown = false;

        while (!overflown)
        {
            var sandX = sandOrigin;
            var sandY = 0;

            var stopped = false;

            uos++;
            while (!stopped)
            {
                ticks++;

                if (WithinBounds(sandY + 1, sandX, grid))
                {
                    if (grid[sandY + 1][sandX] == '.')
                    {
                        sandY++;
                        continue;
                    }
                }
                else
                {
                    grid[sandY][sandX] = 'F';
                    overflown = true;
                    break;
                }

                if (WithinBounds(sandY + 1, sandX - 1, grid))
                {
                    if (grid[sandY + 1][sandX - 1] == '.')
                    {
                        sandY++;
                        sandX--;
                        continue;
                    }
                }
                else
                {
                    grid[sandY][sandX] = 'F';
                    overflown = true;
                    break;
                }

                if (WithinBounds(sandY + 1, sandX + 1, grid))
                {
                    if (grid[sandY + 1][sandX + 1] == '.')
                    {
                        sandY++;
                        sandX++;
                        continue;
                    }
                }
                else
                {
                    grid[sandY][sandX] = 'F';
                    overflown = true;
                    break;
                }

                stopped = true;
                grid[sandY][sandX] = 'o';
            }

        }

        return uos - 1;
    }

    public static void PrintGrid(int width, int height, List<List<char>> grid)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(grid[y][x]);
            }
            Console.Write('\n');
        }
    }

    public static List<(int, int)> GetPoints(int x1, int y1, int x2, int y2)
    {
        List<(int x, int y)> points = new List<(int x, int y)>();

        if (x1 == x2)
        {
            for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)
            {
                points.Add((x1, y));
            }
        }
        else if (y1 == y2)
        {
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
            {
                points.Add((x, y1));
            }
        }

        return points;
    }

    public static void AddRocks(List<(int x, int y)> rocks, List<List<char>> grid)
    {
        foreach (var (x, y) in rocks)
        {
            grid[y][x] = '#';
        }
    }

    public static bool WithinBounds(int y, int x, List<List<char>> grid)
    {
        return y >= 0 && y < grid.Count && x >= 0 && x < grid[0].Count;
    }
}
