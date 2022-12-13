using AOC2022.Solutions;
using static AOC2022.Solutions.Day12;

namespace AOC2022.Tests;

public class Day12Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(31, Day12.Part1("./inputs/day12-example"));
    }

    [Fact]
    public void Direction_EqualityIsCorrect_WhenDirectionsAreEqual()
    {
        Assert.Equal(new Direction { x = 0, y = 0 }, new Direction { x = 0, y = 0 });
        Assert.Equal(new Direction { x = 1, y = 0 }, new Direction { x = 1, y = 0 });
        Assert.Equal(new Direction { x = 0, y = 1 }, new Direction { x = 0, y = 1 });
    }

    [Fact]
    public void Direction_EqualityIsCorrect_WhenDirectionsAreNotEqual()
    {
        Assert.NotEqual(new Direction { x = 0, y = 0 }, new Direction { x = 1, y = 1 });
        Assert.NotEqual(new Direction { x = 1, y = 0 }, new Direction { x = 0, y = 1 });
        Assert.NotEqual(new Direction { x = 0, y = 1 }, new Direction { x = 1, y = 0 });
    }

    [Fact]
    public void HeightMap_InitializationIsCorrect_WhenUsingExampleInputFile()
    {
        var map = new HeightMap(File.ReadAllLines("./inputs/day12-example"));

        Assert.Equal(8, map.Width);
        Assert.Equal(5, map.Height);

        Assert.Equal((0, 0), map.S);
        Assert.Equal((5, 2), map.E);
    }

    [Fact]
    public void GetCharacter()
    {
        var map = new HeightMap(File.ReadAllLines("./inputs/day12-example"));

        Assert.Equal('S', map.GetCharacter(0, 0));
        Assert.Equal('E', map.GetCharacter(5, 2));
        Assert.Equal('a', map.GetCharacter(1, 0));
    }

    [Fact]
    public void CanMove()
    {
        var map = new HeightMap(File.ReadAllLines("./inputs/day12-example"));

        //S -> a
        Assert.True(map.CanMove(new Direction { x = 0, y = 0 }, new Direction { x = 1, y = 0 }));

        //S -> b
        Assert.True(map.CanMove(new Direction { x = 0, y = 0 }, new Direction { x = 1, y = 1 }));

        //a -> b
        Assert.True(map.CanMove(new Direction { x = 1, y = 0 }, new Direction { x = 2, y = 0 }));

        //z -> E
        Assert.True(map.CanMove(new Direction { x = 4, y = 2 }, new Direction { x = 5, y = 2 }));

        //y -> E
        Assert.True(map.CanMove(new Direction { x = 4, y = 1 }, new Direction { x = 5, y = 2 }));
    }

    [Fact]
    public void CantMove()
    {
        var map = new HeightMap(File.ReadAllLines("./inputs/day12-example"));

        //b -> q
        Assert.False(map.CanMove(new Direction { x = 2, y = 0 }, new Direction { x = 3, y = 0 }));

        //S -> c
        Assert.False(map.CanMove(new Direction { x = 0, y = 0 }, new Direction { x = 2, y = 1 }));

        //y -> z
        Assert.False(map.CanMove(new Direction { x = 0, y = 0 }, new Direction { x = 2, y = 1 }));

        //z -> E
        // char z = map.GetCharacter(4, 2);
        // char E = map.GetCharacter(5, 2);
    }
}
