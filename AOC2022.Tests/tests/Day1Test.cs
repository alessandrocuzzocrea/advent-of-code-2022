using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day1Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(24000, Day1.Part1("./inputs/day1-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(45000, Day1.Part2("./inputs/day1-example"));
    }
}
