using AOC2022.Solutions;

namespace AOC2022.Tests;

public class UnitTestDay2
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingInputFile()
    {
        Assert.Equal(Day2.Part1("./inputs/day2"), 11873);
    }

    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(Day2.Part1("./inputs/day2-example"), 15);
    }
}
