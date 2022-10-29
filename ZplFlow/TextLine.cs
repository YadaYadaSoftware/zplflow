using System.Text;

namespace YadaYada.ZplFlow;

public class TextLine : Fragment
{
    public TextLine(string text) : base(true)
    {
        this.Text = text;
    }

    public string Text { get; }
    public override string GetZpl()
    {
        return $"{Codes.FieldData}{Text}";
    }
}