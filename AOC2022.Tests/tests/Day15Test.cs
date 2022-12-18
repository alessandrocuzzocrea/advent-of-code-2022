using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day15Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(26, Day15.Part1("./inputs/day15-example", 10));
    }
}
