namespace AOC2022.Solutions;

public class Day4
{
    public class Section
    {
        int start { get; }
        int end { get; }
        public Section(string s)
        {
            start = int.Parse(s.Split('-')[0]);
            end = int.Parse(s.Split('-')[1]);
        }

        public bool FullyOverlaps(Section other)
        {
            if (start <= other.start && end >= other.end)
            {
                return true;
            }
            else if (other.start <= start && other.end >= end)
            {
                return true;
            }

            return false;
        }

        public bool Overlaps(Section other)
        {
            if (start <= other.end && end >= other.start)
            {
                return true;
            }
            return false;
        }
    }

    public static int Part1(string inputFilePath)
    {
        var fullyOverlaps = 0;

        var pairs = File.ReadLines(inputFilePath);
        foreach (var pair in pairs)
        {
            var section1 = new Section(pair.Split(',')[0]);
            var section2 = new Section(pair.Split(',')[1]);

            if (section1.FullyOverlaps(section2))
            {
                fullyOverlaps += 1;
            }
        }

        return fullyOverlaps;
    }

    public static int Part2(string inputFilePath)
    {
        var overlaps = 0;

        var pairs = File.ReadLines(inputFilePath);
        foreach (var pair in pairs)
        {
            var section1 = new Section(pair.Split(',')[0]);
            var section2 = new Section(pair.Split(',')[1]);

            if (section1.Overlaps(section2))
            {
                overlaps += 1;
            }
        }

        return overlaps;
    }
}
