class Day2
{

    const string InputFilePath = "./solutions/inputs/day2";

    public static void Part1()
    {

        //Rock    -> A, X
        //Paper   -> B, Y
        //Scissor -> C, Z

        // WIN
        // A Y
        // B Z
        // C X

        string[] win = new string[3] { "A Y", "B Z", "C X" };

        // Draw
        // A X
        // B Y
        // C Z

        string[] draw = new string[3] { "A X", "B Y", "C Z" };

        // Lose
        // A Z
        // B X
        // C Y

        string[] lose = new string[3] { "A Z", "B X", "C Y" };

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

            if (win.Contains(round))
            {
                score += 6;
            }
            else if (draw.Contains(round))
            {
                score += 3;
            }
            score += points[you];
        }

        Console.WriteLine(score);

    }

    public static void Part2()
    {
        string[] win = new string[3] { "A Y", "B Z", "C X" };
        string[] draw = new string[3] { "A X", "B Y", "C Z" };
        string[] lose = new string[3] { "A Z", "B X", "C Y" };

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
            // var you = "";

            if (you == "X") // Lose
            {
                a = lose;
                score += 0;
            }
            else if (you == "Y")
            {
                a = draw;
                score += 3;
            }
            else
            { // WIN
                a = win;
                score += 6;

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
        Console.WriteLine(score);
    }
}