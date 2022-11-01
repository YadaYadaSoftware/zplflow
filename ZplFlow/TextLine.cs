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