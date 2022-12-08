namespace AOC2022.Solutions;

public class Day8
{
    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var width = lines[0].Length;
        var height = lines.Length;

        int visibles = 0;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                //check if edge
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    visibles++;
                    continue;
                }

                int tree = int.Parse(lines[y][x].ToString());

                //check up
                var visibleUp = true;
                for (var yUp = y - 1; yUp >= 0; yUp--)
                {
                    var v = int.Parse(lines[yUp][x].ToString());
                    if (tree <= v)
                    {
                        visibleUp = false;
                        continue;
                    }
                }

                //check right
                var visibleRight = true;
                for (var xRight = x + 1; xRight < width; xRight++)
                {
                    var v = int.Parse(lines[y][xRight].ToString());
                    if (tree <= v)
                    {
                        visibleRight = false;
                        continue;
                    }
                }

                //check down
                var visibleDown = true;
                for (var yDown = y + 1; yDown < height; yDown++)
                {
                    var v = int.Parse(lines[yDown][x].ToString());
                    if (tree <= v)
                    {
                        visibleDown = false;
                        continue;
                    }
                }

                //check left
                var visibleLeft = true;
                for (var xLeft = x - 1; xLeft >= 0; xLeft--)
                {
                    var v = int.Parse(lines[y][xLeft].ToString());
                    if (tree <= v)
                    {
                        visibleLeft = false;
                        continue;
                    }
                }

                if (visibleUp || visibleRight || visibleDown || visibleLeft)
                {
                    visibles++;
                }

            }
        }

        return visibles;
    }

    public static int Part2(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var width = lines[0].Length;
        var height = lines.Length;

        var bestScore = 0;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                int tree = int.Parse(lines[y][x].ToString());

                //check up
                var foundUp = 0;
                for (var yUp = y - 1; yUp >= 0; yUp--)
                {
                    var v = int.Parse(lines[yUp][x].ToString());
                    foundUp++;
                    if (tree <= v)
                    {
                        break;
                    }
                }

                //check right
                var foundRight = 0;
                for (var xRight = x + 1; xRight < width; xRight++)
                {
                    var v = int.Parse(lines[y][xRight].ToString());
                    foundRight++;
                    if (tree <= v)
                    {
                        break;
                    }
                }

                //check down
                var foundDown = 0;
                for (var yDown = y + 1; yDown < height; yDown++)
                {
                    var v = int.Parse(lines[yDown][x].ToString());
                    foundDown++;
                    if (tree <= v)
                    {
                        break;
                    }
                }

                //check left
                var foundLeft = 0;
                for (var left_x = x - 1; left_x >= 0; left_x--)
                {
                    var v = int.Parse(lines[y][left_x].ToString());
                    foundLeft++;
                    if (tree <= v)
                    {
                        break;
                    }
                }

                bestScore = int.Max(bestScore, foundUp * foundRight * foundDown * foundLeft);
            }
        }

        return bestScore;
    }
}
