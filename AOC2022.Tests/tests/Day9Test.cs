using AOC2022.Solutions;
using static AOC2022.Solutions.Day9;

namespace AOC2022.Tests;

public class Day9Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(13, Day9.Part1("./inputs/day9-example"));
    }

    // [Fact]
    // public void Part2_IsCorrect_WhenUsingExampleInputFile()
    // {
    //     Assert.Equal(24933642, Day7.Part2("./inputs/day7-example"));
    // }

    [Fact]
    public void Rope_TailMovementsAreCorrect()
    {
        Rope rope = new(2, 0, 4);

        Assert.Equal((0, 4), rope._head.GetPosition());
        Assert.Equal((0, 4), rope.Tails[1].GetPosition());
        Assert.Equal(1, rope.Visited());

        // == R 4 ==
        rope.MoveHead("R", 1);
        Assert.Equal((1, 4), rope._head.GetPosition());
        Assert.Equal((0, 4), rope.Tails[1].GetPosition());
        Assert.Equal(1, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((2, 4), rope._head.GetPosition());
        Assert.Equal((1, 4), rope.Tails[1].GetPosition());
        Assert.Equal(2, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((3, 4), rope._head.GetPosition());
        Assert.Equal((2, 4), rope.Tails[1].GetPosition());
        Assert.Equal(3, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((4, 4), rope._head.GetPosition());
        Assert.Equal((3, 4), rope.Tails[1].GetPosition());
        Assert.Equal(4, rope.Visited());

        // == U 4 ==
        rope.MoveHead("U", 1);
        Assert.Equal((4, 3), rope._head.GetPosition());
        Assert.Equal((3, 4), rope.Tails[1].GetPosition());
        Assert.Equal(4, rope.Visited());
    }

    [Fact]
    public void Rope_KnotsAreTouching_WhenOverlaps()
    {
        Rope rope = new(2);
        rope._head.setPosition(0, 4);
        rope.Tails[1].setPosition(0, 4);

        Assert.True(rope.KnotsTouching(rope._head, rope.Tails[1]));
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(3, 2)]
    [InlineData(3, 3)]
    [InlineData(2, 3)]
    [InlineData(1, 3)]
    [InlineData(1, 2)]
    [InlineData(1, 1)]
    public void Rope_KnotsAreTouching(int xHead, int yHead)
    {
        Rope rope = new(2);
        rope.Tails[1].setPosition(2, 2);
        rope._head.setPosition(xHead, yHead);
        Assert.True(rope.KnotsTouching(rope._head, rope.Tails[1]));
    }

    [Theory]
    [InlineData(2, 0)]
    [InlineData(3, 0)]
    [InlineData(4, 0)]
    [InlineData(5, 1)]
    [InlineData(5, 2)]
    [InlineData(5, 3)]
    [InlineData(2, 4)]
    [InlineData(3, 4)]
    [InlineData(4, 4)]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    [InlineData(0, 3)]
    public void Rope_KnotsAreNotTouching(int xHead, int yHead)
    {
        Rope rope = new(2);
        rope.Tails[1].setPosition(2, 2);
        rope._head.setPosition(xHead, yHead);
        Assert.False(rope.KnotsTouching(rope._head, rope.Tails[1]));
    }
}
