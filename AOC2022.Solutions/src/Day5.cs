using System.Text;
using System.Text.RegularExpressions;

namespace AOC2022.Solutions;

public class Day5
{
    public static string Part1(string inputFilePath)
    {
        var pairs = File.ReadLines(inputFilePath).ToArray();
        var stacks = ParseInputDrawing(pairs, out var lastLineIndex);

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
        var pairs = File.ReadLines(inputFilePath).ToArray();
        var stacks = ParseInputDrawing(pairs, out var lastLineIndex);

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

    private static List<Stack<char>> ParseInputDrawing(string[] pairs, out int lastLineIndex)
    {
        List<Stack<char>> stacks = new() { new Stack<char>() };

        lastLineIndex = 0;
        for (var i = 0; i < pairs.Length; i++)
        {
            if (pairs[i] == string.Empty)
            {
                lastLineIndex = i - 1;
                break;
            }
        }

        var r = new Regex(@"\[([A-Z])\]|(\x20{4})");

        // Prepare stacks
        var m = r.Matches(pairs[0]);
        for (var x = 0; x < m.Count; x++)
        {
            stacks.Add(new Stack<char>());
        }

        for (var y = lastLineIndex - 1; y >= 0; y--)
        {
            for (var x = 0; x < m.Count; x++)
            {
                var currM = r.Matches(pairs[y]);
                var crate = currM[x].Groups[1].Value;
                if (string.IsNullOrWhiteSpace(crate) == false)
                {
                    stacks[x + 1].Push(crate[0]);
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
        for (var i = 1; i < s.Count; i++)
        {
            sb.Append(s[i].Pop());
        }
        return sb.ToString();
    }
}
