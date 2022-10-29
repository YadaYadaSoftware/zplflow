namespace YadaYada.ZplFlow;

public record FileStart : Fragment
{
    public override string GetZpl(Document document, bool withComments)
    {
        return Codes.FileStart;
    }
}