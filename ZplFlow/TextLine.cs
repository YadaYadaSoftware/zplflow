using System.Text;

namespace YadaYada.ZplFlow;

public class TextLine : Fragment
{
    public TextLine(string text) : base(true, supportsHeight: true)
    {
        this.Text = text;
    }

    public string Text { get; }
    public override string GetZpl()
    {
        var zpl = new StringBuilder();
        zpl.AppendLine($"{Codes.ScalableBitmappedFont}0,0,30");
        zpl.AppendLine($"{Codes.FieldData}{Text}");
        return zpl.ToString();
    }

    public override int? Height { get; } = 20;
}