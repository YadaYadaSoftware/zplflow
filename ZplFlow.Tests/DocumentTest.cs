
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
            zpl.Should().Contain($"{Codes.FieldData}{thisIsMyText}");

        }

        [Fact]
        public void SamplePackingSlip()
        {
            var t = new Document();
            t.AddLine("John Doe");
            var zpl = t.GetZpl();
            var lines = zpl.Split(Environment.NewLine);
            lines.Should().ContainSingle(s => s.StartsWith(Codes.ScalableBitmappedFont));
            t.AddLine("123 Main St.");
                t.AddLine("Town, ST 12345");
                t.AddLine(string.Empty);
                t.AddLine("Order #12345");
            zpl = t.GetZpl();
            zpl.Should().Contain(Codes.ScalableBitmappedFont);
        }
    }
}