namespace YadaYada.ZplFlow;

public abstract class Fragment
{
    protected Fragment(bool supportsOrigin)
    {
        this.SupportsOrigin = supportsOrigin;
    }

    protected Fragment()
    {
        
    }
    public abstract string GetZpl();
    public bool SupportsOrigin { get; }
}