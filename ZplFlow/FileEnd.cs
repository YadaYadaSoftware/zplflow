namespace YadaYada.ZplFlow;

public record FileEnd : Fragment
{
    public override string GetZpl(Document document)
    {
        return Codes.FileEnd;
    }
}