using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day11Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(10605, Day11.Part1("./inputs/day11-example"));
    }
}
