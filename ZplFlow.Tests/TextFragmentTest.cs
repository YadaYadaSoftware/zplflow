using System.Drawing;
using FluentAssertions;
using YadaYada.ZplFlow;

namespace ZplFlow.Tests;

public class TextFragmentTest
{
    [Fact]
    public void GetZplTest()
    {
        var t = new TextLine(FontBase.Arial1, "Hello World", new Document(new Size(100, 100)));
        t.Height.Should().Be(40);
    }
}