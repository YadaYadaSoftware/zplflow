using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    private readonly StringBuilder _contents = new(Codes.FileStart);
    public void AddText(string text)
    {
        throw new NotImplementedException();
    }

    public string GetZpl()
    {
        return _contents.ToString();
    }
}

public static class Codes
{
    public const string FileStart = "^XA";
    public const string FileEnd = "^XZ";
}