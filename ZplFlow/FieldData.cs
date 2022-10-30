using System.Text;

namespace YadaYada.ZplFlow;

public record FieldData : Fragment
{
    public string? Text { get; set; }

    public override string GetZpl()
    {
        var zpl = new StringBuilder();
        zpl.Append($"{Codes.FieldDataStart}{Text}{Codes.FieldDataEnd}");
        return zpl.ToString();
    }

}

public record QrCode : Fragment
{
    public override string GetZpl()
    {
        throw new NotImplementedException();
    }
}