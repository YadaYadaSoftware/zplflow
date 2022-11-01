using System.Drawing;
using FluentAssertions;
using YadaYada.ZplFlow;

namespace ZplFlow.Tests;

public class TextFragmentTest
{
    [Fact]
    public void GetZplTest()
    {
        var t = new TextLine(FontBase.Arial1, "Hello World");
        t.Height.Should().Be(20);
    }
}