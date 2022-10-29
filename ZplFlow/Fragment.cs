namespace YadaYada.ZplFlow;

public abstract record Fragment
{
    protected Fragment(bool supportsOrigin = false)
    {
    }

    protected Fragment()
    {
        
    }
    public abstract string GetZpl(Document document, bool withComments = false);

    public int? FragmentHeight { get; set; } = null;
    public int? FragmentWidth { get; set; } = null;
    
}