using System.Text.RegularExpressions;

namespace AOC2022.Solutions;

public class Day15
{
    public static int Part1(string inputFilePath, int targetRow)
    {
        var lines = File.ReadAllLines(inputFilePath);

        // process
        List<Sensor> sensors = new();
        foreach (var line in lines)
        {
            var m = Regex.Matches(line, @"-?\d+");
            var sensorX = int.Parse(m[0].Value);
            var sensorY = int.Parse(m[1].Value);
            var beaconX = int.Parse(m[2].Value);
            var beaconY = int.Parse(m[3].Value);

            sensors.Add(new Sensor((sensorX, sensorY), (beaconX, beaconY)));

        }

        var minX = int.MaxValue;
        var maxX = int.MinValue;

        var minY = int.MaxValue;
        var maxY = int.MinValue;

        foreach (var sensor in sensors)
        {
            minX = int.Min(minX, sensor.Position.x - sensor.Distance);
            maxX = int.Max(maxX, sensor.Position.x + sensor.Distance);

            minY = int.Min(minY, sensor.Position.y - sensor.Distance);
            maxY = int.Max(maxY, sensor.Position.y + sensor.Distance);
        }

        // var xOffset = -minX;
        // var yOffset = -minY;

        // List<List<char>> grid = new();
        var grid = new Cave(minX, maxX, minY, maxY);

        // for (int y = minY; y <= maxY; y++)
        // {
        //     grid.Add(new List<char>());

        //     for (int x = minX; x <= maxX; x++)
        //     {
        //         grid[y + yOffset].Add('.');
        //     }
        // }

        // var width = grid[0].Count;
        // var height = grid.Count;

        // var width = maxX - minX;
        // var height = maxY - minY;

        // PrintGrid(width, height, grid, yOffset);

        // var sensorProgress = 

        // foreach (var sensor in sensors)
        for (var i = 0; i < sensors.Count; i++)
        {
            var sensor = sensors[i];

            for (var x = grid.minX; x <= grid.maxX; x++)
            {
                var dist = Math.Abs(x - sensor.Position.x) + Math.Abs(targetRow - sensor.Position.y);
                if (dist <= sensor.Distance)
                {
                    grid[x, targetRow] = '#';
                }
            }
        }

        foreach (var sensor in sensors)
        {
            grid[sensor.Position.x, sensor.Position.y] = 'S';
            grid[sensor.ClosestBeaconPosition.x, sensor.ClosestBeaconPosition.y] = 'B';
        }

        // grid.PrintGrid();

        var lollo = grid.RowPossibleBeaconPositions(targetRow);

        return lollo;
    }

    public static int Part2(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        // process
        List<List<(int, int)>> scans = new();
        foreach (var line in lines)
        {
        }

        return -1;
    }

    // public static void PrintGrid(int width, int height, Cave grid, int yOffset)
    // {
    //     for (int y = 0; y < height; y++)
    //     {
    //         var tmp = string.Format("{0,3}", y - yOffset);
    //         Console.Write($"{tmp}: ");
    //         for (int x = 0; x < width; x++)
    //         {
    //             Console.Write(grid[x, y]);
    //         }
    //         Console.Write('\n');
    //     }
    // }

    public class Sensor
    {
        public (int x, int y) Position { get; }
        public (int x, int y) ClosestBeaconPosition { get; }
        public int Distance { get; }
        public int MinY { get; }
        public int MaxY { get; }
        public int MinX { get; }
        public int MaxX { get; }

        public Sensor((int x, int y) pos, (int x, int y) beaconPos)
        {
            Position = pos;
            ClosestBeaconPosition = beaconPos;
            Distance = CalculateDistance();

            MinY = Position.y - Distance;
            MaxY = Position.y + Distance;

            MinX = Position.x - Distance;
            MaxX = Position.x + Distance;
        }

        // private int CalculateDistance()
        // {
        //     var xDiff = ClosestBeaconPosition.x - Position.x;
        //     var yDiff = ClosestBeaconPosition.y - Position.y;
        //     return (int)Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        // }

        public int CalculateDistance()
        {
            return Math.Abs(ClosestBeaconPosition.x - Position.x) + Math.Abs(ClosestBeaconPosition.y - Position.y);
        }
    }

    public class Cave
    {
        Dictionary<(int x, int y), char> _cells = new();

        public int minX { get; }
        public int maxX { get; }
        public int minY { get; }
        public int maxY { get; }

        public Cave(int minX, int maxX, int minY, int maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
        }

        public char this[int x, int y]
        {
            get
            {
                if (_cells.TryGetValue((x, y), out var value))
                {
                    return value;
                }
                else
                {
                    return '.';
                }
            }
            set
            {
                _cells[(x, y)] = value;
            }
        }

        public int RowPossibleBeaconPositions(int row)
        {
            var count = 0;
            for (var x = minX; x <= maxX; x++)
            {
                if (this[x, row] == '#')
                {
                    count++;
                }
            }
            return count;
        }

        public void PrintGrid()
        {
            for (int y = minY; y <= maxY; y++)
            {
                var tmp = string.Format("{0,3}", y);
                Console.Write($"{tmp}: ");
                for (int x = minX; x <= maxX; x++)
                {
                    Console.Write(this[x, y]);
                }
                Console.Write('\n');
            }
        }
    }
}
