namespace AOC2022.Solutions;

public class Day3
{
    public static int Part1(string inputFilePath)
    {
        var prioritiesSum = 0;

        var rucksacks = File.ReadLines(inputFilePath);
        foreach (var rucksack in rucksacks)
        {
            var compartments = SplitStringInHalf(rucksack);
            var set1 = new HashSet<char>(compartments.Item1);
            var set2 = new HashSet<char>(compartments.Item2);

            var overlap = set1.Intersect(set2);

            foreach (var tool in overlap)
            {
                prioritiesSum += CalcPriority(tool);
            }
        }

        return prioritiesSum;
    }

    public static int Part2(string inputFilePath)
    {
        var prioritiesSum = 0;

        var rucksacks = File.ReadLines(inputFilePath).ToArray();
        for (var i = 0; i < rucksacks.Length; i += 3)
        {
            var set1 = new HashSet<char>(rucksacks[i]);
            var set2 = new HashSet<char>(rucksacks[i + 1]);
            var set3 = new HashSet<char>(rucksacks[i + 2]);

            var overlap = set1.Intersect(set2).Intersect(set3);

            foreach (var tool in overlap)
            {
                prioritiesSum += CalcPriority(tool);
            }
        }

        return prioritiesSum;
    }

    static (char[], char[]) SplitStringInHalf(string s)
    {
        var comp1 = s.Substring(0, (int)s.Length / 2).ToCharArray();
        var comp2 = s.Substring((int)s.Length / 2, (int)s.Length / 2).ToCharArray();

        return (comp1, comp2);
    }

    static int CalcPriority(char tool)
    {
        var ascii = (int)tool;
        if (Char.IsLower(tool))
        {
            ascii -= 96;
        }
        else
        {
            ascii -= (64 - 26);
        }
        return ascii;
    }
}
