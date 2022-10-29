namespace YadaYada.ZplFlow;

public class FileStart : Fragment
{
    public override string GetZpl(Document document, bool withComments)
    {
        return Codes.FileStart;
    }
}