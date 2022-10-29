using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using YadaYada.ZplFlow;

namespace ZplFlow.Tests
{
    public class FieldDataTest
    {
        [Fact]
        public void AddsFont()
        {
            var t = new FieldData("this is my text");

            var document = new Document();
            var zpl = t.GetZpl(document);
            zpl.Should().Contain(Codes.ScalableBitmappedFont);
            zpl.Should().Contain(Codes.FieldData);
        }

        [Fact]
        public void FontTest()
        {
            const string fontName = "2";
            const int height = 101;
            const int width = 200;

            var t = new FieldData("this is my text");
            t.Font = fontName;
            t.FontHeight = height;
            t.FontHeight.Should().Be(height);
            t.FontWidth = width;
            t.FontWidth.Should().Be(width);

            var zpl = t.GetZpl(new Document());
            var lines = zpl.Split(Environment.NewLine);
            lines.First().Should().Be($"{Codes.ScalableBitmappedFont}{fontName}{Orientation.Normal.GetEnumMemberValue()},{height},{width}");

        }
    }
}
