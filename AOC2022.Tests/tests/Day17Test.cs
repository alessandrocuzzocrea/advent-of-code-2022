using static AOC2022.Solutions.Day17;

namespace AOC2022.Tests;

public class Day17Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(3068, Part1("./inputs/day17-example", 2022));
    }

    [Fact]
    public void Rock1_Test1()
    {
        var c = new Chamber();
        var r = c.Rocks[0];

        Assert.Equal('#', r[0, 0]);
        Assert.Equal('#', r[1, 0]);
        Assert.Equal('#', r[2, 0]);
        Assert.Equal('#', r[3, 0]);
    }

    [Fact]
    public void Rock1_Test2()
    {
        var c = new Chamber();
        var r = c.Rocks[0];

        Assert.Equal(4, r.Width);
        Assert.Equal(1, r.Height);
    }

    [Fact]
    public void Rock1_Test3()
    {
        var c = new Chamber();
        var r = c.Rocks[0];

        Assert.Equal(3, r.RightEdge());
    }

    [Fact]
    public void Rock1_Test4()
    {
        var c = new Chamber();
        var r = c.Rocks[0];

        var set = r.ToChamberSpace(0, 0);

        Assert.Contains((0, 0), set);
        Assert.Contains((1, 0), set);
        Assert.Contains((2, 0), set);
        Assert.Contains((3, 0), set);

        set = r.ToChamberSpace(0, 1);

        Assert.Contains((0, 1), set);
        Assert.Contains((1, 1), set);
        Assert.Contains((2, 1), set);
        Assert.Contains((3, 1), set);

        set = r.ToChamberSpace(1, 0);

        Assert.Contains((1, 0), set);
        Assert.Contains((2, 0), set);
        Assert.Contains((3, 0), set);
        Assert.Contains((4, 0), set);

        set = r.ToChamberSpace(1, 1);

        Assert.Contains((1, 1), set);
        Assert.Contains((2, 1), set);
        Assert.Contains((3, 1), set);
        Assert.Contains((4, 1), set);
    }

    [Fact]
    public void Rock1_Test5()
    {
        var c = new Chamber
        {
            CurrentRock = 0
        };

        Assert.False(c.CheckWallCollisions(0, 0));
        Assert.True(c.CheckWallCollisions(-1, 0));
        Assert.True(c.CheckWallCollisions(4, 0));
    }

    [Fact]
    public void Rock2_Test1()
    {
        var c = new Chamber();
        var r = c.Rocks[1];

        Assert.Equal('.', r[0, 0]);
        Assert.Equal('#', r[1, 0]);
        Assert.Equal('.', r[2, 0]);

        Assert.Equal('#', r[0, 1]);
        Assert.Equal('#', r[1, 1]);
        Assert.Equal('#', r[2, 1]);

        Assert.Equal('.', r[0, 2]);
        Assert.Equal('#', r[1, 2]);
        Assert.Equal('.', r[2, 2]);
    }

    [Fact]
    public void Rock2_Test2()
    {
        var c = new Chamber();
        var r = c.Rocks[1];

        Assert.Equal(3, r.Width);
        Assert.Equal(3, r.Height);
    }

    [Fact]
    public void Rock2_Test3()
    {
        var c = new Chamber();
        var r = c.Rocks[1];

        Assert.Equal(2, r.RightEdge());
    }

    [Fact]
    public void Rock2_Test4()
    {
        var c = new Chamber();
        var r = c.Rocks[1];

        var set = r.ToChamberSpace(0, 0);
        Assert.Contains((1, 0), set);
        Assert.Contains((0, 1), set);
        Assert.Contains((1, 1), set);
        Assert.Contains((2, 1), set);
        Assert.Contains((1, 2), set);

        set = r.ToChamberSpace(0, 1);
        Assert.Contains((1, 0 + 1), set);
        Assert.Contains((0, 1 + 1), set);
        Assert.Contains((1, 1 + 1), set);
        Assert.Contains((2, 1 + 1), set);
        Assert.Contains((1, 2 + 1), set);

        set = r.ToChamberSpace(1, 0);
        Assert.Contains((1 + 1, 0), set);
        Assert.Contains((0 + 1, 1), set);
        Assert.Contains((1 + 1, 1), set);
        Assert.Contains((2 + 1, 1), set);
        Assert.Contains((1 + 1, 2), set);

        set = r.ToChamberSpace(1, 1);
        Assert.Contains((1 + 1, 0 + 1), set);
        Assert.Contains((0 + 1, 1 + 1), set);
        Assert.Contains((1 + 1, 1 + 1), set);
        Assert.Contains((2 + 1, 1 + 1), set);
        Assert.Contains((1 + 1, 2 + 1), set);
    }

    [Fact]
    public void Rock2_Test5()
    {
        var c = new Chamber
        {
            CurrentRock = 1
        };

        Assert.False(c.CheckWallCollisions(0, 0));
        Assert.True(c.CheckWallCollisions(-1, 0));
        Assert.True(c.CheckWallCollisions(5, 0));
    }

    [Fact]
    public void Rock3_Test1()
    {
        var c = new Chamber();
        var r = c.Rocks[2];

        Assert.Equal('#', r[0, 0]);
        Assert.Equal('#', r[1, 0]);
        Assert.Equal('#', r[2, 0]);

        Assert.Equal('.', r[0, 1]);
        Assert.Equal('.', r[1, 1]);
        Assert.Equal('#', r[2, 1]);

        Assert.Equal('.', r[0, 2]);
        Assert.Equal('.', r[1, 2]);
        Assert.Equal('#', r[2, 2]);
    }

    [Fact]
    public void Rock3_Test2()
    {
        var c = new Chamber();
        var r = c.Rocks[2];

        Assert.Equal(3, r.Width);
        Assert.Equal(3, r.Height);
    }

    [Fact]
    public void Rock3_Test3()
    {
        var c = new Chamber();
        var r = c.Rocks[1];

        Assert.Equal(2, r.RightEdge());
    }

    [Fact]
    public void Rock4_Test1()
    {
        var c = new Chamber();
        var r = c.Rocks[3];

        Assert.Equal('#', r[0, 0]);
        Assert.Equal('#', r[0, 1]);
        Assert.Equal('#', r[0, 2]);
        Assert.Equal('#', r[0, 3]);
    }

    [Fact]
    public void Rock4_Test2()
    {
        var c = new Chamber();
        var r = c.Rocks[3];

        Assert.Equal(1, r.Width);
        Assert.Equal(4, r.Height);
    }

    [Fact]
    public void Rock4_Test3()
    {
        var c = new Chamber();
        var r = c.Rocks[3];

        Assert.Equal(0, r.RightEdge());
    }

    [Fact]
    public void Rock5_Test1()
    {
        var c = new Chamber();
        var r = c.Rocks[4];

        Assert.Equal('#', r[0, 0]);
        Assert.Equal('#', r[1, 0]);
        Assert.Equal('#', r[0, 1]);
        Assert.Equal('#', r[1, 1]);
    }

    [Fact]
    public void Rock5_Test2()
    {
        var c = new Chamber();
        var r = c.Rocks[4];

        Assert.Equal(2, r.Width);
        Assert.Equal(2, r.Height);
    }

    [Fact]
    public void Rock5_Test3()
    {
        var c = new Chamber();
        var r = c.Rocks[4];

        Assert.Equal(1, r.RightEdge());
    }
}
