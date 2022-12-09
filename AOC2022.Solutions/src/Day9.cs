namespace AOC2022.Solutions;

public class Day9
{
    public static int Part1(string inputFilePath)
    {
        return CalcVisited(2, File.ReadAllLines(inputFilePath));
    }

    public static int Part2(string inputFilePath)
    {
        return CalcVisited(10, File.ReadAllLines(inputFilePath));
    }

    private static int CalcVisited(int knotsCount, string[] lines)
    {
        Rope rope = new(knotsCount);

        foreach (var line in lines)
        {
            var direction = line.Split(" ")[0];
            var steps = int.Parse(line.Split(" ")[1]);
            rope.MoveHead(direction, steps);
        }

        return rope.Visited();
    }

    public class Knot
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public (int x, int y) GetPosition()
        {
            return (x, y);
        }

        public void Move((int x, int y) dir)
        {
            x += dir.x;
            y += dir.y;
        }
    }

    public class Rope
    {
        public Knot Head { get { return Knots[0]; } }
        public List<Knot> Knots = new();
        readonly HashSet<(int, int)> tailVisited = new();
        readonly Dictionary<string, (int, int)> directions = new()
        {
            {"U", (0, -1)},
            {"R", (1, 0)},
            {"D", (0, 1)},
            {"L", (-1, 0)},
        };

        public Rope(int knotsCount, int startX = 0, int startY = 0)
        {
            for (int i = 0; i < knotsCount; i++)
            {
                Knot newKnot = new();
                newKnot.setPosition(startX, startY);
                Knots.Add(newKnot);
            }

            tailVisited.Add((startX, startY));
        }

        public void MoveHead(string dir, int steps)
        {
            var currentDirection = directions[dir];

            for (int i = 0; i < steps; i++)
            {
                Head.Move(currentDirection);

                for (int j = 1; j < Knots.Count; j++)
                {
                    var current = Knots[j];
                    var previous = Knots[j - 1];

                    MoveTail(previous, current);

                    if (current == Knots[^1])
                    {
                        tailVisited.Add((current.x, current.y));
                    }
                }
            }
        }

        public int Visited() => tailVisited.Count;

        public static bool KnotsTouching(Knot head, Knot tail) => Math.Abs(head.x - tail.x) < 2 && Math.Abs(head.y - tail.y) < 2;

        private static void MoveTail(Knot head, Knot tail)
        {
            if (!KnotsTouching(head, tail))
            {
                var diffX = Math.Clamp(head.x - tail.x, -1, 1);
                var diffY = Math.Clamp(head.y - tail.y, -1, 1);

                tail.setPosition(tail.x + diffX, tail.y + diffY);
            }
        }
    }
}
