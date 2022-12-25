using static AOC2022.Solutions.Day22;

namespace AOC2022.Tests;

public class Day22Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(6032, Part1("./inputs/day22-example"));
    }
}
