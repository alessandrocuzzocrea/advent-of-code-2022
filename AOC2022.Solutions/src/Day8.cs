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

        List<(int, int)> Directions = new() { (0, -1), (1, 0), (0, 1), (-1, 0) };

        var bestScore = 0;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                int tree = int.Parse(lines[y][x].ToString());

                int[] founds = new int[4];

                for (var i = 0; i < Directions.Count; i++)
                {
                    var currDir = Directions[i];

                    var nextX = x + currDir.Item1;
                    var nextY = y + currDir.Item2;

                    while (nextX >= 0 && nextX < width && nextY >= 0 && nextY < height)
                    {
                        var v = int.Parse(lines[nextY][nextX].ToString());
                        founds[i] += 1;
                        if (tree <= v)
                        {
                            break;
                        }

                        nextX += currDir.Item1;
                        nextY += currDir.Item2;
                    }
                }

                bestScore = int.Max(bestScore, founds[0] * founds[1] * founds[2] * founds[3]);
            }
        }

        return bestScore;
    }
}
