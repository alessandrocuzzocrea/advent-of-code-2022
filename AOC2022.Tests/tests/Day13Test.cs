using AOC2022.Solutions;

namespace AOC2022.Tests;

public class Day13Test
{
    [Fact]
    public void Part1_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(13, Day13.Part1("./inputs/day13-example"));
    }

    [Fact]
    public void Part2_IsCorrect_WhenUsingExampleInputFile()
    {
        Assert.Equal(140, Day13.Part2("./inputs/day13-example"));
    }

    /*
        ██████╗░░█████╗░██████╗░░██████╗███████╗
        ██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔════╝
        ██████╔╝███████║██████╔╝╚█████╗░█████╗░░
        ██╔═══╝░██╔══██║██╔══██╗░╚═══██╗██╔══╝░░
        ██║░░░░░██║░░██║██║░░██║██████╔╝███████╗
        ╚═╝░░░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═════╝░╚══════╝
    */

    [Fact]
    public void Parse_ListExample1Packet1()
    {
        var packet = Day13.ParsePacket("[1,1,3,1,1]");
        Assert.Equal(5, packet.Count);
        Assert.Equal(1, packet[0]);
        Assert.Equal(1, packet[1]);
        Assert.Equal(3, packet[2]);
        Assert.Equal(1, packet[3]);
        Assert.Equal(1, packet[4]);
    }

    [Fact]
    public void Parse_ListExample1Packet2()
    {
        var packet = Day13.ParsePacket("[1,1,5,1,1]");
        Assert.Equal(5, packet.Count);
        Assert.Equal(1, packet[0]);
        Assert.Equal(1, packet[1]);
        Assert.Equal(5, packet[2]);
        Assert.Equal(1, packet[3]);
        Assert.Equal(1, packet[4]);
    }

    [Fact]
    public void Parse_ListExample2Packet1()
    {
        var packet = Day13.ParsePacket("[[1],[2,3,4]]");
        Assert.Equal(2, packet.Count);

        Assert.Equal(1, (packet[0] as List<object>)[0]);

        Assert.Equal(2, (packet[1] as List<object>)[0]);
        Assert.Equal(3, (packet[1] as List<object>)[1]);
        Assert.Equal(4, (packet[1] as List<object>)[2]);
    }

    [Fact]
    public void Parse_ListExample2Packet2()
    {
        var packet = Day13.ParsePacket("[[1],4]");
        Assert.Equal(2, packet.Count);

        Assert.Equal(1, (packet[0] as List<object>)[0]);
        Assert.Equal(4, packet[1]);
    }

    [Fact]
    public void Parse_10()
    {
        var packet = Day13.ParsePacket("[10]");
        Assert.Single(packet);

        Assert.Equal(10, packet[0]);
    }

    // Example 3

    [Fact]
    public void Parse_ListExample3Packet1()
    {
        var packet = Day13.ParsePacket("[9]");

        Assert.Equal(1, packet.Count);
        Assert.Equal(9, packet[0]);
    }

    [Fact]
    public void Parse_ListExample3Packet2()
    {
        var packet = Day13.ParsePacket("[[8,7,6]]");
        Assert.Equal(1, packet.Count);

        Assert.Equal(8, (packet[0] as List<object>)[0]);
        Assert.Equal(7, (packet[0] as List<object>)[1]);
        Assert.Equal(6, (packet[0] as List<object>)[2]);
    }

    // Example 6

    [Fact]
    public void Parse_ListExample6Packet1()
    {
        var packet = Day13.ParsePacket("[]");
        Assert.Empty(packet);
    }

    [Fact]
    public void Parse_ListExample6Packet2()
    {
        var packet = Day13.ParsePacket("[3]");
        Assert.Single(packet);

        Assert.Equal(3, packet[0]);
    }

    // Example 7

    [Fact]
    public void Parse_ListExample7Packet1()
    {
        var packet = Day13.ParsePacket("[[[]]]");
        Assert.Single(packet);
        Assert.Single((List<object>)packet[0]);
        Assert.Empty((List<object>)((List<object>)packet[0])[0]);
    }

    [Fact]
    public void Parse_ListExample7Packet2()
    {
        var packet = Day13.ParsePacket("[[]]");
        Assert.Single(packet);
        Assert.Empty((List<object>)packet[0]);
    }

    /*
        ░█████╗░░█████╗░███╗░░░███╗██████╗░░█████╗░██████╗░███████╗
        ██╔══██╗██╔══██╗████╗░████║██╔══██╗██╔══██╗██╔══██╗██╔════╝
        ██║░░╚═╝██║░░██║██╔████╔██║██████╔╝███████║██████╔╝█████╗░░
        ██║░░██╗██║░░██║██║╚██╔╝██║██╔═══╝░██╔══██║██╔══██╗██╔══╝░░
        ╚█████╔╝╚█████╔╝██║░╚═╝░██║██║░░░░░██║░░██║██║░░██║███████╗
        ░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚═╝░░░░░╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝
    */

    [Fact]
    public void Compare_Basic_01()
    {
        var left = Day13.ParsePacket("[2]");
        var right = Day13.ParsePacket("[1]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_02()
    {
        var left = Day13.ParsePacket("[1]");
        var right = Day13.ParsePacket("[2]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_03()
    {
        var left = Day13.ParsePacket("[]");
        var right = Day13.ParsePacket("[1]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_04()
    {
        var left = Day13.ParsePacket("[1]");
        var right = Day13.ParsePacket("[]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_05()
    {
        var left = Day13.ParsePacket("[1]");
        var right = Day13.ParsePacket("[1,1]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_06()
    {
        var left = Day13.ParsePacket("[1,1]");
        var right = Day13.ParsePacket("[1]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_07()
    {
        var left = Day13.ParsePacket("[1]");
        var right = Day13.ParsePacket("[[2]]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_08()
    {
        var left = Day13.ParsePacket("[[2]]");
        var right = Day13.ParsePacket("[1]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_09()
    {
        var left = Day13.ParsePacket("[[],0]");
        var right = Day13.ParsePacket("[[],1]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_10()
    {
        var left = Day13.ParsePacket("[[],1]");
        var right = Day13.ParsePacket("[[],0]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Basic_11()
    {
        var left = Day13.ParsePacket("[1]");
        var right = Day13.ParsePacket("[[1,1]]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_01()
    {
        var left = Day13.ParsePacket("[1,1,3,1,1]");
        var right = Day13.ParsePacket("[1,1,5,1,1]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_02()
    {
        var left = Day13.ParsePacket("[[1],[2,3,4]]");
        var right = Day13.ParsePacket("[[1],4]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_03()
    {
        var left = Day13.ParsePacket("[9]");
        var right = Day13.ParsePacket("[[8,7,6]]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_04()
    {
        var left = Day13.ParsePacket("[[4,4],4,4]");
        var right = Day13.ParsePacket("[[4,4],4,4,4]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_05()
    {
        var left = Day13.ParsePacket("[7,7,7,7]");
        var right = Day13.ParsePacket("[7,7,7]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_06()
    {
        var left = Day13.ParsePacket("[]");
        var right = Day13.ParsePacket("[3]");

        Assert.True(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_07()
    {
        var left = Day13.ParsePacket("[[[]]]");
        var right = Day13.ParsePacket("[[]]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_08()
    {
        var left = Day13.ParsePacket("[1,[2,[3,[4,[5,6,7]]]],8,9]");
        var right = Day13.ParsePacket("[1,[2,[3,[4,[5,6,0]]]],8,9]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Example_09()
    {
        var left = Day13.ParsePacket("[[]]");
        var right = Day13.ParsePacket("[]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Real_001()
    {
        var left = Day13.ParsePacket("[[[6,10],[4,3,[4]]]]");
        var right = Day13.ParsePacket("[[4,3,[[4,9,9,7]]]]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Real_004()
    {
        var left = Day13.ParsePacket("[[[[5,3],1,[10,2,9,7,3]],[[9,1,1],[10]],[[1,6,3,10],7,[2],4,1],0,5],[[[10,1,3,7,1],[8,8,8,0,9],1],[8,[1,1,10,7]],[[]]],[]]");
        var right = Day13.ParsePacket("[[],[[[7],[],[9,5],5,[9,7,8,9]]],[3,6,[7,[]]],[6,9]]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Real_012()
    {
        var left = Day13.ParsePacket("[[[]],[7,[[10],[1,3,8,6],[],0,3]]]");
        var right = Day13.ParsePacket("[[],[8,7,7,[7],[[],[4,4],[2,1,9,0]]],[]]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Real_053()
    {
        var left = Day13.ParsePacket("[[],[[8,4,[0,10,8],[]]],[],[[[2,2,9,7,2],[5],7,[10,1,3],6],0,[0],1,2],[[[],8,[8,4,4,2,7],[0,6,2,3,2],[8]],[7,10],0,5]]");
        var right = Day13.ParsePacket("[[],[[5,[],[1,5,3,3],[7,3,1,0],[3,1,3,10,8]],4,[],9],[5,4,[[9,10],[],[10,7,0],0,[]],7,2],[2]]");

        Assert.False(Day13.RightOrder(left, right));
    }

    [Fact]
    public void Compare_Real_136()
    {
        var left = Day13.ParsePacket("[[[],6,2,[8,[],[2,7,9],[]]],[[],[]]]");
        var right = Day13.ParsePacket("[[[]],[10,[],4,[5,[9,4]]],[[[],[2,9,0],9,3,1]],[[[6]],7,[[5,2],[5,7,9,7,6],[6,4,2,9]],[[3,7,6,7,10],9,[8,0,8,0],[9,4,4]]]]");

        Assert.False(Day13.RightOrder(left, right));
    }

    /*
        ░██████╗░█████╗░██████╗░████████╗
        ██╔════╝██╔══██╗██╔══██╗╚══██╔══╝
        ╚█████╗░██║░░██║██████╔╝░░░██║░░░
        ░╚═══██╗██║░░██║██╔══██╗░░░██║░░░
        ██████╔╝╚█████╔╝██║░░██║░░░██║░░░
        ╚═════╝░░╚════╝░╚═╝░░╚═╝░░░╚═╝░░░
    */

    [Fact]
    public void Sort_01()
    {
        var packet1 = ("[[2]]", Day13.ParsePacket("[[2]]"));
        var packet2 = ("[[6]]", Day13.ParsePacket("[[6]]"));

        List<(string, List<object>)> packets = new() { packet1, packet2 };

        packets.Sort(new Day13.PacketComparer());

        Assert.Equal("[[2]]", packets[0].Item1);
    }

    [Fact]
    public void Sort_02()
    {
        var packet1 = ("[[2]]", Day13.ParsePacket("[[2]]"));
        var packet2 = ("[[6]]", Day13.ParsePacket("[[6]]"));

        List<(string, List<object>)> packets = new() { packet1, packet2 };

        packets.Sort(new Day13.PacketComparer());

        Assert.Equal("[[6]]", packets[1].Item1);
    }

    [Fact]
    public void Sort_03()
    {
        var packet1 = ("[[2]]", Day13.ParsePacket("[[2]]"));
        var packet2 = ("[[2]]", Day13.ParsePacket("[[2]]"));

        List<(string, List<object>)> packets = new() { packet1, packet2 };

        packets.Sort(new Day13.PacketComparer());

        Assert.Equal("[[2]]", packets[0].Item1);
        Assert.Equal("[[2]]", packets[1].Item1);
    }

    [Fact]
    public void Sort_04()
    {
        var packet1 = ("[[[1],4]", Day13.ParsePacket("[[[1],4]"));
        var packet2 = ("[[[]]]", Day13.ParsePacket("[[[]]]"));

        List<(string, List<object>)> packets = new() { packet1, packet2 };

        packets.Sort(new Day13.PacketComparer());

        Assert.Equal("[[[]]]", packets[0].Item1);
        Assert.Equal("[[[1],4]", packets[1].Item1);
    }

    [Fact]
    public void Sort_05()
    {
        var packet1 = ("[[1],4]", Day13.ParsePacket("[[1],4]"));
        var packet2 = ("[1,1,3,1,1]", Day13.ParsePacket("[1,1,3,1,1]"));

        List<(string, List<object>)> packets = new() { packet1, packet2 };

        packets.Sort(new Day13.PacketComparer());

        Assert.Equal("[1,1,3,1,1]", packets[0].Item1);
        Assert.Equal("[[1],4]", packets[1].Item1);
    }
}
