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

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(1, Day9.Part2("./inputs/day9-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile2()
    {
        Assert.Equal(36, Day9.Part2("./inputs/day9-example2"));
    }

    [Fact]
    public void Rope_TailMovementsAreCorrect_ForPart1InputFile()
    {
        Rope rope = new(2, 0, 4);

        Assert.Equal((0, 4), rope.Head.GetPosition());
        Assert.Equal((0, 4), rope.Tails[1].GetPosition());
        Assert.Equal(1, rope.Visited());

        // == R 4 ==
        rope.MoveHead("R", 1);
        Assert.Equal((1, 4), rope.Head.GetPosition());
        Assert.Equal((0, 4), rope.Tails[1].GetPosition());
        Assert.Equal(1, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((2, 4), rope.Head.GetPosition());
        Assert.Equal((1, 4), rope.Tails[1].GetPosition());
        Assert.Equal(2, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((3, 4), rope.Head.GetPosition());
        Assert.Equal((2, 4), rope.Tails[1].GetPosition());
        Assert.Equal(3, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((4, 4), rope.Head.GetPosition());
        Assert.Equal((3, 4), rope.Tails[1].GetPosition());
        Assert.Equal(4, rope.Visited());

        // == U 4 ==
        rope.MoveHead("U", 1);
        Assert.Equal((4, 3), rope.Head.GetPosition());
        Assert.Equal((3, 4), rope.Tails[1].GetPosition());
        Assert.Equal(4, rope.Visited());
    }

    [Fact]
    public void Rope_TailMovementsAreCorrect_ForPart2InputFile()
    {
        Rope rope = new(10, 0, 4);

        Assert.Equal((0, 4), rope.Head.GetPosition());
        Assert.Equal((0, 4), rope.Tails[1].GetPosition());
        Assert.Equal((0, 4), rope.Tails[2].GetPosition());
        Assert.Equal((0, 4), rope.Tails[3].GetPosition());
        Assert.Equal((0, 4), rope.Tails[4].GetPosition());
        Assert.Equal((0, 4), rope.Tails[5].GetPosition());
        Assert.Equal((0, 4), rope.Tails[6].GetPosition());
        Assert.Equal((0, 4), rope.Tails[7].GetPosition());
        Assert.Equal((0, 4), rope.Tails[8].GetPosition());
        Assert.Equal((0, 4), rope.Tails[9].GetPosition());
        Assert.Equal(1, rope.Visited());

        // == R 4 ==
        rope.MoveHead("R", 1);
        Assert.Equal((1, 4), rope.Head.GetPosition());
        Assert.Equal((0, 4), rope.Tails[1].GetPosition());
        Assert.Equal((0, 4), rope.Tails[2].GetPosition());
        Assert.Equal((0, 4), rope.Tails[3].GetPosition());
        Assert.Equal((0, 4), rope.Tails[4].GetPosition());
        Assert.Equal((0, 4), rope.Tails[5].GetPosition());
        Assert.Equal((0, 4), rope.Tails[6].GetPosition());
        Assert.Equal((0, 4), rope.Tails[7].GetPosition());
        Assert.Equal((0, 4), rope.Tails[8].GetPosition());
        Assert.Equal((0, 4), rope.Tails[9].GetPosition());
        Assert.Equal(1, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((2, 4), rope.Head.GetPosition());
        Assert.Equal((1, 4), rope.Tails[1].GetPosition());
        Assert.Equal((0, 4), rope.Tails[2].GetPosition());
        Assert.Equal((0, 4), rope.Tails[3].GetPosition());
        Assert.Equal((0, 4), rope.Tails[4].GetPosition());
        Assert.Equal((0, 4), rope.Tails[5].GetPosition());
        Assert.Equal((0, 4), rope.Tails[6].GetPosition());
        Assert.Equal((0, 4), rope.Tails[7].GetPosition());
        Assert.Equal((0, 4), rope.Tails[8].GetPosition());
        Assert.Equal((0, 4), rope.Tails[9].GetPosition());
        Assert.Equal(1, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((3, 4), rope.Head.GetPosition());
        Assert.Equal((2, 4), rope.Tails[1].GetPosition());
        Assert.Equal((1, 4), rope.Tails[2].GetPosition());
        Assert.Equal((0, 4), rope.Tails[3].GetPosition());
        Assert.Equal((0, 4), rope.Tails[4].GetPosition());
        Assert.Equal((0, 4), rope.Tails[5].GetPosition());
        Assert.Equal((0, 4), rope.Tails[6].GetPosition());
        Assert.Equal((0, 4), rope.Tails[7].GetPosition());
        Assert.Equal((0, 4), rope.Tails[8].GetPosition());
        Assert.Equal((0, 4), rope.Tails[9].GetPosition());
        Assert.Equal(1, rope.Visited());

        rope.MoveHead("R", 1);
        Assert.Equal((4, 4), rope.Head.GetPosition());
        Assert.Equal((3, 4), rope.Tails[1].GetPosition());
        Assert.Equal((2, 4), rope.Tails[2].GetPosition());
        Assert.Equal((1, 4), rope.Tails[3].GetPosition());
        Assert.Equal((0, 4), rope.Tails[4].GetPosition());
        Assert.Equal((0, 4), rope.Tails[5].GetPosition());
        Assert.Equal((0, 4), rope.Tails[6].GetPosition());
        Assert.Equal((0, 4), rope.Tails[7].GetPosition());
        Assert.Equal((0, 4), rope.Tails[8].GetPosition());
        Assert.Equal((0, 4), rope.Tails[9].GetPosition());
        Assert.Equal(1, rope.Visited());

        // == U 4 ==
        rope.MoveHead("U", 1);
        Assert.Equal((4, 3), rope.Head.GetPosition());
        Assert.Equal((3, 4), rope.Tails[1].GetPosition());
        Assert.Equal((2, 4), rope.Tails[2].GetPosition());
        Assert.Equal((1, 4), rope.Tails[3].GetPosition());
        Assert.Equal((0, 4), rope.Tails[4].GetPosition());
        Assert.Equal((0, 4), rope.Tails[5].GetPosition());
        Assert.Equal((0, 4), rope.Tails[6].GetPosition());
        Assert.Equal((0, 4), rope.Tails[7].GetPosition());
        Assert.Equal((0, 4), rope.Tails[8].GetPosition());
        Assert.Equal((0, 4), rope.Tails[9].GetPosition());
        Assert.Equal(1, rope.Visited());

        rope.MoveHead("U", 1);
        Assert.Equal((4, 2), rope.Head.GetPosition());
        Assert.Equal((4, 3), rope.Tails[1].GetPosition());
        Assert.Equal((3, 3), rope.Tails[2].GetPosition());
        Assert.Equal((2, 3), rope.Tails[3].GetPosition());
        Assert.Equal((1, 3), rope.Tails[4].GetPosition());
        Assert.Equal((0, 4), rope.Tails[5].GetPosition());
        Assert.Equal((0, 4), rope.Tails[6].GetPosition());
        Assert.Equal((0, 4), rope.Tails[7].GetPosition());
        Assert.Equal((0, 4), rope.Tails[8].GetPosition());
        Assert.Equal((0, 4), rope.Tails[9].GetPosition());
        Assert.Equal(1, rope.Visited());

        rope.MoveHead("U", 1);

        rope.MoveHead("U", 1);


    }

    [Fact]
    public void Rope_KnotsAreTouching_WhenOverlaps()
    {
        Rope rope = new(2);
        rope.Head.setPosition(0, 4);
        rope.Tails[1].setPosition(0, 4);

        Assert.True(Rope.KnotsTouching(rope.Head, rope.Tails[1]));
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
        rope.Head.setPosition(xHead, yHead);
        Assert.True(Rope.KnotsTouching(rope.Head, rope.Tails[1]));
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
        rope.Head.setPosition(xHead, yHead);
        Assert.False(Rope.KnotsTouching(rope.Head, rope.Tails[1]));
    }
}
