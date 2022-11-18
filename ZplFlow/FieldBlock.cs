namespace YadaYada.ZplFlow;

public record FieldBlock(FontBase Font, string Text, int Width, int NumberOfLines) : Fragment(Font.HeightInDots * NumberOfLines)
{
    public override string GetZpl()
    {
        return $"{Codes.ScalableBitmappedFont}{this.Font.Code}{Codes.FieldBlockStart}{this.Width}{Codes.FieldDataStart}{this.Text}{Codes.FieldDataEnd}";
    }
}