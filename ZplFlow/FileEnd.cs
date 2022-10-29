namespace YadaYada.ZplFlow;

public class FileEnd : Fragment
{
    public override string GetZpl(List<Fragment> fragments)
    {
        return Codes.FileEnd;
    }
}