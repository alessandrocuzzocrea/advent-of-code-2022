namespace AOC2022.Solutions;

public class Day20
{
    public static int Part1(string inputFilePath)
    {
        var lines = File.ReadAllLines(inputFilePath);

        var mixer = new Mixer(lines);
        mixer.MixAll();

        return mixer.CalculateGrooveCoordinates();
    }

    public class Mixer
    {
        public List<(int originalIndex, int number)> OriginalNumbers { get; }
        public List<(int originalIndex, int number)> MixedNumbers { get; }

        private int currentIndex = 0;

        public Mixer(string[] lines)
        {
            OriginalNumbers = lines.Select((line, i) => (i, int.Parse(line))).ToList();
            MixedNumbers = new List<(int, int)>(OriginalNumbers);
        }

        public void MixAll()
        {
            for (int i = 0; i < OriginalNumbers.Count; i++)
            {
                Mix();
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
            var grooveList = MixedNumbers.Select(item => item.number).ToList();
            var grooveIndex = grooveList.IndexOf(0);
            return grooveList[(grooveIndex + 1000) % grooveList.Count] +
                   grooveList[(grooveIndex + 2000) % grooveList.Count] +
                   grooveList[(grooveIndex + 3000) % grooveList.Count];
        }

        public List<int> ToList()
        {
            return MixedNumbers.Select(item => item.number).ToList();
        }

        public static int ModuloWrap(int arrayLength, int currentIndex, int currentNumber)
        {
            return ((currentNumber + currentIndex) % arrayLength + arrayLength) % arrayLength;
        }
    }
}
