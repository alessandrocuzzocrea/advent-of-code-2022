using AOC2022.Solutions;

namespace AOC2022.Tests;

public class UnitTestDay5
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal("CMZ", Day5.Part1("./inputs/day5-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal("MCD", Day5.Part2("./inputs/day5-example"));
    }
}
