namespace YadaYada.ZplFlow;

public record FileEnd : Fragment
{
    public override string GetZpl(Document document, bool withComments)
    {
        return Codes.FileEnd;
    }
}