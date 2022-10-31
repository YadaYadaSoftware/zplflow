
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
            var t = new Document(new Size(4 * 203, 6 * 203), padding: 20);
            var thisIsMyText = "this is my text";
            t.AddLine(thisIsMyText);
            var zpl = t.GetZpl();
            zpl.Should().Contain($"{Codes.FieldDataStart}{thisIsMyText}");

        }

        [Fact]
        public void SamplePackingSlip()
        {
            var t = new Document(new Size(4*203,6*203));
            t.SetDefaultFont('F', heightInDots: 40)
                .AddLine("John Doe", 100)
                .AddLine("123 Main St.",40);
                t.AddLine("Town, ST 12345", 40);
                t.AddLine(string.Empty, 40);
                t.AddLine("Order #12345", 40);
            t.Save(new FileInfo(Path.GetTempPath() + "test.zpl"));
        }

        [Fact]
        public void SamplePackingSlip2()
        {
            var t = new Document(new Size(4 * 203, 6 * 203));
            t.AddText(FontBase.Arial4, "This is my text");
            
            t.Save(new FileInfo(Path.GetTempPath() + "test.zpl"));
            var zpl = t.GetZpl();
            zpl.Should().Contain(Codes.LabelHome);
            zpl.Should().Contain($"{Codes.FieldDataStart}This is my text");
        }
    }
}