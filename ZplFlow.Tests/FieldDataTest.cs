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
            var fragments = new List<Fragment>();
            
            var zpl = t.GetZpl(new Document());
            zpl.Should().Contain(Codes.ScalableBitmappedFont);
            zpl.Should().Contain(Codes.FieldData);
        }
    }
}
