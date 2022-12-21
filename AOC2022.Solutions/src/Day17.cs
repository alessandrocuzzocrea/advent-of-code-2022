namespace AOC2022.Solutions;

public class Day17
{
    public static int Part1(string inputFilePath, int limit)
    {
        var c = new Chamber();
        c.SpawnRock();

        var lines = File.ReadAllLines(inputFilePath);
        var i = 0;
        while (true)
        {
            Console.WriteLine($"Rocks: {c.RocksCount}");

            if (c.RocksCount > limit)
            {
                break;
            }

            var chr = lines[0][i];
            // Console.WriteLine($"Input: {i}");
            c.Blow(chr);
            // c.Print();
            c.Fall();
            // c.Print();

            i = (i + 1) % lines[0].Length;
        }

        return c.FindHighestPointY();
    }

    public class Rock
    {
        public char[,] Shape { get; set; }
        public string Name { get; set; }

        public int Width => Shape.GetLength(1);
        public int Height => Shape.GetLength(0);

        public Rock(char[,] shape, string name)
        {
            Shape = shape;
            Name = name;
        }

        public char this[int x, int y]
        {
            get
            {
                return Shape[Shape.GetLength(0) - 1 - y, x];
            }
        }

        public void Print()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.Write(Shape[i, j]);
                }
                Console.WriteLine();
            }
        }

        public int LeftEdge()
        {
            return 0;
        }

        public int RightEdge()
        {
            var res = 0;
            for (var y = 0; y < Height; y++)
            {
                if (this[Width - 1, y] != '.')
                {
                    res = int.Max(res, Shape.GetLength(1) - 1);
                }
            }
            return res;
        }

        public HashSet<(int x, int y)> ToChamberSpace(int xOffset, int yOffset)
        {
            var res = new HashSet<(int x, int y)>();
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    if (this[x, y] == '#')
                    {
                        res.Add((x + xOffset, y + yOffset));
                    }
                }
            }
            return res;
        }
    }

    public class Chamber
    {
        public Rock[] Rocks { get; }

        public int CurrentRock { get; set; }
        public int CurrentRockX { get; set; }
        public int CurrentRockY { get; set; }
        public int RocksCount = 0;

        public int Width = 7;

        public HashSet<(int x, int y)> storage = new() {
            (0, -1), (1, -1), (2, -1), (3, -1), (4, -1), (5, -1)
        };

        public Chamber()
        {
            Rocks = new Rock[5];

            var rock1 = new Rock(new char[,] {
                { '#', '#', '#', '#' }
            }, "1");

            var rock2 = new Rock(new char[,] {
                { '.', '#', '.' },
                { '#', '#', '#' },
                { '.', '#', '.' }
            }, "2");

            var rock3 = new Rock(new char[,] {
                { '.', '.', '#' },
                { '.', '.', '#' },
                { '#', '#', '#' }
            }, "3");

            var rock4 = new Rock(new char[,] {
                { '#' },
                { '#' },
                { '#' },
                { '#' }
            }, "4");

            var rock5 = new Rock(new char[,] {
                { '#', '#' },
                { '#', '#' }
            }, "5");

            Rocks[0] = rock1;
            Rocks[1] = rock2;
            Rocks[2] = rock3;
            Rocks[3] = rock4;
            Rocks[4] = rock5;
        }

        public void SpawnRock()
        {
            CurrentRockX = 2;
            CurrentRockY = FindHighestPointY() + 3;
            RocksCount++;
        }

        public void Blow(char jet)
        {
            int newX;

            if (jet == '>')
            {
                newX = CurrentRockX + 1;
            }
            else
            {
                newX = CurrentRockX - 1;
            }

            if (!CheckWallCollisions(newX, CurrentRockY))
            {
                Console.WriteLine($"Jet {jet}");
                CurrentRockX = newX;
            }
            else
            {
                Console.WriteLine($"Jet {jet}... nothing happened");
            }
        }

        public void Fall()
        {
            var newY = CurrentRockY - 1;

            if (CheckFloorCollisions(CurrentRockX, newY))
            {
                var set = Rocks[CurrentRock].ToChamberSpace(CurrentRockX, CurrentRockY);
                storage.UnionWith(set);
                CurrentRock = (CurrentRock + 1) % 5;
                SpawnRock();
                Console.WriteLine($"Falling down by 1.. collision!");
            }
            else
            {
                Console.WriteLine($"Falling down by 1");
                CurrentRockY = newY;
            }
        }

        private bool CheckFloorCollisions(int x, int y)
        {
            var rock = Rocks[CurrentRock];
            var set = rock.ToChamberSpace(x, y);
            var intersection = storage.Intersect(set);
            return intersection.Any();
        }

        public bool CheckWallCollisions(int x, int y)
        {
            var rock = Rocks[CurrentRock];

            if (rock.LeftEdge() + x >= 0 && rock.RightEdge() + x < Width)
            {
                var set = rock.ToChamberSpace(x, y);
                var intersection = storage.Intersect(set);
                return intersection.Any();
            }

            return true;
        }

        public void Print()
        {
            for (var y = FindHighestPointY() + 10; y >= 0; y--)
            {
                Console.Write('|');

                for (var x = 0; x < Width; x++)
                {
                    if (Rocks[CurrentRock].ToChamberSpace(CurrentRockX, CurrentRockY).Contains((x, y)))
                    {
                        Console.Write('@');
                    }
                    else
                    if (storage.Contains((x, y)))
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine('|');
            }

            Console.WriteLine("+-------+\n");
        }

        public int FindHighestPointY()
        {
            int highest = -1;
            foreach (var (_, y) in storage)
            {
                highest = int.Max(highest, y);
            }
            return highest + 1;
        }
    }
}
