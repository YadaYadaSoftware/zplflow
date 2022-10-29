
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
            var zpl = t.GetZpl();
            zpl.Should().Contain($"{Codes.FieldOrigin}0,0");
            zpl.Should().Contain($"{Codes.FieldData}{thisIsMyText}");

        }
    }
}