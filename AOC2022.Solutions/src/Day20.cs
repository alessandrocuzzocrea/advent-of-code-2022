namespace AOC2022.Solutions;

public class Day20
{
    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var mixer = new Mixer(lines);
        for (int i = 0; i < lines.Length; i++)
        {
            mixer.Mix();
        }

        return mixer.CalculateGrooveCoordinates();
    }

    public class Mixer
    {
        public List<(int, int)> originalNumbers = new();
        public List<(int, int)> mixedNumbers = new();

        private int currentIndex = 0;

        public Mixer(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                originalNumbers.Add((i, int.Parse(line)));
                mixedNumbers.Add((i, int.Parse(line)));
            }
        }

        public void Mix()
        {
            var i = currentIndex;

            (int, int) currentItem = originalNumbers[i];
            int number = currentItem.Item2;
            int index = mixedNumbers.IndexOf(currentItem);
            mixedNumbers.Remove(currentItem);

            var mixedIndex = ModuloWrap(mixedNumbers.Count, index, number);
            if (mixedIndex == 0)
            {
                mixedIndex = mixedNumbers.Count;
            }
            mixedNumbers.Insert(mixedIndex, (-1, number));

            currentIndex++;
        }

        public int CalculateGrooveCoordinates()
        {
            var grooveList = mixedNumbers.Select(omar => omar.Item2).ToList();

            var groveCoords = new List<int>();
            for (int i = 0; i < grooveList.Count; i++)
            {
                if (grooveList[i] == 0)
                {
                    groveCoords.Add(grooveList[(i + 1000) % grooveList.Count]);
                    groveCoords.Add(grooveList[(i + 2000) % grooveList.Count]);
                    groveCoords.Add(grooveList[(i + 3000) % grooveList.Count]);
                    break;
                }
            }

            return groveCoords.Sum();
        }

        public List<int> ToList()
        {
            return mixedNumbers.Select(item => item.Item2).ToList();
        }

        public static int ModuloWrap(int arrayLength, int currentIndex, int currentNumber)
        {
            return ((currentNumber + currentIndex) % arrayLength + arrayLength) % arrayLength;
        }
    }
}
