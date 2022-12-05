using AOC2022.Solutions;

namespace AOC2022.Tests;

public class UnitTestDay2
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(15, Day2.Part1("./inputs/day2-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(12, Day2.Part2("./inputs/day2-example"));
    }
}
