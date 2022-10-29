namespace YadaYada.ZplFlow;

public abstract class Fragment
{
    protected Fragment(bool supportsOrigin = false)
    {
        this.SupportsOrigin = supportsOrigin;
    }

    protected Fragment()
    {
        
    }
    public abstract string GetZpl(Document document);
    public bool SupportsOrigin { get; }

    public int? FragmentHeight { get; set; } = null;
    public int? FragmentWidth { get; set; } = null;
    
}