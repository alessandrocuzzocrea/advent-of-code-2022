using AOC2022.Solutions;
using static AOC2022.Solutions.Day19;

namespace AOC2022.Tests;

public class Day19Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(33, Part1("./inputs/day19-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(56 * 62, Part2("./inputs/day19-example"));
    }

    [Fact]
    public void Part2_IsCorrect_ForBlueprint1()
    {
        List<Blueprint> b = ParseAllBlueprints("./inputs/day19-example");
        Assert.Equal(56, b[0].MaximizeGeodes2(32));
    }

    [Fact]
    public void Part2_IsCorrect_ForBlueprint2()
    {
        List<Blueprint> b = ParseAllBlueprints("./inputs/day19-example");
        Assert.Equal(62, b[1].MaximizeGeodes2(32));
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 0)]
    [InlineData(3, 0)]
    [InlineData(4, 0)]
    [InlineData(5, 0)]
    [InlineData(6, 0)]
    [InlineData(7, 0)]
    [InlineData(8, 0)]
    [InlineData(9, 0)]
    [InlineData(10, 0)]
    [InlineData(11, 0)]
    [InlineData(12, 0)]
    [InlineData(13, 0)]
    [InlineData(14, 0)]
    [InlineData(15, 0)]
    [InlineData(16, 0)]
    [InlineData(17, 0)]
    [InlineData(18, 0)]
    [InlineData(19, 1)]
    [InlineData(20, 2)]
    [InlineData(21, 3)]
    [InlineData(22, 5)]
    [InlineData(23, 7)]
    [InlineData(24, 9)]
    public void Part1_ExampleBlueprint1(int minutes, int geodes)
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");
        var omar1 = blueprints[0].MaximizeGeodes(minutes);
        Assert.Equal(geodes, omar1);
    }

    [Fact]
    public void TestLoller24()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 24,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 4,
            obsidianBots: 2,
            geodeBots: 2,
            ore: 6,
            clay: 41,
            obsidian: 8,
            geodes: 9
        );
        var maxGeoBotsMinute = new int[24 + 1];
        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }

    [Fact]
    public void TestLoller23()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 23,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 4,
            obsidianBots: 2,
            geodeBots: 2,
            ore: 5,
            clay: 37,
            obsidian: 6,
            geodes: 7
        );
        var maxGeoBotsMinute = new int[24 + 1];
        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }

    [Fact]
    public void TestLoller22()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 22,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 4,
            obsidianBots: 2,
            geodeBots: 2,
            ore: 4,
            clay: 33,
            obsidian: 4,
            geodes: 5
        );
        var maxGeoBotsMinute = new int[24 + 1];
        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }

    [Fact]
    public void TestLoller21()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 21,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 4,
            obsidianBots: 2,
            geodeBots: 2,
            ore: 3,
            clay: 29,
            obsidian: 2,
            geodes: 3
        );
        var maxGeoBotsMinute = new int[24 + 1];
        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }

    [Fact]
    public void TestLoller20()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 20,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 4,
            obsidianBots: 2,
            geodeBots: 1,
            ore: 4,
            clay: 25,
            obsidian: 7,
            geodes: 2
        );
        var maxGeoBotsMinute = new int[24 + 1];
        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }

    [Fact]
    public void TestLoller19()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 19,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 4,
            obsidianBots: 2,
            geodeBots: 1,
            ore: 3,
            clay: 21,
            obsidian: 5,
            geodes: 1
        );
        var maxGeoBotsMinute = new int[24 + 1];
        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }

    [Fact]
    public void TestLoller11()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 11,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 3,
            obsidianBots: 1,
            geodeBots: 0,
            ore: 2,
            clay: 4,
            obsidian: 0,
            geodes: 0
        );
        var maxGeoBotsMinute = new int[24 + 1];
        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }

    [Fact]
    public void TestLoller3()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 3,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 1,
            obsidianBots: 0,
            geodeBots: 0,
            ore: 1,
            clay: 0,
            obsidian: 0,
            geodes: 0
        );

        var maxGeoBotsMinute = new int[24 + 1];

        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }

    [Fact]
    public void TestLoller2()
    {
        List<Blueprint> blueprints = ParseAllBlueprints("./inputs/day19-example");

        var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();

        var s =
        (
            currentTime: 2,
            timeLimit: 24,
            oreBots: 1,
            clayBots: 0,
            obsidianBots: 0,
            geodeBots: 0,
            ore: 2,
            clay: 0,
            obsidian: 0,
            geodes: 0
        );

        var maxGeoBotsMinute = new int[24 + 1];

        var omar1 = blueprints[0].CalculateQualityLevel(s, dp, maxGeoBotsMinute);
        Assert.Equal(9, omar1);
    }
}
