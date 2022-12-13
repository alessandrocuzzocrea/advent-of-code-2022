namespace AOC2022.Solutions;

public class Day12
{
    /* 
    
    - a lowest
    - z highest
    - one step
    - up, right, down, left
    - destination square can be at most one higher (eg: m -> n)
    - S start
    - E goal

    */

    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);
        var ans = new Solver(lines).solve();

        return ans;
    }

    public class Direction : IEquatable<Direction>
    {
        public char dir = '.';
        public int x;
        public int y;

        public bool Equals(Direction? other)
        {
            if (other == null)
            {
                return false;
            }

            if (x == other.x && y == other.y)
            {
                return true;

            }

            return false;
        }

        public override bool Equals(object obj)
        {

            Direction? dirObj = obj as Direction;

            if (obj == null) return false;
            return Equals(dirObj);
        }

        public override int GetHashCode()
        {
            return $"{x},{y}".GetHashCode();
        }
    }

    public class HeightMap
    {
        readonly string[] _data;
        public int Width { get { return _data[0].Length; } }
        public int Height { get { return _data.Length; } }
        public (int, int) S;
        public (int, int) E;

        public HeightMap(string[] data)
        {
            _data = data;

            //find S & E
            for (var i = 0; i < Height; i++)
            {
                var line = _data[i];

                if (line.IndexOf('S') != -1)
                {
                    S = (line.IndexOf('S'), i);
                }

                if (line.IndexOf('E') != -1)
                {
                    E = (line.IndexOf('E'), i);
                }
            }
        }

        public bool CanMove(Direction curr, Direction dest/*, Direction[] visited*/)
        {
            // if (!visited.ToList().Contains(dest))
            // {
            if (dest.x >= 0 && dest.x < Width && dest.y >= 0 && dest.y < Height)
            {
                // var currValue = maze[curr.y][curr.x];
                var currValue = GetCharacter(curr.x, curr.y);

                // var destValue = maze[dest.y][dest.x];
                var destValue = GetCharacter(dest.x, dest.y);

                if (currValue == 'S')
                {
                    currValue = 'a';
                }

                if (destValue == 'E')
                {
                    destValue = 'z';
                }

                if (currValue >= destValue || currValue + 1 == destValue)
                {
                    return true;
                }
            }
            // }
            return false;
        }

        public List<Direction> GetPossibleDestinations(Direction curr/*, Direction[] visited*/)
        {
            List<Direction> res = new();

            // up
            var up = new Direction { x = curr.x, y = curr.y - 1, dir = '^' };
            if (CanMove(curr, up))
            {
                res.Add(up);
            };

            // right
            var right = new Direction { x = curr.x + 1, y = curr.y, dir = '>' };
            if (CanMove(curr, right))
            {
                res.Add(right);
            };

            // down
            var down = new Direction { x = curr.x, y = curr.y + 1, dir = 'v' };
            if (CanMove(curr, down))
            {
                res.Add(down);
            };

            // left
            var left = new Direction { x = curr.x - 1, y = curr.y, dir = '<' };
            if (CanMove(curr, left))
            {
                res.Add(left);
            };

            return res;
        }

        public char GetCharacter(int x, int y)
        {
            return _data[y][x];
        }
    }

    public class Solver
    {
        public HeightMap maze;
        public Solver(string[] heightMapData)
        {
            this.maze = new HeightMap(heightMapData);
        }

        public int solve()
        {
            char[,] footprints = new char[maze.Height, maze.Width];

            return dfs(new Direction { x = maze.S.Item1, y = maze.S.Item2 }, Array.Empty<Direction>(), footprints, 0);
        }

        public List<Direction> GetPossibleDestinations(Direction curr, Direction[] visited)
        {
            List<Direction> res = new();

            // up
            var up = new Direction { x = curr.x, y = curr.y - 1, dir = '^' };
            if (IsPossibleDestination(curr, up, visited))
            {
                res.Add(up);
            };

            // right
            var right = new Direction { x = curr.x + 1, y = curr.y, dir = '>' };
            if (IsPossibleDestination(curr, right, visited))
            {
                res.Add(right);
            };

            // down
            var down = new Direction { x = curr.x, y = curr.y + 1, dir = 'v' };
            if (IsPossibleDestination(curr, down, visited))
            {
                res.Add(down);
            };

            // left
            var left = new Direction { x = curr.x - 1, y = curr.y, dir = '<' };
            if (IsPossibleDestination(curr, left, visited))
            {
                res.Add(left);
            };

            return res;
        }

        public bool IsPossibleDestination(Direction curr, Direction dest, Direction[] visited)
        {
            if (!visited.ToList().Contains(dest))
            {
                if (dest.x >= 0 && dest.x < maze.Width && dest.y >= 0 && dest.y < maze.Height)
                {
                    // var currValue = maze[curr.y][curr.x];
                    var currValue = maze.GetCharacter(curr.x, curr.y);

                    // var destValue = maze[dest.y][dest.x];
                    var destValue = maze.GetCharacter(dest.x, dest.y);

                    if (currValue == 'S')
                    {
                        currValue = 'a';
                    }

                    if (destValue == 'E')
                    {
                        destValue = 'z';
                    }

                    if (currValue >= destValue || currValue + 1 == destValue)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int dfs(Direction curr, Direction[] visited, char[,] footprints, int steps)
        {
            var newVisited = visited.Append(curr).ToArray();

            if ((curr.x, curr.y) == maze.E)
            {
                Console.WriteLine($"FOUND x: {curr.x}, y: {curr.y}, steps:{steps}");

                if (steps == 31)
                {
                    for (var y = 0; y < maze.Height; y++)
                    {
                        for (var x = 0; x < maze.Width; x++)
                        {
                            if (footprints[y, x] == '\0')
                            {
                                Console.Write('.');
                            }
                            else
                            {
                                Console.Write(footprints[y, x]);
                            }
                        }
                        Console.Write('\n');
                    }
                }

                return steps;
            }

            // Console.WriteLine($"Visit x: {curr.x}, y: {curr.y}, steps:{steps}");

            if (steps >= 100_00)
            {
                return int.MaxValue;
            }

            // var possibleMoves = GetPossibleDestinations(curr, newVisited);
            var possibleMoves = maze.GetPossibleDestinations(curr);

            possibleMoves.RemoveAll(dir => newVisited.Contains(dir));

            List<int> dfsRes = new();
            foreach (var move in possibleMoves)
            {
                // if (newVisited.Contains(move))
                // {
                //     continue;
                // }
                char[,] newFootprints = new char[maze.Height, maze.Width];
                Array.Copy(footprints, newFootprints, maze.Width * maze.Height);

                newFootprints[curr.y, curr.x] = move.dir;

                var tmp = dfs(move, newVisited, newFootprints, steps + 1);
                dfsRes.Add(tmp);
            }

            if (dfsRes.Count == 0)
            {
                return int.MaxValue;
            }

            var minz = dfsRes.Min();

            return minz;
        }

        // public List<Direction> FilterAlreadyVisited(List<Direction> moves)
        // {
        //     moves. 
        // }
    }
}
