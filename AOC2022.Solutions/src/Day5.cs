using System.Text;

public class Day5
{
    public static string Part1(string inputFilePath)
    {
        int lastLineIndex;
        var pairs = File.ReadLines(inputFilePath).ToArray();
        var stacks = ParseInputDrawing(inputFilePath, pairs, out lastLineIndex);

        for (var j = lastLineIndex + 2; j < pairs.Length; j++)
        {
            var (count, from, to) = ParseStep(pairs[j]);

            for (var i = 0; i < count; i++)
            {
                var crate = stacks[from].Pop();
                stacks[to].Push(crate);
            }
        }

        return StackToResult(stacks);
    }

    public static string Part2(string inputFilePath)
    {
        int lastLineIndex;
        var pairs = File.ReadLines(inputFilePath).ToArray();
        var stacks = ParseInputDrawing(inputFilePath, pairs, out lastLineIndex);

        for (var j = lastLineIndex + 2; j < pairs.Length; j++)
        {
            var tmp = new List<char>();

            var (count, from, to) = ParseStep(pairs[j]);
            for (var i = 0; i < count; i++)
            {
                var crate = stacks[from].Pop();
                tmp.Add(crate);
            }

            tmp.Reverse();

            foreach (char crate in tmp)
            {
                stacks[to].Push(crate);
            }

        }

        return StackToResult(stacks);
    }

    private static List<Stack<char>> ParseInputDrawing(string inputFilePath, string[] pairs, out int lastLineIndex)
    {
        List<Stack<char>> stacks = new List<Stack<char>>();
        stacks.Add(new Stack<char>());
        lastLineIndex = 0;
        for (var i = 0; i < pairs.Length; i++)
        {
            if (pairs[i] == string.Empty)
            {
                lastLineIndex = i - 1;
                break;
            }
        }

        for (var y = 1; y < pairs[lastLineIndex].Length; y += 4)
        {
            var f = pairs[lastLineIndex];
            var currStack = new Stack<char>();
            stacks.Add(currStack);
            var stackNo = int.Parse(f[y].ToString());

            for (var i = lastLineIndex - 1; i >= 0; i--)
            {
                var line = pairs[i];
                var crate = line[y];
                if (char.IsWhiteSpace(crate) == false)
                {
                    currStack.Push(crate);
                }
            }
        }
        return stacks;
    }

    private static (int count, int from, int to) ParseStep(string s)
    {
        var ll = s.Split(' ');
        return (count: int.Parse(ll[1]), from: int.Parse(ll[3]), to: int.Parse(ll[5]));
    }

    private static string StackToResult(List<Stack<char>> s)
    {
        StringBuilder sb = new StringBuilder();
        for (var i = 1; i < s.Count(); i++)
        {
            sb.Append(s[i].Pop());
        }
        return sb.ToString();
    }
}
