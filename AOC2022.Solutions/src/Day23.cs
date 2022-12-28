using System.Text.RegularExpressions;

namespace AOC2022.Solutions;

public class Day23
{
    public enum Directions
    { North, South, West, East }
    public static int Part1(string inputFilePath)
    {
        return Solve(inputFilePath, 10);
    }

    public static int Part2(string inputFilePath)
    {
        return Solve2(inputFilePath, int.MaxValue);
    }

    public static int Solve(string inputFilePath, int rounds)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var elves = new Dictionary<int, (int x, int y)>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var character = line[x];
                if (character == '#')
                {
                    elves.Add(elves.Count, (x, y));
                }
            }
        }

        Console.WriteLine($"--- Initial State ---");
        Print(elves);
        Console.WriteLine();

        var proposedDirection = 0;
        for (var currentRound = 1; currentRound <= rounds; currentRound++)
        {
            // considering where to move
            var possibleMoves = GetPossibleMoves(elves, proposedDirection);

            // actually moving
            foreach (var move in possibleMoves)
            {
                if (move.Value.Count == 1)
                {
                    elves[move.Value[0]] = move.Key;
                }
            }

            proposedDirection = (proposedDirection + 1) % 4;
            Console.WriteLine($"--- Round: {currentRound} ---");
            Print(elves);
            Console.WriteLine();
        }

        var area = GetRectangleArea(elves);

        var solution = area - elves.Count;
        return solution;
    }

    public static int Solve2(string inputFilePath, int rounds)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var elves = new Dictionary<int, (int x, int y)>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var character = line[x];
                if (character == '#')
                {
                    elves.Add(elves.Count, (x, y));
                }
            }
        }

        Console.WriteLine($"--- Initial State ---");
        Print(elves);
        Console.WriteLine();

        var proposedDirection = 0;
        for (var currentRound = 1; currentRound <= rounds; currentRound++)
        {
            // considering where to move
            var possibleMoves = GetPossibleMoves(elves, proposedDirection);

            if (possibleMoves.Count > 0)
            {
                // actually moving
                foreach (var move in possibleMoves)
                {
                    if (move.Value.Count == 1)
                    {
                        elves[move.Value[0]] = move.Key;
                    }
                }
            }
            else
            {
                return currentRound;
            }

            proposedDirection = (proposedDirection + 1) % 4;
            Console.WriteLine($"--- Round: {currentRound} ---");
            Print(elves);
            Console.WriteLine();
        }

        return -1;
    }

    public static int GetRectangleArea(Dictionary<int, (int x, int y)> elves)
    {
        var minX = int.MaxValue;
        var maxX = int.MinValue;

        var minY = int.MaxValue;
        var maxY = int.MinValue;

        foreach (var elf in elves)
        {
            minX = Math.Min(minX, elf.Value.x);
            maxX = Math.Max(maxX, elf.Value.x);

            minY = Math.Min(minY, elf.Value.y);
            maxY = Math.Max(maxY, elf.Value.y);
        }

        return Math.Abs(maxX + 1 - minX) * Math.Abs(maxY + 1 - minY);
    }

    public static Dictionary<(int x, int y), List<int>> GetPossibleMoves(Dictionary<int, (int x, int y)> elves, int proposedDirection)
    {

        var directions = new (int x, int y)[] { (0, -1), (0, 1), (-1, 0), (1, 0) };

        var possibleMoves = new Dictionary<(int x, int y), List<int>>();

        foreach (var elf in elves)
        {
            var elfProposedDirection = proposedDirection;
            var adj = AdjacentElfPresent(elves, elf.Value.x, elf.Value.y);
            if (adj[0] || adj[1] || adj[2] || adj[3])
            {
                (int x, int y) move;

                for (var dir = 0; dir < 4; dir++)
                {
                    if (adj[elfProposedDirection] == false)
                    {
                        move = (elf.Value.x + directions[elfProposedDirection].x, elf.Value.y + directions[elfProposedDirection].y);

                        if (!possibleMoves.ContainsKey(move))
                        {
                            possibleMoves[move] = new List<int>();
                        }
                        possibleMoves[move].Add(elf.Key);

                        break;
                    }
                    else
                    {
                        elfProposedDirection = (elfProposedDirection + 1) % 4;
                    }
                }
            }
            else
            {
                //Do nothing;
            };
        }

        return possibleMoves;
    }

    public static bool[] AdjacentElfPresent(Dictionary<int, (int x, int y)> elves, int x, int y)
    {
        bool n = false;
        bool s = false;
        bool w = false;
        bool e = false;

        if (elves.ContainsValue((x - 1, y - 1))) { n = true; }
        if (elves.ContainsValue((x, y - 1))) { n = true; }
        if (elves.ContainsValue((x + 1, y - 1))) { n = true; }

        if (elves.ContainsValue((x + 1, y + 1))) { s = true; }// SE
        if (elves.ContainsValue((x, y + 1))) { s = true; } // S
        if (elves.ContainsValue((x - 1, y + 1))) { s = true; }// SW

        if (elves.ContainsValue((x - 1, y + 1))) { w = true; }// SW
        if (elves.ContainsValue((x - 1, y))) { w = true; }// W
        if (elves.ContainsValue((x - 1, y - 1))) { w = true; }// NW

        if (elves.ContainsValue((x + 1, y - 1))) { e = true; }  // NE
        if (elves.ContainsValue((x + 1, y))) { e = true; } // E
        if (elves.ContainsValue((x + 1, y + 1))) { e = true; } // SE

        return new bool[] { n, s, w, e };
    }

    public static void Print(Dictionary<int, (int x, int y)> elves)
    {
        var minX = int.MaxValue;
        var maxX = int.MinValue;

        var minY = int.MaxValue;
        var maxY = int.MinValue;

        foreach (var elf in elves)
        {
            minX = Math.Min(minX, elf.Value.x);
            maxX = Math.Max(maxX, elf.Value.x);

            minY = Math.Min(minY, elf.Value.y);
            maxY = Math.Max(maxY, elf.Value.y);
        }

        for (int y = minY - 1; y <= maxY + 1; y++)
        {
            for (int x = minX - 1; x <= maxX + 1; x++)
            {
                if (elves.ContainsValue((x, y)))
                {
                    Console.Write('#');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}
