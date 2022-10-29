namespace YadaYada.ZplFlow;

public class FileEnd : Fragment
{
    public override string GetZpl(Document document, bool withComments)
    {
        return Codes.FileEnd;
    }
}