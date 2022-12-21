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

        var directions = new List<(int x, int y, int z)>
        {
            ( x: 1, y: 0, z: 0 ),
            ( x: -1,y : 0,z : 0 ),
            ( x: 0, y: 1, z: 0 ),
            ( x: 0, y: -1,z : 0 ),
            ( x: 0, y: 0, z: 1 ),
            ( x: 0, y: 0, z: -1)
        };

        foreach (var (x, y, z) in cubes)
        {
            foreach (var direction in directions)
            {
                if (!cubes.Contains((x + direction.x, y + direction.y, z + direction.z)))
                {
                    faces++;
                }
            }
        }

        return faces;
    }
}
