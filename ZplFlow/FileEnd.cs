namespace YadaYada.ZplFlow;

public record FileEnd : Fragment
{
    public FileEnd() : base(0)
    {
        
    }
    public override string GetZpl()
    {
        return Codes.FileEnd;
    }
}