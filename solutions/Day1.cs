
public class Day1
{
    const string InputFilePath = "./solutions/inputs/day1";

    public static int Part1()
    {
        int maxCalories = int.MinValue;
        int currentCalories = 0;

        var lines = File.ReadAllLines(InputFilePath).ToList();
        lines.Add("");
        foreach (string line in lines)
        {
            if (line == "")
            {
                maxCalories = int.Max(maxCalories, currentCalories);
                currentCalories = 0;
            }
            else
            {
                currentCalories += int.Parse(line);
            }
        }

        return (maxCalories);
    }

    public static int Part2()
    {
        int currentCalories = 0;
        List<int> elves = new List<int>();

        var lines = File.ReadAllLines(InputFilePath).ToList();
        lines.Add("");
        foreach (string line in lines)
        {
            if (line == "")
            {
                elves.Add(currentCalories);
                currentCalories = 0;
            }
            else
            {
                currentCalories += int.Parse(line);
            }
        }

        elves.Sort();
        elves.Reverse();
        return (elves[0] + elves[1] + elves[2]);
    }
}
