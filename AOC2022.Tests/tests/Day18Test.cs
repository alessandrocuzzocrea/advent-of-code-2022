using static AOC2022.Solutions.Day18;

namespace AOC2022.Tests;

public class Day18Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(64, Part1("./inputs/day18-example"));
    }
}
