using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using YadaYada.ZplFlow;

namespace ZplFlow.Tests
{
    public class ScalableBitmappedFontTest
    {
        [Fact]
        public void GetZplTest()
        {
            const string font = "0";
            const int width = 10;
            const int height = 11;
            var orientation = "N";
            var t = new ScalableBitmappedFont(font, width, height, Orientation.Normal);
            var zpl = t.GetZpl(new Document(new Size(4 * 203, 6 * 203)));
            zpl.Should().Be($"{Codes.ScalableBitmappedFont}{font}{orientation},{height},{width}");
        }
    }
}
