namespace AOC2022.Solutions;

public class Day10
{
    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var cycleCounter = 0;
        var X = 1;
        var signalStrength = 0;
        var specialCycles = new int[] { 20, 60, 100, 140, 180, 220 };

        foreach (var line in lines)
        {
            var opCode = line.Split(" ")[0];
            switch (opCode)
            {
                case "noop":
                    cycleCounter++;
                    if (specialCycles.Contains(cycleCounter))
                    {
                        signalStrength += cycleCounter * X;
                    }

                    break;
                case "addx":
                    cycleCounter++;
                    if (specialCycles.Contains(cycleCounter))
                    {
                        signalStrength += cycleCounter * X;
                    }

                    cycleCounter++;
                    if (specialCycles.Contains(cycleCounter))
                    {
                        signalStrength += cycleCounter * X;
                    }

                    var V = int.Parse(line.Split(" ")[1]);
                    X += V;

                    break;

            }

        }

        return signalStrength;
    }
}
