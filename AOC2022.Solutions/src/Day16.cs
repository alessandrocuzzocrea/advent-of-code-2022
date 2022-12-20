using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace AOC2022.Solutions;

public class Day16
{
    public static int Part1(string inputFilePath)
    {
        var valves = new Dictionary<string, (int, List<string>)>();

        string pattern = @"Valve ([A-Z]+) has flow rate=(\d+); (?:tunnel|tunnels) (?:lead|leads) to (?:valve|valves) (.*)";

        var lines = File.ReadAllLines(inputFilePath);
        foreach (var line in lines)
        {
            MatchCollection m = Regex.Matches(line, pattern);

            var valve = m[0].Groups[1].ToString();
            var juice = int.Parse(m[0].Groups[2].ToString());
            var neighbors = m[0].Groups[3].ToString().Split(", ").ToList();

            valves[valve] = (juice, neighbors);
        }

        return new Solver(valves).solve("AA", ImmutableList<string>.Empty, 0, 30, 0);
    }
}

public class Solver
{
    public Solver(Dictionary<string, (int, List<string>)> valves)
    {
        Valves = valves;
    }

    public Dictionary<string, (int, List<string>)> Valves { get; }
    public Dictionary<string, (int, List<string>)> JuicyValves
    {
        get
        {
            return Valves.Where(kvp => kvp.Value.Item1 > 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }

    public int solve(string currentValve, ImmutableList<string> valveOpened, int currentFlow, int timeLimit, int currentTime)
    {
        if (valveOpened.Count == JuicyValves.Count)
        {
            return currentFlow;
        }

        if (currentTime > timeLimit)
        {
            return currentFlow;
        }

        var a = FindNextValveToOpen(currentValve, valveOpened, timeLimit - currentTime);

        var res = new List<int>();

        foreach (var candidate in a)
        {
            var newCurrentTime = currentTime + candidate.Item2;
            var newCurrentFlow = currentFlow + candidate.Item3;
            var newValveOpened = valveOpened.Add(candidate.Item1);

            res.Add(solve(candidate.Item1, newValveOpened, newCurrentFlow, timeLimit, newCurrentTime));
        }

        return res.Count > 0 ? res.Max() : currentFlow;
    }

    public List<(string, int, int)> FindNextValveToOpen(string currValve, ImmutableList<string> valveOpened, int timeLeft)
    {
        List<(string name, int cost, int juice)> candidates = new();

        foreach (var valve in JuicyValves)
        {
            if (!valveOpened.Contains(valve.Key) && valve.Key != currValve)
            {
                var cost = CalculateDistance(currValve, valve.Key) + 1;
                if (cost < timeLeft)
                {
                    var juice = Valves[valve.Key].Item1 * (timeLeft - cost);
                    candidates.Add((valve.Key, cost, juice));
                }
            }
        }

        candidates.Sort((x, y) => y.juice - x.juice);
        return candidates;
    }

    public int CalculateDistance(string currentValve, string targetValve)
    {
        Queue<string> queue = new Queue<string>();
        Dictionary<string, int> visited = new Dictionary<string, int>();

        queue.Enqueue(currentValve);
        visited[currentValve] = 0;

        while (queue.Count > 0)
        {
            string current = queue.Dequeue();

            if (current == targetValve)
            {
                return visited[current];
            }

            List<string> neighbors = Valves[current].Item2;

            foreach (string neighbor in neighbors)
            {
                if (!visited.ContainsKey(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited[neighbor] = visited[current] + 1;
                }
            }
        }

        return -1;
    }
}
