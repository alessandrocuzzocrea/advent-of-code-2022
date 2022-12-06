using AOC2022.Solutions;

namespace AOC2022.Tests;

public class UnitTestDay6
{
    // [Fact]
    // public void Part1_IsCorrect_WhenUsingExampleInputFile()
    // {
    //     Assert.Equal("CMZ", Day6.Part1("./inputs/day6-example"));
    // }

    // [Fact]
    // public void Part2_IsCorrect_WhenUsingExampleInputFile()
    // {
    //     Assert.Equal("MCD", Day6.Part2("./inputs/day6-example"));
    // }

    [Fact]
    public void RenameMe_ReturnsTheCorrectValue() {
       Assert.Equal(7, Day6.RenameMe("mjqjpqmgbljsphdztnvjfqwrcgsmlb"));
       Assert.Equal(5, Day6.RenameMe("bvwbjplbgvbhsrlpgdmjqwftvncz"));
       Assert.Equal(6, Day6.RenameMe("nppdvjthqldpwncqszvftbrmjlhg"));
       Assert.Equal(10, Day6.RenameMe("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"));
       Assert.Equal(11, Day6.RenameMe("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"));
    }
}
