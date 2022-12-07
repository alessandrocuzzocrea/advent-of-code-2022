using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day6Test
{
    [Fact]
    public void DetectMarker_ReturnsTheCorrectValue_WhenLookAhead4()
    {
        Assert.Equal(7, Day6.DetectMarker("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4));
        Assert.Equal(5, Day6.DetectMarker("bvwbjplbgvbhsrlpgdmjqwftvncz", 4));
        Assert.Equal(6, Day6.DetectMarker("nppdvjthqldpwncqszvftbrmjlhg", 4));
        Assert.Equal(10, Day6.DetectMarker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4));
        Assert.Equal(11, Day6.DetectMarker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4));
    }

    [Fact]
    public void DetectMarker_ReturnsTheCorrectValue_WhenLookAhead14()
    {
        Assert.Equal(19, Day6.DetectMarker("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14));
        Assert.Equal(23, Day6.DetectMarker("bvwbjplbgvbhsrlpgdmjqwftvncz", 14));
        Assert.Equal(23, Day6.DetectMarker("nppdvjthqldpwncqszvftbrmjlhg", 14));
        Assert.Equal(29, Day6.DetectMarker("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14));
        Assert.Equal(26, Day6.DetectMarker("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14));
    }
}
