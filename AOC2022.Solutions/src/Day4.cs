class Day4
{
    const string InputFilePath = "./inputs/day4";

    public static int Part1()
    {
        var fullyOverlaps = 0;

        var pairs = File.ReadLines(InputFilePath);
        foreach (var pair in pairs)
        {
            var section1 = pair.Split(',')[0];
            var section2 = pair.Split(',')[1];

            var section1_start = int.Parse(section1.Split('-')[0]);
            var section1_end = int.Parse(section1.Split('-')[1]);

            var section2_start = int.Parse(section2.Split('-')[0]);
            var section2_end = int.Parse(section2.Split('-')[1]);

            if (section1_start <= section2_start && section1_end >= section2_end)
            {
                fullyOverlaps += 1;
            }
            else if (section2_start <= section1_start && section2_end >= section1_end)
            {
                fullyOverlaps += 1;
            }
        }

        return fullyOverlaps;
    }

    public static int Part2()
    {
        var overlaps = 0;

        var pairs = File.ReadLines(InputFilePath);
        foreach (var pair in pairs)
        {
            var section1 = pair.Split(',')[0];
            var section2 = pair.Split(',')[1];

            var section1_start = int.Parse(section1.Split('-')[0]);
            var section1_end = int.Parse(section1.Split('-')[1]);

            var section2_start = int.Parse(section2.Split('-')[0]);
            var section2_end = int.Parse(section2.Split('-')[1]);

            if (section1_start <= section2_end && section1_end >= section2_start)
            {
                overlaps += 1;
            }
        }

        return overlaps;
    }
}
