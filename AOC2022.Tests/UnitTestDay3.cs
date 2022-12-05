using AOC2022.Solutions;

namespace AOC2022.Tests;

public class UnitTestDay3
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(157, Day3.Part1("./inputs/day3-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(70, Day3.Part2("./inputs/day3-example"));
    }
}
