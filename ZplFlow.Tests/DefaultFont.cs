using FluentAssertions;
using Xunit;
using YadaYada.ZplFlow;

namespace ZplFlow.Tests;

public class DefaultFontTest
{
    [Fact]
    public void Test()
    {
        var target = new DefaultFont('C', 10, 11);
        var document = new Document();
        var zpl = target.GetZpl(document);
        zpl.Should().Be($"{Codes.DefaultFont}C,10,11");
    }
}