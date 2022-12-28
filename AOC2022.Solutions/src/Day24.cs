namespace AOC2022.Solutions;

public class Day24
{
    public static int Part1(string inputFilePath)
    {
        var result = Solve(File.ReadAllLines(inputFilePath));
        return result;
    }

    public static int Solve(string[] map)
    {
        var v = new Valley(map);
        int minSteps = v.GetMinSteps();

        return minSteps;
    }

    public class Valley
    {
        public string[] Map { get; private set; }
        public (int x, int y) Start { get; }
        public (int x, int y) Goal { get; }
        public List<Blizzard> Blizzards { get; }
        public Valley(string[] map)
        {
            Map = map;

            for (var i = 0; i < map[0].Length; i++)
            {
                var c = map[0][i];
                if (c == '.')
                {
                    Start = (i, 0);
                }
            }

            for (var i = 0; i < map[^1].Length; i++)
            {
                var c = map[^1][i];
                if (c == '.')
                {
                    Goal = (i, map.Length - 1);
                }
            }

            Blizzards = new List<Blizzard>();

            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == '^' || map[y][x] == 'v' || map[y][x] == '<' || map[y][x] == '>')
                    {
                        var b = new Blizzard(map[y][x], x, y);
                        Blizzards.Add(b);
                    }
                }
            }
        }

        public char this[int x, int y]
        {
            get
            {
                var blizzards = GetBlizzards(x, y);

                if (blizzards.Count > 1)
                {
                    return '2';
                }
                else if (blizzards.Count == 1)
                {
                    return blizzards[0].Direction;
                }
                else if (Start.x == x && Start.y == y)
                {
                    return '.';
                }
                else if (Goal.x == x && Goal.y == y)
                {
                    return '.';
                }
                else if (x == 0 || x == Map[0].Length - 1 || y == 0 || y == Map.Length - 1)
                {

                    return '#';
                }

                return '.';
            }
        }

        public List<Blizzard> GetBlizzards(int x, int y)
        {
            List<Blizzard> result = new();
            foreach (var b in Blizzards)
            {
                if (b.X == x && b.Y == y)
                {
                    result.Add(b);
                }
            }

            return result;
        }

        public void Print((int x, int y) PlayerPosition)
        {
            for (int y = 0; y < Map.Length; y++)
            {
                for (int x = 0; x < Map[0].Length; x++)
                {
                    if (x == PlayerPosition.x && y == PlayerPosition.y)
                    {
                        Console.Write('E');
                    }
                    else
                    {
                        Console.Write(this[x, y]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Tick()
        {
            foreach (var b in Blizzards)
            {
                (int x, int y) = (b.X, b.Y);

                switch (b.Direction)
                {
                    case '^':
                        y--;
                        if (y < 1)
                        {
                            y = Map.Length - 2;
                        }
                        break;
                    case 'v':
                        y++;
                        if (y >= Map.Length - 1)
                        {
                            y = 1;
                        }
                        break;
                    case '<':
                        x--;
                        if (x < 1)
                        {
                            x = Map[0].Length - 2;
                        }
                        break;
                    case '>':
                        x++;
                        if (x >= Map[0].Length - 1)
                        {
                            x = 1;
                        }
                        break;
                }

                b.Move(x, y);
            }
        }

        public int GetMinSteps()
        {
            Queue<((int x, int y) position, int steps, string history)> queue = new Queue<((int x, int y) position, int steps, string history)>();
            queue.Enqueue((Start, 0, $"{Start.x},{Start.y}"));

            Dictionary<(int x, int y), int> minSteps = new Dictionary<(int x, int y), int>();
            minSteps[Start] = 0;

            Console.WriteLine("=== Initial State ===");
            Print(Start);

            while (queue.Any())
            {
                ((int x, int y) position, int steps, string history) = queue.Dequeue();
                if (position == Goal)
                {
                    Print(position);
                    return steps;
                }
                Tick();
                Print(position);
                EnqueueNeighbors(queue, minSteps, position, steps, history);
            }

            return -1;
        }

        public void EnqueueNeighbors(Queue<((int x, int y) position, int steps, string history)> queue, Dictionary<(int x, int y), int> minSteps, (int x, int y) position, int steps, string history)
        {
            var moves = GetPossibleNextMove(position);

            foreach (var m in moves)
            {
                EnqueueNeighbor(queue, minSteps, m.position, steps + 1, history);

            }
        }

        public void EnqueueNeighbor(Queue<((int x, int y) position, int steps, string history)> queue, Dictionary<(int x, int y), int> minSteps, (int x, int y) position, int steps, string history)
        {
            if (IsValidPosition(position))
            {
                minSteps[position] = steps;
                queue.Enqueue((position, steps, $"{history} {position.x},{position.y}"));
            }
        }

        public List<(int score, (int x, int y) position)> GetPossibleNextMove((int x, int y) position)
        {
            var possibleMoves = new List<(int score, (int x, int y) position)>();

            var left = (position.x - 1, position.y);
            var right = (position.x + 1, position.y);
            var up = (position.x, position.y - 1);
            var down = (position.x, position.y + 1);
            var wait = (position.x, position.y);

            possibleMoves.Add((CalcScore(left), left));
            possibleMoves.Add((CalcScore(right), right));
            possibleMoves.Add((CalcScore(up), up));
            possibleMoves.Add((CalcScore(down), down));
            possibleMoves.Add((CalcScore(wait), wait));

            IComparer<(int score, (int x, int y) position)> comparer = Comparer<(int score, (int x, int y) position)>.Create((a, b) => a.score.CompareTo(b.score));

            possibleMoves.Sort(comparer);

            return possibleMoves;
        }

        public int CalcScore((int x, int y) position)
        {
            return Math.Abs(position.x - Goal.x) + Math.Abs(position.y - Goal.y);
        }

        public bool IsValidPosition((int x, int y) position)
        {
            var wall = IsWall(position);
            var bliz = IsBlizzard(position);
            var oob = IsOutOfBounds(position);
            var amIGoingToDie = AmIGoingToDie(position);
            return !wall && !bliz && !oob && !amIGoingToDie;
        }

        public bool IsWall((int x, int y) position)
        {
            var bWall = this[position.x, position.y] == '#';
            return bWall;
        }

        public bool IsBlizzard((int x, int y) position)
        {
            var tile = this[position.x, position.y];
            var bBlizz = tile == '^' || tile == 'v' || tile == '<' || tile == '>' || tile == '2';
            return bBlizz;
        }

        public bool IsOutOfBounds((int x, int y) position)
        {
            (int x, int y) = position;
            var oob = x < 0 || x > Map[0].Length || y < 0 || y > Map.Length;
            return oob;
        }

        public bool AmIGoingToDie((int x, int y) position)
        {
            var left = this[position.x - 1, position.y] == '>';
            var right = this[position.x + 1, position.y] == '<';
            var up = this[position.x, position.y - 1] == 'v';
            var down = this[position.x, position.y + 1] == '^';

            var gonnaDie = left || right || up || down;
            return gonnaDie;
        }
    }

    public class Blizzard
    {
        public char Direction { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public Blizzard(char direction, int x, int y)
        {
            Direction = direction;
            X = x;
            Y = y;
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
