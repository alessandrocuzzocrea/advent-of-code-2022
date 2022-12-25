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
        public List<(int originalIndex, int number)> OriginalNumbers = new();
        public List<(int originalIndex, int number)> MixedNumbers = new();

        private int currentIndex = 0;

        public Mixer(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                OriginalNumbers.Add((i, int.Parse(line)));
                MixedNumbers.Add((i, int.Parse(line)));
            }
        }

        public void Mix()
        {
            var i = currentIndex;

            (int, int) currentItem = OriginalNumbers[i];
            int number = currentItem.Item2;
            int index = MixedNumbers.IndexOf(currentItem);
            MixedNumbers.Remove(currentItem);

            var mixedIndex = ModuloWrap(MixedNumbers.Count, index, number);
            if (mixedIndex == 0)
            {
                mixedIndex = MixedNumbers.Count;
            }
            MixedNumbers.Insert(mixedIndex, (-1, number));

            currentIndex++;
        }

        public int CalculateGrooveCoordinates()
        {
            var grooveList = MixedNumbers.Select(omar => omar.number).ToList();
            var grooveIndex = grooveList.IndexOf(0);
            return grooveList[(grooveIndex + 1000) % grooveList.Count] +
                   grooveList[(grooveIndex + 2000) % grooveList.Count] +
                   grooveList[(grooveIndex + 3000) % grooveList.Count];
        }

        public List<int> ToList()
        {
            return MixedNumbers.Select(item => item.Item2).ToList();
        }

        public static int ModuloWrap(int arrayLength, int currentIndex, int currentNumber)
        {
            return ((currentNumber + currentIndex) % arrayLength + arrayLength) % arrayLength;
        }
    }
}
