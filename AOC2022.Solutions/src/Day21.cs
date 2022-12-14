namespace AOC2022.Solutions;

public class Day21
{
    public static long Part1(string inputFilePath)
    {
        Dictionary<string, long> values = new();
        Dictionary<string, string> operations = new();

        foreach (string line in File.ReadLines(inputFilePath))
        {
            string[] parts = line.Split(": ");

            string monkey = parts[0];
            string equation = parts[1];

            if (int.TryParse(equation, out int value))
            {
                values[monkey] = value;
            }
            else
            {
                operations[monkey] = equation;
            }
        }

        HashSet<string> processed = new HashSet<string>();

        long Evaluate(string monkey)
        {
            if (values.ContainsKey(monkey) || processed.Contains(monkey))
            {
                return values[monkey];
            }

            string[] operands = operations[monkey].Split();
            var result = operands[1] switch
            {
                "+" => Evaluate(operands[0]) + Evaluate(operands[2]),
                "-" => Evaluate(operands[0]) - Evaluate(operands[2]),
                "*" => Evaluate(operands[0]) * Evaluate(operands[2]),
                "/" => Evaluate(operands[0]) / Evaluate(operands[2]),
                _ => throw new ArgumentException($"Invalid operator: {operands[1]}"),
            };
            values[monkey] = result;
            processed.Add(monkey);
            return result;
        }

        return Evaluate("root");
    }
}
