using System.Diagnostics;

namespace AOC2022.Solutions;

class Day2
{
    const string InputFilePath = "./inputs/day2";

    static readonly string[] Win = new string[3] { "A Y", "B Z", "C X" };
    static readonly string[] Draw = new string[3] { "A X", "B Y", "C Z" };
    static readonly string[] Lose = new string[3] { "A Z", "B X", "C Y" };

    const int WinPoints = 6;
    const int DrawPoints = 3;
    const int LosePoints = 0;

    public static int Part1()
    {
        var fightPoints = new Dictionary<string, int> {
            {"A X", 3}
        };

        var points = new Dictionary<string, int> {
            {"X", 1},
            {"Y", 2},
            {"Z", 3}
        };

        var score = 0;

        var rounds = File.ReadLines(InputFilePath);
        foreach (var round in rounds)
        {
            var roundSplit = round.Split(' ');
            var opponent = roundSplit[0];
            var you = roundSplit[1];

            if (Day2.Win.Contains(round))
            {
                score += WinPoints;
            }
            else if (Day2.Draw.Contains(round))
            {
                score += DrawPoints;
            } else {
                score += LosePoints;
            }

            score += points[you];
        }

        Debug.Assert(score == 11873);
        return score;
    }

    public static int Part2()
    {
        var points = new Dictionary<string, int> {
            {"X", 1},
            {"Y", 2},
            {"Z", 3}
        };

        var score = 0;
        string[] a;

        var rounds = File.ReadLines(InputFilePath);
        foreach (var round in rounds)
        {
            var roundSplit = round.Split(' ');
            var opponent = roundSplit[0];
            var you = roundSplit[1];

            if (you == "X")
            {
                a = Day2.Lose;
                score += LosePoints;
            }
            else if (you == "Y")
            {
                a = Day2.Draw;
                score += DrawPoints;
            }
            else
            {
                a = Day2.Win;
                score += WinPoints;
            }

            foreach (var combo in a)
            {
                if (combo.StartsWith(opponent))
                {
                    you = combo.Split(" ")[1];
                }
            }

            score += points[you];
        }

        Debug.Assert(score == 12014);
        return score;
    }
}
