class Day5
{
    const string InputFilePath = "./solutions/inputs/day5";

    public static string Part1()
    {
        var stacks = new List<Stack<char>>();
        stacks.Add(new Stack<char>());
        var lastLineIndex = 0;

        var pairs = File.ReadLines(InputFilePath).ToArray();
        for (var i = 0; i < pairs.Length; i++)
        {
            if (pairs[i] == string.Empty)
            {
                lastLineIndex = i - 1;
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
                if (crate != ' ')
                {
                    currStack.Push(crate);
                }
            }
        }

        for (var y = lastLineIndex + 2; y < pairs.Length; y++)
        {
            var ll = pairs[y].Split(" ");

            var count = int.Parse(ll[1]);
            var from = int.Parse(ll[3]);
            var to = int.Parse(ll[5]);

            for (var i = 0; i < count; i++)
            {
                var tmp = stacks[from].Pop();
                stacks[to].Push(tmp);
            }
        }

        string res = "";
        for (var i = 1; i < stacks.Count(); i++)
        {
            res = res + stacks[i].Pop();
        }
        
        return res;
    }

    public static string Part2()
    {
        var stacks = new List<Stack<char>>();
        stacks.Add(new Stack<char>());
        var lastLineIndex = 0;

        var pairs = File.ReadLines(InputFilePath).ToArray();
        for (var i = 0; i < pairs.Length; i++)
        {
            if (pairs[i] == string.Empty)
            {
                lastLineIndex = i - 1;
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
                if (crate != ' ')
                {
                    currStack.Push(crate);
                }
            }
        }

        for (var y = lastLineIndex + 2; y < pairs.Length; y++)
        {
            var ll = pairs[y].Split(" ");

            var count = int.Parse(ll[1]);
            var from = int.Parse(ll[3]);
            var to = int.Parse(ll[5]);

            var tmp2 = new List<char>();

            for (var i = 0; i < count; i++)
            {
                var tmp = stacks[from].Pop();
                tmp2.Add(tmp);
            }

            tmp2.Reverse();

            foreach (char crate in tmp2)
            {
                stacks[to].Push(crate);
            }

        }

        string res = "";
        for (var i = 1; i < stacks.Count(); i++)
        {
            res = res + stacks[i].Pop();
        }
        
        return res;
    }
}
