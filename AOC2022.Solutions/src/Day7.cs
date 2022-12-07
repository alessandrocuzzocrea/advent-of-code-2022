namespace AOC2022.Solutions;

public class Day7
{
    const int TotalSpace = 70_000_000;
    const int SpaceRequired = 30_000_000;
    private class Node : IComparable<Node>
    {
        public string Path;
        public Node? Parent;
        public List<Node> Children = new();
        public int Size = 0;

        public Node(string path, Node? parent)
        {
            Path = path;
            Parent = parent;
            Parent?.Children.Add(this);
        }

        public int CalcSize()
        {
            return Size + CalcChildrenSize();
        }

        public int CalcChildrenSize()
        {
            int totalSize = 0;
            foreach (var child in Children)
            {
                totalSize += child.CalcSize();
            }

            return totalSize;
        }

        public int CompareTo(Node? other)
        {
            if (other == null)
            {
                return 1;
            }
            return other.CalcSize() - this.CalcSize();
        }
    }

    public static int Part1(string inputFilePath)
    {
        Node? root = null;
        Node? currNode = null;

        foreach (var s in File.ReadAllLines(inputFilePath))
        {
            var tokens = s.Split(' ');

            switch (tokens[0])
            {
                case "$":
                    switch (tokens[1])
                    {
                        case "cd":
                            var path = tokens[2];

                            if (path == "..")
                            {
                                currNode = currNode?.Parent;
                            }
                            else
                            {
                                if (path == "/")
                                {
                                    var newNode = new Node(path, null);
                                    root = newNode;
                                    currNode = newNode;
                                }
                                else
                                {
                                    var newNode = new Node(path, currNode);
                                    currNode = newNode;
                                }
                            }
                            break;
                        case "ls":
                            // Console.WriteLine($"ls");
                            break;
                    }
                    break;
                case "dir":
                    // Console.WriteLine($"dir {tokens[1]}");
                    break;
                default:
                    // Console.WriteLine($"file {tokens[1]}, size {tokens[0]}");
                    if (currNode != null)
                    {
                        currNode.Size += int.Parse(tokens[0]);
                    }
                    break;
            }
        }

        int f = 0;
        dfs(root, ref f);

        return f;
    }

    public static int Part2(string inputFilePath)
    {
        Node? root = null;
        Node? currNode = null;

        var nodes = new List<Node>();

        foreach (var s in File.ReadAllLines(inputFilePath))
        {
            var tokens = s.Split(' ');

            switch (tokens[0])
            {
                case "$":
                    switch (tokens[1])
                    {
                        case "cd":
                            var path = tokens[2];

                            if (path == "..")
                            {
                                currNode = currNode?.Parent;
                            }
                            else
                            {
                                if (path == "/")
                                {
                                    var newNode = new Node(path, null);
                                    nodes.Add(newNode);
                                    root = newNode;
                                    currNode = newNode;
                                }
                                else
                                {
                                    var newNode = new Node(path, currNode);
                                    nodes.Add(newNode);
                                    currNode = newNode;
                                }
                            }
                            break;
                        case "ls":
                            // Console.WriteLine($"ls");
                            break;
                    }
                    break;
                case "dir":
                    // Console.WriteLine($"dir {tokens[1]}");
                    break;
                default:
                    // Console.WriteLine($"file {tokens[1]}, size {tokens[0]}");
                    if (currNode != null)
                    {
                        currNode.Size += int.Parse(tokens[0]);
                    }
                    break;
            }
        }

        int f = 0;
        int totalSpaceUsed = dfs2(root, ref f);

        int unusedSpace = TotalSpace - totalSpaceUsed;
        int emptySpaceNeeded = SpaceRequired - unusedSpace;

        nodes.Sort();
        int loller = int.MaxValue;

        foreach (var node in nodes)
        {
            // Console.WriteLine(node.ToString());
            if (node.CalcSize() >= emptySpaceNeeded)
            {
                loller = int.Min(loller, node.CalcSize());
            }

        }

        return loller;
    }

    private static int dfs(Node n, ref int f)
    {
        int childrenTotalSize = 0;
        foreach (var child in n.Children)
        {
            childrenTotalSize += dfs(child, ref f);
        }

        if (n.Size + childrenTotalSize <= 100_000)
        {
            f += n.Size + childrenTotalSize;
        }

        return n.Size + childrenTotalSize;
    }

    private static int dfs2(Node n, ref int f)
    {
        int childrenTotalSize = 0;
        foreach (var child in n.Children)
        {
            childrenTotalSize += dfs(child, ref f);
        }

        // if (n.size + childrenTotalSize <= 100_000)
        // {
        //     f += n.size + childrenTotalSize;
        // }

        return n.Size + childrenTotalSize;
    }
}
