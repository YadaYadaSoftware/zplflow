namespace YadaYada.ZplFlow;

public record GraphicBox : Fragment
{
    public int Width { get; }

    public GraphicBox(int width, int height)
        : base(height)
    {
        Width = width;
        this.Height = height;
    }

    public override string GetZpl()
    {
        return $"{Codes.GraphicBox}{this.Width},{this.Height},{this.Height},B,0{Codes.FieldDataEnd}";
    }
}