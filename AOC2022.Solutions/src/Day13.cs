namespace AOC2022.Solutions;

public class Day13
{
    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);
        var rightOrderSum = 0;

        for (int x = 0; x < lines.Length; x += 3)
        {
            var pairNo = x / 3 + 1;

            var l = ParsePacket(lines[x + 0]);
            var r = ParsePacket(lines[x + 1]);

            if (RightOrder(l, r))
            {
                rightOrderSum += pairNo;
            }
        }

        return rightOrderSum;
    }

    public static int Part2(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var divider1 = ("[[2]]", ParsePacket("[[2]]"));
        var divider2 = ("[[6]]", ParsePacket("[[6]]"));

        List<(string, List<object>)> packets = new() { divider1, divider2 };

        for (int x = 0; x < lines.Length; x++)
        {
            var str = lines[x + 0];
            if (string.Empty == str)
            {
                continue;
            }

            packets.Add((str, ParsePacket(str)));
        }

        packets.Sort(new PacketComparer());

        var decoderKey = 1;
        for (var i = 0; i < packets.Count; i++)
        {
            var packet = packets[i];
            if (packet.Item1 == "[[2]]" || packet.Item1 == "[[6]]")
            {
                decoderKey *= i + 1;
            }
        }

        return decoderKey;
    }

    public static List<object> ParsePacket(string s)
    {
        List<object> first = new();
        Stack<List<object>> stack = new();
        stack.Push(first);

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c == '[')
            {
                List<object> newList = new();
                stack.Peek().Add(newList);
                stack.Push(newList);
            }
            else
            if (c == ']')
            {
                stack.Pop();
            }
            else
            if (c == ',')
            {
                continue;
            }
            else
            {
                int val = int.Parse(c.ToString());
                if (val == 1)
                {
                    if (s[i + 1] == '0')
                    {
                        val = 10;
                        i++;
                    }
                }
                stack.Peek().Add(val);
            }
        }

        return first[0] as List<object>;
    }

    public static bool RightOrder(List<object> left, List<object> right)
    {
        var res = ComparePackets(left, right);
        if (res == 0)
        {
            throw new InvalidOperationException();
        }

        return res < 0;
    }

    public static int ComparePackets(List<object> left, List<object> right)
    {
        while (left.Count > 0 && right.Count > 0)
        {
            if (left[0] is int && right[0] is int)
            {
                int elementL = (int)left[0];
                int elementR = (int)right[0];

                if (elementL < elementR)
                {
                    return -1;
                }
                else if (elementL > elementR)
                {
                    return 1;
                }
            }
            else
            if (left[0] is int && !(right[0] is int))
            {
                var res = ComparePackets(new List<object>() { (int)left[0] }, right[0] as List<object>);
                if (res != 0)
                {
                    return res;
                }
            }
            else
            if (!(left[0] is int) && right[0] is int)
            {
                var res = ComparePackets(left[0] as List<object>, new List<object>() { (int)right[0] });
                if (res != 0)
                {
                    return res;
                }
            }
            else
            {
                var listL = left[0] as List<object>;
                var listR = right[0] as List<object>;
                if (listL.Count > 0 || listR.Count > 0)
                {
                    var res = ComparePackets(listL, listR);
                    if (res != 0)
                    {
                        return res;
                    }
                }
            }

            left.RemoveAt(0);
            right.RemoveAt(0);
        }

        if (left.Count == 0 && right.Count == 0)
        {
            return 0;
        }

        if (left.Count == 0)
        {
            return -1;
        }

        return 1;
    }

    public class PacketComparer : IComparer<(string str, List<object>)>
    {
        public int Compare((string str, List<object>) packet1, (string str, List<object>) packet2)
        {
            return ComparePackets(ParsePacket(packet1.str), ParsePacket(packet2.str));
        }
    }
}
