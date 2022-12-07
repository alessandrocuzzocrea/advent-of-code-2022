namespace AOC2022.Solutions;

public class Day7
{
    private class Directory : IComparable<Directory>
    {
        public string Path;
        public Directory? Parent;
        public List<Directory> Children = new();
        public int Size = 0;

        public Directory(string path, Directory? parent)
        {
            Path = path;
            Parent = parent;
            Parent?.Children.Add(this);
        }

        public int DirectorySize()
        {
            return Size + ChildrenSize();
        }

        public int ChildrenSize()
        {
            int totalSize = 0;
            foreach (var child in Children)
            {
                totalSize += child.DirectorySize();
            }

            return totalSize;
        }

        public int CompareTo(Directory? other)
        {
            if (other == null)
            {
                return -1;
            }
            return DirectorySize() - other.DirectorySize();
        }
    }

    public static int Part1(string inputFilePath)
    {
        var dirs = ExecuteCommands(File.ReadAllLines(inputFilePath));

        int f = 0;
        foreach (var d in dirs)
        {
            if (d.DirectorySize() <= 100_000)
            {
                f += d.DirectorySize();
            }
        }

        return f;
    }

    public static int Part2(string inputFilePath)
    {
        var dirs = ExecuteCommands(File.ReadAllLines(inputFilePath));

        const int TotalSpace = 70_000_000;
        const int SpaceRequired = 30_000_000;

        var emptySpaceNeeded = SpaceRequired - (TotalSpace - dirs[0].DirectorySize());

        dirs.Sort();

        foreach (var d in dirs)
        {
            if (d.DirectorySize() >= emptySpaceNeeded)
            {
                return d.DirectorySize();
            }
        }

        return -1;
    }

    private static List<Directory> ExecuteCommands(string[] cmds)
    {
        var dirs = new List<Directory>();
        Directory? currDir = null;

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
                                currDir = currDir?.Parent;
                            }
                            else
                            {
                                var newDir = new Directory(path, currDir);
                                dirs.Add(newDir);
                                currDir = newDir;
                            }
                            break;
                        case "ls":
                            break;
                    }
                    break;
                case "dir":
                    break;
                default:
                    if (currDir != null)
                    {
                        currDir.Size += int.Parse(tokens[0]);
                    }
                    break;
            }
        }

        return dirs;
    }
}
