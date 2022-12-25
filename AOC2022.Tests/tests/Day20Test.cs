using static AOC2022.Solutions.Day20;

namespace AOC2022.Tests;

public class Day20Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(3, Part1("./inputs/day20-example"));
    }

    [Theory]
    [InlineData(7, 0, 1, 1)]
    [InlineData(7, 0, 2, 2)]
    [InlineData(7, 1, -3, 5)]
    [InlineData(7, 2, 3, 5)]
    [InlineData(7, 2, -2, 0)]
    [InlineData(7, 3, 0, 3)]
    [InlineData(7, 5, 4, 2)]
    public void ModuloWrap_ReturnsCorrectResult(int arrayLength, int index, int number, int newIndexExpected)
    {
        Assert.Equal(newIndexExpected, Mixer.ModuloWrap(arrayLength, index, number));
    }

    [Fact]
    public void Part1_Example_InitialArrangement()
    {
        var mixer = new Mixer(File.ReadAllLines("./inputs/day20-example"));
        Assert.Equal(new List<int>() { 1, 2, -3, 3, -2, 0, 4 }, mixer.ToList());
    }

    [Fact]
    public void Part1_Example_AfterSwap1()
    {
        var mixer = new Mixer(File.ReadAllLines("./inputs/day20-example"));
        mixer.Mix();
        Assert.Equal(new List<int>() { 2, 1, -3, 3, -2, 0, 4 }, mixer.ToList());
    }

    [Fact]
    public void Part1_Example_AfterSwap2()
    {
        var mixer = new Mixer(File.ReadAllLines("./inputs/day20-example"));
        mixer.Mix();
        mixer.Mix();
        Assert.Equal(new List<int>() { 1, -3, 2, 3, -2, 0, 4 }, mixer.ToList());
    }

    [Fact]
    public void Part1_Example_AfterSwap3()
    {
        var mixer = new Mixer(File.ReadAllLines("./inputs/day20-example"));
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        Assert.Equal(new List<int>() { 1, 2, 3, -2, -3, 0, 4 }, mixer.ToList());
    }

    [Fact]
    public void Part1_Example_AfterSwap4()
    {
        var mixer = new Mixer(File.ReadAllLines("./inputs/day20-example"));
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        Assert.Equal(new List<int>() { 1, 2, -2, -3, 0, 3, 4 }, mixer.ToList());
    }

    [Fact]
    public void Part1_Example_AfterSwap5()
    {
        var mixer = new Mixer(File.ReadAllLines("./inputs/day20-example"));
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        Assert.Equal(new List<int>() { 1, 2, -3, 0, 3, 4, -2 }, mixer.ToList());
    }

    [Fact]
    public void Part1_Example_AfterSwap6()
    {
        var mixer = new Mixer(File.ReadAllLines("./inputs/day20-example"));
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        Assert.Equal(new List<int>() { 1, 2, -3, 0, 3, 4, -2 }, mixer.ToList());
    }

    [Fact]
    public void Part1_Example_AfterSwap7()
    {
        var mixer = new Mixer(File.ReadAllLines("./inputs/day20-example"));
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        mixer.Mix();
        Assert.Equal(new List<int>() { 1, 2, -3, 4, 0, 3, -2 }, mixer.ToList());
    }
}
