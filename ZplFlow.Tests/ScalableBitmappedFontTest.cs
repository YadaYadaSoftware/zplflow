using System;
using System.Collections.Generic;
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
            const char font = '0';
            const int width = 10;
            const int height = 11;
            var orientation = "N";
            var t = new ScalableBitmappedFont(font, Orientation.Normal, width, height);
            var zpl = t.GetZpl();
            zpl.Should().Be($"{Codes.ScalableBitmappedFont}{font}{orientation},{height},{width}");
        }
    }
}
