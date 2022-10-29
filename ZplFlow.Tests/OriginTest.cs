using System.Drawing;
using FluentAssertions;
using YadaYada.ZplFlow;

namespace ZplFlow.Tests;

public class OriginTest
{
    [Fact]
    public void GetZplTest()
    {
        var t = new Origin();
        const int x = 1;
        t.X = x;
        const int y = 2;
        t.Y = y;
        t.Justification = Origin.JustificationEnum.Right;
        var zpl = t.GetZpl(new Document(new Size(4 * 203, 6 * 203)));
        zpl.Should().Be($"{Codes.FieldOrigin}{x},{y},{(int)t.Justification}");
    }
}