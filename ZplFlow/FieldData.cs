using System.Text;

namespace YadaYada.ZplFlow;

public class FieldData : Fragment, IScalableBitmappedFont
{
    public FieldData(string text) : base(true, supportsHeight: true)
    {
        this.Text = text;
        this.TextFont = new ScalableBitmappedFont();
    }

    public ScalableBitmappedFont TextFont { get;}
    public int? FontWidth
    {
        get => TextFont.FontWidth;
        set => TextFont.FontWidth = value;
    }

    public Orientation Orientation
    {
        get => TextFont.Orientation;
        set => TextFont.Orientation = value;
    }

    public int? FontHeight
    {
        get => TextFont.FontHeight;
        set => TextFont.FontHeight = value;
    }

    public string Text { get; }

    public override string GetZpl(Document document)
    {
        var zpl = new StringBuilder();
        var fontCommand = this.TextFont.GetZpl(document);
        zpl.AppendLine(fontCommand);
        zpl.AppendLine($"{Codes.FieldData}{Text}");
        return zpl.ToString();
    }

    public string Font
    {
        get => TextFont.Font;
        set => TextFont.Font = value;
    }
}

