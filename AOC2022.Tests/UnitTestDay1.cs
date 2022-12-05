using AOC2022.Solutions;

namespace AOC2022.Tests;

public class UnitTestDay1
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingInputFile()
    {
        Assert.Equal(Day1.Part1("./inputs/day1"), 68442);
    }

    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(Day1.Part1("./inputs/day1-example"), 24000);
    }
}
