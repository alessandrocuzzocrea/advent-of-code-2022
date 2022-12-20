using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day16Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(1651, Day16.Part1("./inputs/day16-example"));
    }
}
