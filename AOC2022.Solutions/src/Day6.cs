namespace AOC2022.Solutions;

public class Day6
{
    public static int Part1(string inputFilePath)
    {
        var buffer = File.ReadAllLines(inputFilePath).ToList()[0];
        return DetectMarker(buffer, 4);
    }

    public static int Part2(string inputFilePath)
    {
        var buffer = File.ReadAllLines(inputFilePath).ToList()[0];
        return DetectMarker(buffer, 14);
    }

    public static int DetectMarker(string buffer, int lookAhead)
    {
        for (int j = 0; j < buffer.Length; j++)
        {
            var marker = new List<char>();

            var set = new HashSet<char>();
            for (int x = 0; x < lookAhead; x++)
            {
                set.Add(buffer[j + x]);
            }

            if (set.Count() == lookAhead)
            {
                return j + lookAhead;
            }
        }
        return -1;
    }
}
