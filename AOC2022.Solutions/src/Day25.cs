namespace AOC2022.Solutions;

public class Day25
{
    public static string Part1(string inputFilePath)
    {
        var sum = 0;

        foreach (var line in File.ReadAllLines(inputFilePath))
        {
            int result = 0;
            int placeValue = 1;
            for (int i = line.Length - 1; i >= 0; i--)
            {
                char digit = line[i];
                int value = 0;
                switch (digit)
                {
                    case '2': value = 2; break;
                    case '1': value = 1; break;
                    case '0': value = 0; break;
                    case '-': value = -1; break;
                    case '=': value = -2; break;
                }
                result += value * placeValue;
                placeValue *= 5;
            }
            sum += result;
        }

        return ToSnafu(sum);
    }

    public static string ToSnafu(int decimalNumber)
    {
        var digits = new Dictionary<int, string>
            {
                { -2, "=" },
                { -1, "-" },
                { 0, "0" },
                { 1, "1" },
                { 2, "2" }
            };
        var s = "";
        while (decimalNumber != 0)
        {
            s += digits[(decimalNumber + 2) % 5 - 2];
            decimalNumber = (decimalNumber - ((decimalNumber + 2) % 5 - 2)) / 5;
        }
        return string.Join("", s.Reverse());
    }
}
