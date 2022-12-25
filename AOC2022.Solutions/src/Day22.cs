using System.Text.RegularExpressions;

namespace AOC2022.Solutions;

public class Day22
{
    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var longest = 0;
        foreach (var line in lines.Take(lines.Length - 1))
        {
            longest = int.Max(longest, line.Length);
        }

        List<string> paddedLines = new();
        foreach (var line in lines.Take(lines.Length - 1))
        {
            paddedLines.Add(line.PadRight(longest));
        }

        var map = paddedLines
                    .Select(line => line.ToCharArray())
                    .ToArray();

        var instructions = Regex.Split(lines.Last(), @"(?<=\d)(?=L|R)|(?<=L|R)(?=\d)")
                .Select(str => int.TryParse(str, out int num) ? (object)num : str[0])
                .ToArray();

        int currentRow = 0, currentCol = Array.IndexOf(map[0], '.'), currentFacing = 0;  // facing right

        foreach (var instruction in instructions)
        {
            if (instruction is int num)
            {
                for (int i = 0; i < num; i++)
                {
                    int nextRow = currentRow, nextCol = currentCol;
                    if (currentFacing == 0) nextCol++;  // facing right
                    else if (currentFacing == 1) nextRow++;  // facing down
                    else if (currentFacing == 2) nextCol--;  // facing left
                    else if (currentFacing == 3) nextRow--;  // facing up

                    if (nextRow < 0 || nextRow >= map.Length || nextCol < 0 || nextCol >= map[0].Length)
                    {
                        if (currentFacing == 2) nextCol = map[0].Length - 1;
                        else if (currentFacing == 3) nextRow = map.Length - 1;
                        else if (currentFacing == 0) nextCol = 0;
                        else if (currentFacing == 1) nextRow = 0;
                    }

                    if (map[nextRow][nextCol] == ' ')
                    {
                        var rock = false;

                        if (currentFacing == 0)
                        {
                            var palpableColum = nextCol;
                            while (true)
                            {
                                if (map[nextRow][palpableColum] == '.')
                                {
                                    nextCol = palpableColum;
                                    break;
                                }
                                else
                                if (map[nextRow][palpableColum] == '#')
                                {
                                    rock = true;
                                    break;
                                }
                                else
                                if (map[nextRow][palpableColum] == ' ')
                                {
                                    palpableColum++;
                                    if (palpableColum < 0 || palpableColum >= map[0].Length)
                                    {
                                        // wrap around to other side of map
                                        if (currentFacing == 2) palpableColum = map[0].Length - 1;
                                        else if (currentFacing == 0) palpableColum = 0;
                                    }
                                }
                            }
                        }
                        else if (currentFacing == 1)
                        {
                            var palpableRow = nextRow;
                            while (true)
                            {
                                if (map[palpableRow][nextCol] == '.')
                                {
                                    nextRow = palpableRow;
                                    break;
                                }
                                else
                                if (map[palpableRow][nextCol] == '#')
                                {
                                    rock = true;
                                    break;
                                }
                                else
                                if (map[palpableRow][nextCol] == ' ')
                                {
                                    palpableRow++;
                                    if (palpableRow < 0 || palpableRow >= map.Length)
                                    {
                                        if (currentFacing == 3) palpableRow = map.Length - 1;
                                        else if (currentFacing == 1) palpableRow = 0;
                                    }
                                }
                                else
                                {
                                    throw new Exception("Big problem");
                                }

                            }
                        }
                        else if (currentFacing == 2)
                        {
                            var palpableColum = nextCol;
                            while (true)
                            {
                                if (map[nextRow][palpableColum] == '.')
                                {
                                    nextCol = palpableColum;
                                    break;
                                }
                                else
                                if (map[nextRow][palpableColum] == '#')
                                {
                                    rock = true;
                                    break;
                                }
                                else
                                if (map[nextRow][palpableColum] == ' ')
                                {
                                    palpableColum--;
                                    if (palpableColum < 0 || palpableColum >= map[0].Length)
                                    {
                                        if (currentFacing == 2) palpableColum = map[0].Length - 1;
                                        else if (currentFacing == 0) palpableColum = 0;
                                    }
                                }
                                else
                                {
                                    throw new Exception("Big problem");
                                }

                            }
                        }
                        else if (currentFacing == 3)
                        {

                            var palpableRow = nextRow;
                            while (true)
                            {
                                if (map[palpableRow][nextCol] == '.')
                                {
                                    nextRow = palpableRow;
                                    break;
                                }
                                else
                                if (map[palpableRow][nextCol] == '#')
                                {
                                    rock = true;
                                    break;
                                }
                                else
                                if (map[palpableRow][nextCol] == ' ')
                                {
                                    palpableRow--;
                                    if (palpableRow < 0 || palpableRow >= map.Length)
                                    {
                                        if (currentFacing == 3) palpableRow = map.Length - 1;
                                        else if (currentFacing == 1) palpableRow = 0;
                                    }
                                }
                                else
                                {
                                    throw new Exception("Big problem");
                                }
                            }
                        }

                        if (rock)
                        {
                            break;
                        }
                    }
                    else
                    if (nextRow < 0 || nextRow >= map.Length || nextCol < 0 || nextCol >= map[0].Length)
                    {
                    }
                    else
                    if (map[nextRow][nextCol] == '#')
                    {
                        break;
                    }

                    currentRow = nextRow;
                    currentCol = nextCol;
                }
            }
            else
            {
                if ((char)instruction == 'L') currentFacing = (currentFacing - 1 + 4) % 4;
                else currentFacing = (currentFacing + 1) % 4;
            }
        }

        return 1000 * (currentRow + 1) + 4 * (currentCol + 1) + currentFacing;
    }
}
