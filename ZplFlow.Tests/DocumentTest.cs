
using System.Drawing;
using FluentAssertions;
using YadaYada.ZplFlow;
using YadaYada.ZplFlow.Fonts;

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
            t.Y.Should().Be(20);
            t.AddText(FontBase.Arial4, "This is my text");
            t.Y.Should().Be(20 + FontBase.Arial4.HeightInDots);
            t.AddTextBlock(new OCRB(), "this is a long piece of text.  this is a long piece of text.  this is a long piece of text.  this is a long piece of text.  this is a long piece of text.  this is a long piece of text.  ", 120);

            t.Save(new FileInfo(Path.GetTempPath() + "test.zpl"));
            var zpl = t.GetZpl();
            zpl.Should().Contain(Codes.LabelHome);
            zpl.Should().Contain($"{Codes.FieldDataStart}This is my text");
        }

        [Fact]
        public void SampleOverflow()
        {
            var t = new Document(new Size(4 * 203, 6 * 203));

            for (int page = 1; page < 3; page++)
            {
                for (int i = 1; i <= 9; i++)
                {
                        t.AddTextBlock(new OCRB(), $"this is a long piece of text #{i} on page #{page}.  this is a long piece of text.  this is a long piece of text.  this is a long piece of text.  this is a long piece of text.  this is a long piece of text.  ", 120);
                }
            }
            t.Save(new FileInfo(Path.GetTempPath() + "test.zpl"));

            t.Y.Should().Be(620);

        }

        [Fact]
        public void QrCodeTest()
        {
            var t = new Document(new Size(4 * 203, 6 * 203));
            t.AddQrCode(Guid.NewGuid().ToString());
            t.Save(new FileInfo(Path.GetTempPath() + "test.zpl"));
        }

        [Fact]
        public void HorizontalRuleTest()
        {
            var t = new Document(new Size(4 * 203, 6 * 203));
            t.AddText(FontBase.Arial4, "Before Rule")
                .AddHorizontalRule(5)
                .AddText(FontBase.Arial4, "After Rule");
            ;
            t.Save(new FileInfo(Path.GetTempPath() + "test.zpl"));

        }
    }
}