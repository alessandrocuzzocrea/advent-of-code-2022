namespace AOC2022.Solutions;

public class Day7
{
    const int TotalSpace = 70_000_000;
    const int SpaceRequired = 30_000_000;
    private class Node : IComparable<Node>
    {
        public Node? parent;
        public List<Node> children = new();
        public string path;
        public int size = 0;
        public Node(string path, Node? parent)
        {
            this.parent = parent;
            this.path = path;
            this.parent?.children.Add(this);
        }

        public int CompareTo(Node? other)
        {
            if (other == null)
            {
                return 1;
            }
            return other.calcSize() - this.calcSize();
        }

        public int calcSize()
        {
            int childrenTotalSize = 0;
            foreach (var child in children)
            {
                childrenTotalSize += child.calcSize();
            }

            return size + childrenTotalSize;
        }

        public override string ToString()
        {
            return "Node: " + path + " " + calcSize();
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
                                currNode = currNode?.parent;
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
                            Console.WriteLine($"ls");
                            break;
                    }
                    break;
                case "dir":
                    Console.WriteLine($"dir {tokens[1]}");
                    break;
                default:
                    Console.WriteLine($"file {tokens[1]}, size {tokens[0]}");
                    if (currNode != null)
                    {
                        currNode.size += int.Parse(tokens[0]);
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
                                currNode = currNode?.parent;
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
                            Console.WriteLine($"ls");
                            break;
                    }
                    break;
                case "dir":
                    Console.WriteLine($"dir {tokens[1]}");
                    break;
                default:
                    Console.WriteLine($"file {tokens[1]}, size {tokens[0]}");
                    if (currNode != null)
                    {
                        currNode.size += int.Parse(tokens[0]);
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
            Console.WriteLine(node.ToString());
            if (node.calcSize() >= emptySpaceNeeded)
            {
                loller = int.Min(loller, node.calcSize());
            }

        }

        return loller;
    }

    private static int dfs(Node n, ref int f)
    {
        int childrenTotalSize = 0;
        foreach (var child in n.children)
        {
            childrenTotalSize += dfs(child, ref f);
        }

        if (n.size + childrenTotalSize <= 100_000)
        {
            f += n.size + childrenTotalSize;
        }

        return n.size + childrenTotalSize;
    }

    private static int dfs2(Node n, ref int f)
    {
        int childrenTotalSize = 0;
        foreach (var child in n.children)
        {
            childrenTotalSize += dfs(child, ref f);
        }

        // if (n.size + childrenTotalSize <= 100_000)
        // {
        //     f += n.size + childrenTotalSize;
        // }

        return n.size + childrenTotalSize;
    }
}
