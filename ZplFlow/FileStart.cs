namespace YadaYada.ZplFlow;

public record FileStart : Fragment
{
    public FileStart() : base(0)
    {

    }
    public override string GetZpl()
    {
        return Codes.FileStart;
    }
}