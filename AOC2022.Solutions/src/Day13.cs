namespace AOC2022.Solutions;

public class Day13
{
    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);
        var rightOrderSum = 0;

        for (int x = 0; x < lines.Length; x += 3)
        {
            var pair = x / 3 + 1;

            var lStr = lines[x + 0];
            var rStr = lines[x + 1];

            var left = ParsePacket(lStr);
            var right = ParsePacket(rStr);

            if (Compare(left, right))
            {
                rightOrderSum += pair;
            }
        }

        return rightOrderSum;
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

    public static bool Compare(List<object> left, List<object> right)
    {
        while (left.Count > 0 && right.Count > 0)
        {
            if (left[0] is int && right[0] is int)
            {
                int elementL = (int)left[0];
                int elementR = (int)right[0];

                if (elementL < elementR)
                {
                    return true;
                }
                else if (elementL > elementR)
                {
                    return false;
                }
                else
                {
                    left.RemoveAt(0);
                    right.RemoveAt(0);
                }
            }
            else
            if (left[0] is int && !(right[0] is int))
            {
                return Compare(new List<object>() { (int)left[0] }, right[0] as List<object>);
            }
            else
            if (!(left[0] is int) && right[0] is int)
            {
                return Compare(left[0] as List<object>, new List<object>() { (int)right[0] });
            }
            else
            {
                var listL = left[0] as List<object>;
                var listR = right[0] as List<object>;
                if (listL.Count > 0 || listR.Count > 0)
                {
                    return Compare(listL, listR);
                }
                else
                {
                    left.RemoveAt(0);
                    right.RemoveAt(0);
                }
            }
        }

        if (left.Count == 0)
        {
            return true;
        }

        if (right.Count == 0)
        {
            return false;
        }

        throw new InvalidOperationException();
    }
}
