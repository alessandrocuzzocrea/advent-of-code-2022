using AOC2022.Solutions;

namespace AOC2022.Tests;

public class UnitTestDay7
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(95437, Day7.Part1("./inputs/day7-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(24933642, Day7.Part2("./inputs/day7-example"));
    }
}
