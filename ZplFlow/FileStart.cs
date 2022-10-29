namespace YadaYada.ZplFlow;

public class FileStart : Fragment
{
    public override string GetZpl(Document document)
    {
        return Codes.FileStart;
    }
}