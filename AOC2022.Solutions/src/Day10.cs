using System.Text;

namespace AOC2022.Solutions;

public class Day10
{
    public static int Part1(string inputFilePath)
    {
        var cycleCounter = 0;
        var X = 1;
        var signalStrength = 0;

        int[] specialCycles = new int[] { 20, 60, 100, 140, 180, 220 };

        foreach (var line in File.ReadAllLines(inputFilePath))
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

    public static string Part2(string inputFilePath)
    {
        var cycleCounter = 0;
        var X = 1;

        var framebuffer = new StringBuilder();

        foreach (var line in File.ReadAllLines(inputFilePath))
        {
            var opCode = line.Split(" ")[0];
            switch (opCode)
            {
                case "noop":
                    {
                        cycleCounter++;
                        var crtCurrentPosition = framebuffer.Length % 40;
                        if (crtCurrentPosition == X - 1 || crtCurrentPosition == X || crtCurrentPosition == X + 1)
                        {
                            framebuffer.Append('#');
                        }
                        else
                        {
                            framebuffer.Append('.');
                        }
                    }
                    break;
                case "addx":
                    {
                        cycleCounter++;
                        {
                            var crtCurrentPosition = framebuffer.Length % 40;
                            if (crtCurrentPosition == X - 1 || crtCurrentPosition == X || crtCurrentPosition == X + 1)
                            {
                                framebuffer.Append('#');
                            }
                            else
                            {
                                framebuffer.Append('.');
                            }
                        }
                        cycleCounter++;

                        {
                            var crtCurrentPosition = framebuffer.Length % 40;
                            if (crtCurrentPosition == X - 1 || crtCurrentPosition == X || crtCurrentPosition == X + 1)
                            {
                                framebuffer.Append('#');
                            }
                            else
                            {
                                framebuffer.Append('.');
                            }
                        }

                        var V = int.Parse(line.Split(" ")[1]);
                        X += V;
                    }
                    break;
            }
        }

        return string.Join('\n', PrintCRT(framebuffer));
    }

    public static string[] PrintCRT(StringBuilder framebuffer)
    {
        List<string> tmp = new();
        string tmp2 = framebuffer.ToString();
        for (int x = 0; x < 6; x++)
        {
            tmp.Add(tmp2.Substring(40 * x, 40));
        }
        return tmp.ToArray();
    }
}
