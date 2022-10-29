namespace YadaYada.ZplFlow;

public class DefaultFont : Fragment
{
    public char Font { get; set; }
    public int WidthInDots { get; set; }
    public int HeightInDots { get; set; }

    public DefaultFont(char font, int widthInDots, int heightInDots)
    {
        Font = font;
        WidthInDots = widthInDots;
        HeightInDots = heightInDots;
    }
    public override string GetZpl(Document document, bool withComments = false)
    {
        return $"{Codes.DefaultFont}{Font},{WidthInDots},{HeightInDots}";
    }
}