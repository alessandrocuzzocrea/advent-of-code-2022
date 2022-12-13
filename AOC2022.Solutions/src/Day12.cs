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
        // var ans = new Solver(lines).solve();
        var ans = new Solver(lines).Solve2();

        return ans;
    }

    public static int Part2(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);
        // var ans = new Solver(lines).solve();
        var ans = new Solver(lines).Solve3();

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

    public class Node : IEquatable<Node>
    {
        public int x { get; set; }
        public int y { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F { get { return G + H; } }
        public char Value { get; set; }
        public char OGChar { get; set; }
        public Node Parent { get; set; }

        public Node(int x, int y, char value)
        {
            this.x = x;
            this.y = y;
            Value = value;
        }

        public bool Equals(Node? other)
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

        public override string ToString()
        {
            return $"x: {x}, y: {y}, char:{OGChar}";
        }
    }

    public class Solver
    {
        public HeightMap maze;
        private List<Node> openList;
        private List<Node> closedList;
        public Solver(string[] heightMapData)
        {
            maze = new HeightMap(heightMapData);

            openList = new List<Node>();
            closedList = new List<Node>();
        }

        public int solve()
        {
            char[,] footprints = new char[maze.Height, maze.Width];

            return dfs(new Direction { x = maze.S.Item1, y = maze.S.Item2 }, Array.Empty<Direction>(), footprints, 0);
        }

        public int Solve2()
        {
            // char[,] footprints = new char[maze.Height, maze.Width];

            // return dfs(new Direction { x = maze.S.Item1, y = maze.S.Item2 }, Array.Empty<Direction>(), footprints, 0);
            var startNode = new Node(maze.S.Item1, maze.S.Item2, 'S')
            {
                OGChar = 'S'
            };
            var endNode = new Node(maze.E.Item1, maze.E.Item2, 'E') { OGChar = 'E' };

            startNode.G = 0;
            startNode.H = CalcH(startNode, endNode);

            openList.Add(startNode);

            while (openList.Count > 0)
            {
                var currentNode = GetLowestFScoreNode();

                if (currentNode.Equals(endNode))
                {
                    return currentNode.G;
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                var neighbors = GetNeighbors(currentNode);
                foreach (var neighbor in neighbors)
                {
                    if (closedList.Contains(neighbor))
                    {
                        continue;
                    }

                    neighbor.G = currentNode.G + 1;
                    neighbor.H = CalcH(neighbor, endNode);
                    neighbor.Parent = currentNode;

                    // foreach (Node openNode in openList)
                    // {
                    //     if (neighbor.Equals(openNode) && neighbor.G > openNode.G)
                    //     {
                    //         continue;
                    //     }
                    //     else
                    //     {
                    //         // neighbor.Parent = currentNode;
                    //         // openList.Add(neighbor);
                    //     }
                    // })
                    if (!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                    }
                }

            }
            return -1;
        }

        public int AStar(Node startNode, Node endNode)
        {
            // return dfs(new Direction { x = maze.S.Item1, y = maze.S.Item2 }, Array.Empty<Direction>(), footprints, 0);
            // var startNode = new Node(maze.S.Item1, maze.S.Item2, 'S')
            // {
            //     OGChar = 'S'
            // };

            startNode.G = 0;
            startNode.H = CalcH(startNode, endNode);

            openList.Add(startNode);

            while (openList.Count > 0)
            {
                var currentNode = GetLowestFScoreNode();

                if (currentNode.Equals(endNode))
                {
                    return currentNode.G;
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                var neighbors = GetNeighbors(currentNode);
                foreach (var neighbor in neighbors)
                {
                    if (closedList.Contains(neighbor))
                    {
                        continue;
                    }

                    neighbor.G = currentNode.G + 1;
                    neighbor.H = CalcH(neighbor, endNode);
                    neighbor.Parent = currentNode;

                    // foreach (Node openNode in openList)
                    // {
                    //     if (neighbor.Equals(openNode) && neighbor.G > openNode.G)
                    //     {
                    //         continue;
                    //     }
                    //     else
                    //     {
                    //         // neighbor.Parent = currentNode;
                    //         // openList.Add(neighbor);
                    //     }
                    // })
                    if (!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                    }
                }

            }
            return int.MaxValue;
        }

        public int Solve3()
        {
            List<(int x, int y, int steps)> results = new();

            List<Node> ANodes = FindAllAs(maze);
            var endNode = new Node(maze.E.Item1, maze.E.Item2, 'E') { OGChar = 'E' };

            for (var i = 0; i < ANodes.Count; i++)
            {
                // Console.WriteLine($"Progress {i}/{ANodes.Count}");
                var startNode = ANodes[i];
                openList.Clear();
                closedList.Clear();
                var steps = AStar(startNode, endNode);
                results.Add((startNode.x, startNode.y, steps));
            }

            results.Sort((x, y) => x.steps.CompareTo(y.steps));

            return results[0].steps;
        }

        private List<Node> FindAllAs(HeightMap maze)
        {
            List<Node> res = new();
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    char c = maze.GetCharacter(x, y);
                    if (c == 'S' || c == 'a')
                    {
                        res.Add(new Node(x, y, c));
                    }
                }
            }
            return res;
        }

        public bool IsPossibleDestination2(Node curr, Node child)
        {
            // if (!visited.ToList().Contains(dest))
            // {
            if (child.x >= 0 && child.x < maze.Width && child.y >= 0 && child.y < maze.Height)
            {
                // var currValue = maze[curr.y][curr.x];
                var currValue = maze.GetCharacter(curr.x, curr.y);

                // var destValue = maze[dest.y][dest.x];
                var destValue = maze.GetCharacter(child.x, child.y);

                child.OGChar = destValue;

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

        public List<Node> GetNeighbors(Node curr)
        {
            List<Node> res = new();

            // up
            var up = new Node(curr.x, curr.y - 1, '^');
            if (IsPossibleDestination2(curr, up))
            {
                res.Add(up);
            };

            // right
            var right = new Node(curr.x + 1, curr.y, '>');
            if (IsPossibleDestination2(curr, right))
            {
                res.Add(right);
            };

            // down
            var down = new Node(curr.x, curr.y + 1, 'v');
            if (IsPossibleDestination2(curr, down))
            {
                res.Add(down);
            };

            // left
            var left = new Node(curr.x - 1, curr.y, '<');
            if (IsPossibleDestination2(curr, left))
            {
                res.Add(left);
            };

            return res;
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

        public int CalcH(Node current, Node end)
        {
            return Math.Abs(current.x - end.x) + Math.Abs(current.y - end.y);
        }

        public Node GetLowestFScoreNode()
        {
            Node lowest = openList[0];
            foreach (Node n in openList)
            {
                if (n.F < lowest.F)
                {
                    lowest = n;
                }
            }

            return lowest;
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
