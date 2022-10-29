using System.Text;

namespace YadaYada.ZplFlow;

public class FieldData : Fragment
{
    public FieldData(string text) : base(true)
    {
        this.Text = text;
    }




    public string Text { get; }

    public override string GetZpl(Document document)
    {
        var zpl = new StringBuilder();
        zpl.AppendLine($"{Codes.FieldData}{Text}");
        return zpl.ToString();
    }

}

