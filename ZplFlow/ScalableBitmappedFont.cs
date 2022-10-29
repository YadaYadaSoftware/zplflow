namespace YadaYada.ZplFlow;

public class ScalableBitmappedFont : Fragment
{
    public ScalableBitmappedFont(string font, int width, int height, string orientation)
    {
        this.Font = font;
        this.Width = width;
        this.Height = height;
        this.Orientation = orientation;
    }
    public override string GetZpl()
    {
        return $"{Codes.ScalableBitmappedFont}{this.Font}{this.Orientation},{this.Height},{this.Width}";
    }
    public string Font { get; }
    public int? Width { get; }
    public int? Height { get; }
    public string Orientation { get; }
    
}