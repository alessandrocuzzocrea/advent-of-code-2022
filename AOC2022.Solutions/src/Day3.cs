public class Day3
{
    public static int Part1(string inputFilePath)
    {
        var prioritySum = 0;

        var rucksacks = File.ReadLines(inputFilePath);
        foreach (var rucksack in rucksacks)
        {
            var comp1 = rucksack.Substring(0, (int)rucksack.Length / 2).ToCharArray();
            var comp2 = rucksack.Substring((int)rucksack.Length / 2, (int)rucksack.Length / 2).ToCharArray();

            var comp1Set = new HashSet<char>(comp1);
            var comp2Set = new HashSet<char>(comp2);

            var overlap = comp1Set.Intersect(comp2Set);

            foreach (var tool in overlap)
            {
                var ascii = (int) tool;
                if (Char.IsLower(tool)) {
                    ascii -= 96;
                } else {
                    ascii -= (64 - 26);
                }

                // Console.WriteLine($"{tool}: {ascii}");
                prioritySum += ascii;
            }
        }

        return prioritySum;
    }

    public static int Part2(string inputFilePath) {
        var prioritySum = 0;

        var rucksacks = File.ReadLines(inputFilePath).ToArray();
        for (var i = 0; i < rucksacks.Length; i += 3)
        {
            var ruck1 = rucksacks[i];
            var ruck2 = rucksacks[i+1];
            var ruck3 = rucksacks[i+2];

            var ruck1Set = new HashSet<char>(ruck1);
            var ruck2Set = new HashSet<char>(ruck2);
            var ruck3Set = new HashSet<char>(ruck3);

            var overlap = ruck1Set.Intersect(ruck2Set).Intersect(ruck3Set);

            foreach (var tool in overlap)
            {
                var ascii = (int) tool;
                if (Char.IsLower(tool)) {
                    ascii -= 96;
                } else {
                    ascii -= (64 - 26);
                }

                // Console.WriteLine($"{tool}: {ascii}");
                prioritySum += ascii;
            }
        }

        return prioritySum;
    }
}
