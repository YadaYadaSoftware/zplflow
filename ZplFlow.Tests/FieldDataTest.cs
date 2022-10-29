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
    }
}
