using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day4Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(2, Day4.Part1("./inputs/day4-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(4, Day4.Part2("./inputs/day4-example"));
    }
}
