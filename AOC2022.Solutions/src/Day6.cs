public class Day6
{
    public static int Part1(string inputFilePath)
    {
        var buffer = File.ReadAllLines(inputFilePath).ToList()[0];
        return RenameMe(buffer);
    }

    // public static string Part2(string inputFilePath)
    // {
    //     return "";
    // }

    public static int RenameMe(string buffer)
    {
        for (int j = 0; j < buffer.Length; j++)
        {
            var marker = new List<char>();
            var set = new HashSet<char>(){
                buffer[j + 0],
                buffer[j + 1],
                buffer[j + 2],
                buffer[j + 3],
                };

            if (set.Count() == 4) {
                return j+4;
            }
        }
        return -1;
    }
}
