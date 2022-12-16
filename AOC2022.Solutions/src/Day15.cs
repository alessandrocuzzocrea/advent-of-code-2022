using System.Text;
using System.Text.RegularExpressions;

namespace AOC2022.Solutions;

public class Day15
{
    public static int Part1(string inputFilePath, int targetRow)
    {
        var lines = File.ReadAllLines(inputFilePath);

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
            minX = int.Min(minX, sensor.MinX);
            maxX = int.Max(maxX, sensor.MaxX);

            minY = int.Min(minY, sensor.MinY);
            maxY = int.Max(maxY, sensor.MaxX);
        }

        var grid = new Cave(minX, maxX, minY, maxY);

        for (var i = 0; i < sensors.Count; i++)
        {
            var sensor = sensors[i];

            for (var y = grid.minY; y <= grid.maxY; y++)
            {
                for (var x = grid.minX; x <= grid.maxX; x++)
                {
                    var dist = Math.Abs(x - sensor.Position.x) + Math.Abs(y - sensor.Position.y);
                    if (dist <= sensor.Distance)
                    {
                        grid[x, y] = '#';
                    }
                }
            }

        }

        foreach (var sensor in sensors)
        {
            grid[sensor.Position.x, sensor.Position.y] = 'S';
            grid[sensor.ClosestBeaconPosition.x, sensor.ClosestBeaconPosition.y] = 'B';
        }

        // grid.Print();

        var lollo = grid.RowPossibleBeaconPositions(targetRow);

        return lollo;
    }

    public static long Part2(string inputFilePath, int limit)
    {
        var lines = File.ReadAllLines(inputFilePath);

        List<Sensor> sensors = new();
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
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
            minX = int.Min(minX, sensor.MinX);
            maxX = int.Max(maxX, sensor.MaxX);

            minY = int.Min(minY, sensor.MinY);
            maxY = int.Max(maxY, sensor.MaxX);
        }

        var grid = new Cave(minX, maxX, minY, maxY);

        var targetX = -1;
        var targetY = -1;

        for (var y = 0; y <= limit; y++)
        {
            List<(int startX, int endX)> intervals = new();

            foreach (var sensor in sensors)
            {
                var (startX, endX) = sensor.GetMaxMinXPerRow(y);

                if (startX < 0)
                {
                    startX = 0;
                }

                if (endX > limit)
                {
                    endX = limit;
                }

                if (startX.HasValue && endX.HasValue)
                {
                    if (startX <= limit && endX >= 0)
                    {
                        intervals.Add((startX.Value, endX.Value));
                    }
                }
            }

            intervals.Sort((x, y) => x.startX - y.startX);

            List<(int startX, int endX)> mergedIntervals = new List<(int startX, int endX)>();

            (int startX, int endX) currentInterval = intervals.First();

            foreach (var interval in intervals.Skip(1))
            {
                if (currentInterval.endX + 1 >= interval.startX)
                {
                    currentInterval.endX = Math.Max(currentInterval.endX, interval.endX);
                }
                else
                {
                    mergedIntervals.Add(currentInterval);
                    currentInterval = interval;
                }
            }

            mergedIntervals.Add(currentInterval);

            if (mergedIntervals.Count > 1)
            {
                targetX = mergedIntervals.First().endX + 1;
                targetY = y;
            }
        }

        return targetX * 4_000_000L + targetY;
    }

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

        public int CalculateDistance()
        {
            return CalculateToPoint(ClosestBeaconPosition.x, ClosestBeaconPosition.y);
        }

        public int CalculateToPoint(int x, int y)
        {
            return Math.Abs(x - Position.x) + Math.Abs(y - Position.y);
        }

        public (int? minX, int? maxX) GetMaxMinXPerRow(int row)
        {
            int? minXPerRow = null;
            int? maxXPerRow = null;

            if (row >= Position.y - Distance && row <= Position.y + Distance)
            {
                var rowX = Position.x;
                var rowY = row;

                var distanceToPoint = CalculateToPoint(rowX, rowY);
                var distanceDiff = Distance - distanceToPoint;

                minXPerRow = Position.x - distanceDiff;
                maxXPerRow = Position.x + distanceDiff;
            }

            return (minXPerRow, maxXPerRow);
        }
    }

    public class Cave
    {
        readonly Dictionary<(int x, int y), char> _cells = new();

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

        public string GetRow(int row)
        {
            var sb = new StringBuilder();
            for (var x = minX; x <= maxX; x++)
            {
                sb.Append(this[x, row]);
            }
            return sb.ToString();
        }

        public void Print()
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
