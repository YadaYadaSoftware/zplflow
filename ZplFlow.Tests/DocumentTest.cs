
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

        }
    }
}