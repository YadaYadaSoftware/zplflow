namespace YadaYada.ZplFlow;

public record TextBlock : Fragment
{
    public FontBase Font { get; }
    public string Text { get; }
    public int BlockWidth { get; }

    public TextBlock(FontBase font, string text, int blockWidth, int blockHeight) : base((int)(Math.Ceiling(text.Length / (blockWidth / font.WidthInDots)) * font.HeightInDots))
    {
        Font = font;
        Text = text;
        BlockWidth = blockWidth;
        this.Height = blockHeight;
    }

    public override string GetZpl()
    {
        return $"{Codes.ScalableBitmappedFont}{this.Font.Code}{Codes.TextBlockStart}N,{this.BlockWidth},{this.Height}{Codes.FieldDataStart}{this.Text}{Codes.FieldDataEnd}";
    }
}