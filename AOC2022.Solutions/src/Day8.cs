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

                //check top
                var top_visible = true;
                for (var top_y = y - 1; top_y >= 0; top_y--)
                {
                    var v = int.Parse(lines[top_y][x].ToString());
                    if (tree <= v)
                    {
                        top_visible = false;
                        continue;
                    }
                }

                //check right
                var right_visible = true;
                for (var right_x = x + 1; right_x < width; right_x++)
                {
                    var v = int.Parse(lines[y][right_x].ToString());
                    if (tree <= v)
                    {
                        right_visible = false;
                        continue;
                    }
                }

                //check down
                var down_visible = true;
                for (var down_y = y + 1; down_y < height; down_y++)
                {
                    var v = int.Parse(lines[down_y][x].ToString());
                    if (tree <= v)
                    {
                        down_visible = false;
                        continue;
                    }
                }

                //check left
                var left_visible = true;
                for (var left_x = x - 1; left_x >= 0; left_x--)
                {
                    var v = int.Parse(lines[y][left_x].ToString());
                    if (tree <= v)
                    {
                        left_visible = false;
                        continue;
                    }
                }

                if (top_visible || right_visible || down_visible || left_visible)
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
                // //check if edge
                // if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                // {
                //     visibles++;
                //     continue;
                // }

                int tree = int.Parse(lines[y][x].ToString());

                //check top
                var top_found = 0;
                for (var top_y = y - 1; top_y >= 0; top_y--)
                {
                    var v = int.Parse(lines[top_y][x].ToString());
                    top_found++;
                    if (tree <= v)
                    {
                        break;
                    }
                }

                //check right
                var right_found = 0;
                for (var right_x = x + 1; right_x < width; right_x++)
                {
                    var v = int.Parse(lines[y][right_x].ToString());
                    right_found++;
                    if (tree <= v)
                    {
                        break;
                    }
                }

                //check down
                var down_found = 0;
                for (var down_y = y + 1; down_y < height; down_y++)
                {
                    var v = int.Parse(lines[down_y][x].ToString());
                    down_found++;
                    if (tree <= v)
                    {
                        break;
                    }
                }

                //check left
                var left_found = 0;
                for (var left_x = x - 1; left_x >= 0; left_x--)
                {
                    var v = int.Parse(lines[y][left_x].ToString());
                    left_found++;
                    if (tree <= v)
                    {
                        break;
                    }
                }

                var score = top_found * left_found * right_found * down_found;

                if (score > bestScore)
                {
                    Console.WriteLine($"best: x:{x}, y:{y} - {tree}");
                }

                bestScore = int.Max(bestScore, score);
            }
        }

        return bestScore;
    }
}
