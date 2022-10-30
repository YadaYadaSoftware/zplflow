namespace YadaYada.ZplFlow;

public abstract record Fragment
{
    public abstract string GetZpl();

    public int? FragmentHeight { get; set; } = null;
    public int? FragmentWidth { get; set; } = null;
    
}