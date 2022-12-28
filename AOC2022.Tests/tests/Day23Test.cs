using static AOC2022.Solutions.Day23;

namespace AOC2023.Tests;

public class Day23Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(110, Part1("./inputs/day23-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(20, Part2("./inputs/day23-example"));
    }

    [Fact]
    public void Part1_Example2_InitialState_Result()
    {
        Assert.Equal(3, Solve("./inputs/day23-example2", 0));
    }

    [Fact]
    public void Part1_Example2_AfterRound1_Result()
    {
        Assert.Equal(5, Solve("./inputs/day23-example2", 1));
    }

    [Fact]
    public void Part1_Example2_AfterRound2_Result()
    {
        Assert.Equal(15, Solve("./inputs/day23-example2", 2));
    }

    [Fact]
    public void Part1_Example2_AfterRound3_Result()
    {
        Assert.Equal(25, Solve("./inputs/day23-example2", 3));
    }

    [Fact]
    public void Part1_Example2_AfterRound4_Result()
    {
        Assert.Equal(25, Solve("./inputs/day23-example2", 4));
    }
}
