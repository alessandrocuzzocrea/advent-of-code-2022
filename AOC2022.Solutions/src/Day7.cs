namespace AOC2022.Solutions;

public class Day7
{
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

        public int NodeSize()
        {
            return Size + ChildrenSize();
        }

        public int ChildrenSize()
        {
            int totalSize = 0;
            foreach (var child in Children)
            {
                totalSize += child.NodeSize();
            }

            return totalSize;
        }

        public int CompareTo(Node? other)
        {
            if (other == null)
            {
                return -1;
            }
            return NodeSize() - other.NodeSize();
        }

        public override string ToString()
        {
            return "Node: " + Path + " " + NodeSize().ToString("N0");
        }
    }

    public static int Part1(string inputFilePath)
    {
        var nodes = ExecuteCommands(File.ReadAllLines(inputFilePath));

        int f = 0;
        foreach (var n in nodes)
        {
            if (n.NodeSize() <= 100_000)
            {
                f += n.NodeSize();
            }
        }

        return f;
    }

    public static int Part2(string inputFilePath)
    {
        var nodes = ExecuteCommands(File.ReadAllLines(inputFilePath));

        const int TotalSpace = 70_000_000;
        const int SpaceRequired = 30_000_000;

        var emptySpaceNeeded = SpaceRequired - (TotalSpace - nodes[0].NodeSize());

        nodes.Sort();

        foreach (var node in nodes)
        {
            if (node.NodeSize() >= emptySpaceNeeded)
            {
                return node.NodeSize();
            }
        }

        return -1;
    }

    private static List<Node> ExecuteCommands(string[] cmds)
    {
        var nodes = new List<Node>();
        Node? currNode = null;

        foreach (var cmd in cmds)
        {
            var tokens = cmd.Split(' ');

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
                                var newNode = new Node(path, currNode);
                                nodes.Add(newNode);
                                currNode = newNode;
                            }
                            break;
                        case "ls":
                            break;
                    }
                    break;
                case "dir":
                    break;
                default:
                    if (currNode != null)
                    {
                        currNode.Size += int.Parse(tokens[0]);
                    }
                    break;
            }
        }

        return nodes;
    }
}
