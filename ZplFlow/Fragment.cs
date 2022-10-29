namespace YadaYada.ZplFlow;

public abstract class Fragment
{
    protected Fragment(bool supportsOrigin = false)
    {
    }

    protected Fragment()
    {
        
    }
    public abstract string GetZpl(Document document);

    public int? FragmentHeight { get; set; } = null;
    public int? FragmentWidth { get; set; } = null;
    
}