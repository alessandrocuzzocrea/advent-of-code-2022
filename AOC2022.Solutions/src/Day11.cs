namespace AOC2022.Solutions;

public class Day11
{
    public class Monkey
    {
        public List<int> Items = new();
        public string Operation = "";
        public int Test = -1;
        public int TargetTrue = -1;
        public int TargetFalse = -1;
        public int InspectedTimes;

        public override string ToString()
        {
            return string.Join(',', Items);
        }

    }
    public static int Part1(string inputFilePath)
    {

        List<Monkey> monkeys = new();

        var lines = File.ReadAllLines(inputFilePath);
        for (var i = 0; i < lines.Length; i += 7)
        {
            var line = lines[i];

            Monkey m = new Monkey()
            {
                Items = Array.ConvertAll(lines[i + 1][18..].Split(','), int.Parse).ToList(),
                Operation = lines[i + 2][12..],
                Test = int.Parse(lines[i + 3][20..]),
                TargetTrue = int.Parse(lines[i + 4][28..]),
                TargetFalse = int.Parse(lines[i + 5][30..]),
            };

            monkeys.Add(m);
        }

        for (int round = 0; round < 20; round++)
        {
            foreach (Monkey currentMonkey in monkeys)
            {
                while (currentMonkey.Items.Count > 0)
                {
                    var item = currentMonkey.Items[0];
                    currentMonkey.Items.RemoveAt(0);

                    currentMonkey.InspectedTimes++;

                    switch (currentMonkey.Operation)
                    {
                        case " new = old * 17":
                            item *= 17;
                            break;
                        case " new = old + 1":
                            item += 1;
                            break;
                        case " new = old + 3":
                            item += 3;
                            break;
                        case " new = old + 5":
                            item += 5;
                            break;
                        case " new = old * old":
                            item *= item;
                            break;
                        case " new = old + 2":
                            item += 2;
                            break;
                        case " new = old + 4":
                            item += 4;
                            break;
                        case " new = old * 19":
                            item *= 19;
                            break;
                        case " new = old + 6":
                            item += 6;
                            break;
                    }

                    item /= 3;

                    if (item % currentMonkey.Test == 0)
                    {
                        monkeys[currentMonkey.TargetTrue].Items.Add(item);
                    }
                    else
                    {
                        monkeys[currentMonkey.TargetFalse].Items.Add(item);
                    }

                }
            }
        }

        monkeys.Sort((m1, m2) => m1.InspectedTimes.CompareTo(m2.InspectedTimes));
        monkeys.Reverse();

        return monkeys[0].InspectedTimes * monkeys[1].InspectedTimes;
    }

    // public static string Part2(string inputFilePath)
    // {
    // }
}
