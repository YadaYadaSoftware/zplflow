namespace YadaYada.ZplFlow;

public abstract record Fragment
{
    public int Height { get; protected set; }

    protected Fragment(int height)
    {
        Height = height;
    }
    public abstract string GetZpl();
    
}