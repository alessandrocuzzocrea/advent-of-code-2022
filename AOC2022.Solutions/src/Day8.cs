namespace AOC2022.Solutions;

public class Day8
{
    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var width = lines[0].Length;
        var height = lines.Length;

        List<(int, int)> Directions = new() { (0, -1), (1, 0), (0, 1), (-1, 0) };

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

                bool[] visibleDirs = new bool[] { true, true, true, true };

                for (var i = 0; i < Directions.Count; i++)
                {
                    var currDir = Directions[i];

                    var nextX = x + currDir.Item1;
                    var nextY = y + currDir.Item2;

                    while (nextX >= 0 && nextX < width && nextY >= 0 && nextY < height)
                    {


                        var v = int.Parse(lines[nextY][nextX].ToString());
                        if (tree <= v)
                        {
                            visibleDirs[i] = false;
                            // continue;
                            break;
                        }

                        nextX += currDir.Item1;
                        nextY += currDir.Item2;
                    }
                }

                if (visibleDirs[0] || visibleDirs[1] || visibleDirs[2] || visibleDirs[3])
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
