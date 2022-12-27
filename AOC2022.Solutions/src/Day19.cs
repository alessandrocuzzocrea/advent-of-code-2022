using System.Text.RegularExpressions;

namespace AOC2022.Solutions;

public class Day19
{
    public static int Part1(string inputFilePath)
    {
        return ParseAllBlueprints(inputFilePath)
                .Sum(b => b.MaximizeGeodes(24));
    }

    public static int Part2(string inputFilePath)
    {
        return ParseAllBlueprints(inputFilePath)
                .Take(3)
                .Select(a => a.MaximizeGeodes2(32))
                .Aggregate(1, (a, b) => a * b);
    }

    public static List<Blueprint> ParseAllBlueprints(string inputFilePath)
    {
        List<Blueprint> blueprints = new();
        string pattern = @"Blueprint (\d+): Each ore robot costs (\d+) ore. Each clay robot costs (\d+) ore. Each obsidian robot costs (\d+) ore and (\d+) clay. Each geode robot costs (\d+) ore and (\d+) obsidian.";

        var lines = File.ReadAllLines(inputFilePath);
        foreach (var line in lines)
        {
            MatchCollection m = Regex.Matches(line, pattern);

            var blueprintId = int.Parse(m[0].Groups[1].ToString());
            var oreRobotOreCost = int.Parse(m[0].Groups[2].ToString());

            var clayRobotOreCost = int.Parse(m[0].Groups[3].ToString());

            var obsidianRobotOreCost = int.Parse(m[0].Groups[4].ToString());
            var obsidianRobotClayCost = int.Parse(m[0].Groups[5].ToString());

            var geodeRobotOreCost = int.Parse(m[0].Groups[6].ToString());
            var geodeRobotObsidianCost = int.Parse(m[0].Groups[7].ToString());

            blueprints.Add(new Blueprint(blueprintId, oreRobotOreCost, clayRobotOreCost, obsidianRobotOreCost, obsidianRobotClayCost, geodeRobotOreCost, geodeRobotObsidianCost));
        }

        return blueprints;
    }

    public class Blueprint
    {
        public int BlueprintId { get; }
        public int OreRobotOreCost { get; }
        public int ClayRobotOreCost { get; }
        public int ObsidianRobotOreCost { get; }
        public int ObsidianRobotClayCost { get; }
        public int GeodeRobotOreCost { get; }
        public int GeodeRobotObsidianCost { get; }

        public Blueprint(int blueprintId, int oreRobotOreCost, int clayRobotOreCost, int obsidianRobotOreCost, int obsidianRobotClayCost, int geodeRobotOreCost, int geodeRobotClayCost)
        {
            BlueprintId = blueprintId;
            OreRobotOreCost = oreRobotOreCost;
            ClayRobotOreCost = clayRobotOreCost;
            ObsidianRobotOreCost = obsidianRobotOreCost;
            ObsidianRobotClayCost = obsidianRobotClayCost;
            GeodeRobotOreCost = geodeRobotOreCost;
            GeodeRobotObsidianCost = geodeRobotClayCost;
        }

        public int MaximizeGeodes(int timeLimit)
        {
            var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();
            var maxGeoBotsMinute = new int[timeLimit + 1];
            Array.Fill(maxGeoBotsMinute, 0);

            var s = CalculateQualityLevel(
                (currentTime: 0,
                timeLimit: timeLimit,
                oreBots: 1,
                clayBots: 0,
                obsidianBots: 0,
                geodeBots: 0,
                ore: 0,
                clay: 0,
                obsidian: 0,
                geodes: 0),
                dp,
                maxGeoBotsMinute
            );

            return s * BlueprintId;
        }

        public int MaximizeGeodes2(int timeLimit)
        {
            var dp = new Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int>();
            var maxGeoBotsMinute = new int[timeLimit + 1];
            Array.Fill(maxGeoBotsMinute, 0);

            var s = CalculateQualityLevel(
                (currentTime: 0,
                timeLimit: timeLimit,
                oreBots: 1,
                clayBots: 0,
                obsidianBots: 0,
                geodeBots: 0,
                ore: 0,
                clay: 0,
                obsidian: 0,
                geodes: 0),
                dp,
                maxGeoBotsMinute
            );

            return s;
        }

        public int CalculateQualityLevel((int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes) s, Dictionary<(int currentTime, int timeLimit, int oreBots, int clayBots, int obsidianBots, int geodeBots, int ore, int clay, int obsidian, int geodes), int> dp, int[] maxGeoBotsMinute)
        {
            if (s.geodes < maxGeoBotsMinute[s.currentTime])
            {
                return -1;
            }
            else
            {
                maxGeoBotsMinute[s.currentTime] = s.geodes;
            }

            if (s.currentTime == s.timeLimit)
            {
                return s.geodes;
            }

            var possible = new List<int>();

            //Decide to do nothing
            {
                var DoNothing =
                    (
                        currentTime: s.currentTime + 1,
                        timeLimit: s.timeLimit,

                        oreBots: s.oreBots,
                        clayBots: s.clayBots,
                        obsidianBots: s.obsidianBots,
                        geodeBots: s.geodeBots,

                        ore: s.ore + s.oreBots,
                        clay: s.clay + s.clayBots,
                        obsidian: s.obsidian + s.obsidianBots,
                        geodes: s.geodes + s.geodeBots
                    );

                if (dp.TryGetValue(DoNothing, out var value2))
                {
                    possible.Add(value2);
                }
                else
                {
                    int value3 = CalculateQualityLevel(DoNothing, dp, maxGeoBotsMinute);
                    dp[DoNothing] = value3;
                    possible.Add(value3);
                }
            }

            //Decide to make a OreRobot
            {
                if (s.ore >= OreRobotOreCost)
                {
                    var MakeAClayBot =
                        (
                            currentTime: s.currentTime + 1,
                            timeLimit: s.timeLimit,

                            oreBots: s.oreBots + 1,
                            clayBots: s.clayBots,
                            obsidianBots: s.obsidianBots,
                            geodeBots: s.geodeBots,

                            ore: s.ore + s.oreBots - OreRobotOreCost,
                            clay: s.clay + s.clayBots,
                            obsidian: s.obsidian + s.obsidianBots,
                            geodes: s.geodes + s.geodeBots
                        );

                    if (dp.TryGetValue(MakeAClayBot, out var value2))
                    {
                        possible.Add(value2);
                    }
                    else
                    {
                        int value3 = CalculateQualityLevel(MakeAClayBot, dp, maxGeoBotsMinute);
                        dp[MakeAClayBot] = value3;
                        possible.Add(value3);
                    }
                }
            }

            //Decide to make a ClayRobot
            {
                if (s.ore >= ClayRobotOreCost)
                {
                    var MakeAClayBot =
                        (
                            currentTime: s.currentTime + 1,
                            timeLimit: s.timeLimit,

                            oreBots: s.oreBots,
                            clayBots: s.clayBots + 1,
                            obsidianBots: s.obsidianBots,
                            geodeBots: s.geodeBots,

                            ore: s.ore + s.oreBots - ClayRobotOreCost,
                            clay: s.clay + s.clayBots,
                            obsidian: s.obsidian + s.obsidianBots,
                            geodes: s.geodes + s.geodeBots
                        );

                    if (dp.TryGetValue(MakeAClayBot, out var value2))
                    {
                        possible.Add(value2);
                    }
                    else
                    {
                        int value3 = CalculateQualityLevel(MakeAClayBot, dp, maxGeoBotsMinute);
                        dp[MakeAClayBot] = value3;
                        possible.Add(value3);
                    }
                }
            }

            //Decide to make an ObsidianBot
            {
                if (s.ore >= ObsidianRobotOreCost && s.clay >= ObsidianRobotClayCost)
                {
                    var MakeAnObsidianBot =
                        (
                            currentTime: s.currentTime + 1,
                            timeLimit: s.timeLimit,

                            oreBots: s.oreBots,
                            clayBots: s.clayBots,
                            obsidianBots: s.obsidianBots + 1,
                            geodeBots: s.geodeBots,

                            ore: s.ore + s.oreBots - ObsidianRobotOreCost,
                            clay: s.clay + s.clayBots - ObsidianRobotClayCost,
                            obsidian: s.obsidian + s.obsidianBots,
                            geodes: s.geodes + s.geodeBots
                        );

                    if (dp.TryGetValue(MakeAnObsidianBot, out var value2))
                    {
                        possible.Add(value2);
                    }
                    else
                    {
                        int value3 = CalculateQualityLevel(MakeAnObsidianBot, dp, maxGeoBotsMinute);
                        dp[MakeAnObsidianBot] = value3;
                        possible.Add(value3);
                    }
                }
            }

            //Decide to make a GeodeRobot
            {
                if (s.ore >= GeodeRobotOreCost && s.obsidian >= GeodeRobotObsidianCost)
                {
                    var MakeAGeodeBot =
                        (
                            currentTime: s.currentTime + 1,
                            timeLimit: s.timeLimit,

                            oreBots: s.oreBots,
                            clayBots: s.clayBots,
                            obsidianBots: s.obsidianBots,
                            geodeBots: s.geodeBots + 1,

                            ore: s.ore + s.oreBots - GeodeRobotOreCost,
                            clay: s.clay + s.clayBots,
                            obsidian: s.obsidian + s.obsidianBots - GeodeRobotObsidianCost,
                            geodes: s.geodes + s.geodeBots
                        );

                    if (dp.TryGetValue(MakeAGeodeBot, out var value2))
                    {
                        possible.Add(value2);
                    }
                    else
                    {
                        int value3 = CalculateQualityLevel(MakeAGeodeBot, dp, maxGeoBotsMinute);
                        dp[MakeAGeodeBot] = value3;
                        possible.Add(value3);
                    }
                }
            }
            return possible.Max();
        }
    }
}
