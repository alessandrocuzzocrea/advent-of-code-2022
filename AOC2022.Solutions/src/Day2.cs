namespace AOC2022.Solutions;

public class Day2
{
    static readonly string[] Win = new string[3] { "A Y", "B Z", "C X" };
    static readonly string[] Draw = new string[3] { "A X", "B Y", "C Z" };
    static readonly string[] Lose = new string[3] { "A Z", "B X", "C Y" };

    const int WinPoints = 6;
    const int DrawPoints = 3;
    const int LosePoints = 0;

    static readonly Dictionary<string, int> shapePoints = new()
    {
            {"X", 1},
            {"Y", 2},
            {"Z", 3}
    };

    public static int Part1(string inputFilePath)
    {
        var score = 0;

        var rounds = File.ReadLines(inputFilePath);
        foreach (var round in rounds)
        {
            var shape = round.Split(' ')[1];
            score += CalcOutcomePoints(round) + shapePoints[shape];
        }

        return score;
    }

    public static int Part2(string inputFilePath)
    {
        var score = 0;
        string[] strategy;

        var rounds = File.ReadLines(inputFilePath);
        foreach (var round in rounds)
        {
            var roundSplit = round.Split(' ');
            var opponent = roundSplit[0];
            var you = roundSplit[1];

            if (you == "Z")
            {
                strategy = Win;
                score += WinPoints;
            }
            else if (you == "Y")
            {
                strategy = Draw;
                score += DrawPoints;
            }
            else
            {
                strategy = Lose;
            }

            foreach (var combo in strategy)
            {
                if (combo.StartsWith(opponent))
                {
                    you = combo.Split(" ")[1];
                }
            }

            score += shapePoints[you];
        }

        return score;
    }

    static int CalcOutcomePoints(string round)
    {
        if (Win.Contains(round))
        {
            return WinPoints;
        }
        else if (Draw.Contains(round))
        {
            return DrawPoints;
        }
        else
        {
            return LosePoints;
        }
    }
}
