namespace YadaYada.ZplFlow;

public class FileStart : Fragment
{
    public override string GetZpl(List<Fragment> fragments)
    {
        return Codes.FileStart;
    }
}