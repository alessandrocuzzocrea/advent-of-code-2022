using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day14Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(24, Day14.Part1("./inputs/day14-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(93, Day14.Part2("./inputs/day14-example"));
    }

}
