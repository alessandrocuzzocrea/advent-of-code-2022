using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace AOC2022.Solutions;

public class Day18
{
    public static int Part1(string inputFilePath)
    {
        var cubes = new HashSet<(int x, int y, int z)>();

        var faces = 0;

        var lines = File.ReadAllLines(inputFilePath);
        foreach (var line in lines)
        {
            var coords = line.Split(',');

            cubes.Add((
                x: int.Parse(coords[0]),
                y: int.Parse(coords[1]),
                z: int.Parse(coords[2])
            ));
        }

        foreach (var (x, y, z) in cubes)
        {
            //Top
            if (!cubes.Contains((x, y + 1, z)))
            {
                faces++;
            }

            //Bottom
            if (!cubes.Contains((x, y - 1, z)))
            {
                faces++;
            }

            //Front
            if (!cubes.Contains((x, y, z + 1)))
            {
                faces++;
            }

            //Back
            if (!cubes.Contains((x, y, z - 1)))
            {
                faces++;
            }

            //Left
            if (!cubes.Contains((x - 1, y, z)))
            {
                faces++;
            }

            //Right
            if (!cubes.Contains((x + 1, y, z)))
            {
                faces++;
            }
        }

        return faces;
    }
}
