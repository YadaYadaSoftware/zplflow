
using System.Drawing;
using FluentAssertions;
using YadaYada.ZplFlow;

namespace ZplFlow.Tests
{
    public class DocumentTest
    {
        [Fact]
        public void FileStartAndFileEnd()
        {
            var t = new Document();
            t.GetZpl().Should().StartWith(Codes.FileStart);
            t.GetZpl().ReplaceLineEndings(string.Empty).Should().EndWith(Codes.FileEnd);
        }

        [Fact]
        public void AddTextTest()
        {
            var t = new Document();
            var thisIsMyText = "this is my text";
            t.AddLine(thisIsMyText);
            t.Fragments.Should().ContainSingle(fragment => fragment is ScalableBitmappedFont);
            var zpl = t.GetZpl();
            zpl.Should().Contain(Codes.ScalableBitmappedFont);
            zpl.Should().Contain($"{Codes.FieldDataStart}{thisIsMyText}");

        }

        [Fact]
        public void SamplePackingSlip()
        {
            var t = new Document(new Size(4*203,6*203));
            t.AddLine("John Doe", 100);
            var zpl = t.GetZpl();
            var lines = zpl.Split(Environment.NewLine);
            lines.Should().ContainSingle(s => s.StartsWith(Codes.ScalableBitmappedFont));
            t.AddLine("123 Main St.",40);
                t.AddLine("Town, ST 12345", 40);
                t.AddLine(string.Empty, 40);
                t.AddLine("Order #12345", 40);
            zpl = t.GetZpl(true);
            zpl.Should().Contain(Codes.ScalableBitmappedFont);
            File.WriteAllText("c:\\temp\\test.zpl", zpl);

            /*

^XA
^FO0,0,0
^ABN0,100
^FDJohn Doe^FS
^FO10,150,0
^ABN0,50
^FD123 Main St.^FS
^XZ
            
            
             */


        }
    }
}