using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day8Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(21, Day8.Part1("./inputs/day8-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(8, Day8.Part2("./inputs/day8-example"));
    }
}
