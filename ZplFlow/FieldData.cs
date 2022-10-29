using System.Text;

namespace YadaYada.ZplFlow;

public record FieldData : Fragment
{
    public FieldData(string text) : base(true)
    {
        this.Text = text;
    }




    public string Text { get; }

    public override string GetZpl(Document document)
    {
        var zpl = new StringBuilder();
        zpl.AppendLine($"{Codes.FieldDataStart}{Text}{Codes.FieldDataEnd}");
        return zpl.ToString();
    }

}