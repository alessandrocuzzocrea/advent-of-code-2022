using static AOC2022.Solutions.Day25;

namespace AOC2023.Tests;

public class Day25Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal("2=-1=0", Part1("./inputs/day25-example"));
    }
}
