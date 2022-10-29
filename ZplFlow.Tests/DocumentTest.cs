
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
            var t = new Document(new Size(4 * 203, 6 * 203));
            t.GetZpl().Should().StartWith(Codes.FileStart);
            t.GetZpl().ReplaceLineEndings(string.Empty).Should().EndWith(Codes.FileEnd);
        }

        [Fact]
        public void AddTextTest()
        {
            var t = new Document(new Size(4 * 203, 6 * 203));
            var thisIsMyText = "this is my text";
            t.AddLine(thisIsMyText);
            var zpl = t.GetZpl();
            zpl.Should().Contain($"{Codes.FieldDataStart}{thisIsMyText}");

        }

        [Fact]
        public void SamplePackingSlip()
        {
            var t = new Document(new Size(4*203,6*203));
            t.SetDefaultFont('C', heightInDots: 40)
                .AddLine("John Doe", 100)
                .AddLine("123 Main St.",40);
                t.AddLine("Town, ST 12345", 40);
                t.AddLine(string.Empty, 40);
                t.AddLine("Order #12345", 40);
            var zpl = t.GetZpl(true);
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