namespace AOC2022.Solutions;

public class Day9
{
    public class Rope
    {
        readonly HashSet<(int, int)> tailVisited = new();
        public class Knot
        {
            public int x { get; private set; }
            public int y { get; private set; }

            public int xPrev { get; private set; }
            public int yPrev { get; private set; }

            public void setPosition(int x, int y)
            {
                xPrev = this.x;
                yPrev = this.y;

                this.x = x;
                this.y = y;
            }

            public (int x, int y) GetPosition()
            {
                return (x, y);
            }

            public (int x, int y) GetPositionPrevious()
            {
                return (xPrev, yPrev);
            }

            public void setMove((int x, int y) dir)
            {
                xPrev = x;
                yPrev = y;

                x += dir.x;
                y += dir.y;
            }
        }

        readonly Dictionary<string, (int, int)> directions = new() {
                {"U", (0, -1)},
                {"R", (1, 0)},
                {"D", (0, 1)},
                {"L", (-1, 0)},
            };

        public Knot _head;
        // public Knot _tail;
        public List<Knot> Tails = new();

        public Rope(int knotsCount, int startX = 0, int startY = 0)
        {
            if (knotsCount <= 1)
            {
                throw new ArgumentException("lollo");
            }
            _head = new();
            _head.setPosition(startX, startY);
            Tails.Add(_head);

            for (int i = 1; i < knotsCount; i++)
            {
                Knot newKnot = new();
                newKnot.setPosition(startX, startY);
                Tails.Add(newKnot);
            }

            tailVisited.Add((startX, startY));
        }

        public int Visited()
        {
            return tailVisited.Count;
        }

        public bool KnotsTouching(Knot head, Knot tail)
        {
            if (Math.Abs(head.x - tail.x) < 2 && Math.Abs(head.y - tail.y) < 2)
            {
                return true;
            }

            return false;
        }

        public void MoveHead(string dir, int steps)
        {
            var currentDirection = directions[dir];

            for (int i = 0; i < steps; i++)
            {
                _head.setMove(currentDirection);

                for (int j = 1; j < Tails.Count; j++)
                {
                    MoveTail(Tails[j - 1], Tails[j]);
                }
            }
        }

        void MoveTail(Knot head, Knot tail)
        {
            var tailX = tail.x;
            var tailY = tail.y;

            if (!KnotsTouching(head, tail))
            {
                tailX = head.GetPositionPrevious().x;
                tailY = head.GetPositionPrevious().y;
            }

            tail.setPosition(tailX, tailY);
            tailVisited.Add((tail.x, tail.y));
        }
    }

    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);
        Rope rope = new(2);

        foreach (var line in lines)
        {
            var d = line.Split(" ")[0];
            var s = line.Split(" ")[1];
            rope.MoveHead(d, int.Parse(s));
        }

        return rope.Visited();
    }
}
