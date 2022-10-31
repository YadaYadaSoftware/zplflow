namespace YadaYada.ZplFlow;

public record TextLine : Fragment
{
    public TextLine(FontBase font, string text) : base(font.HeightInDots)
    {
        this.Font = font;
        this.Text = text;
    }

    public string Text { get; set; }

    public FontBase Font { get; set; }
    public override string GetZpl()
    {

        return $"{Codes.ScalableBitmappedFont}{this.Font.Code}{Codes.FieldDataStart}{this.Text}{Codes.FieldDataEnd}";

    }
}

public record TextBlock : Fragment
{
    public FontBase Font { get; }
    public string Text { get; }
    public int MaxLines { get; }
    public int Width { get; }

    public TextBlock(FontBase font, string text, int width, int maxLines) : base((int)(Math.Ceiling(text.Length / (width / font.WidthInDots)) * font.HeightInDots))
    {
        Font = font;
        Text = text;
        MaxLines = maxLines;
        Width = width;
    }

    public override string GetZpl()
    {
        return $"{Codes.ScalableBitmappedFont}{this.Font.Code}{Codes.FieldBlockStart}{this.Width},{this.MaxLines}{Codes.FieldDataStart}{this.Text}{Codes.FieldDataEnd}";
    }
}