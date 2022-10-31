using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public record FieldData : Fragment
{
    public FieldData():base(0)
    {
        
    }
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
    public string Data { get; set; }
    private const string OrientationNormal = "N";
    private const string ModelEnhanced = "2";

    public QrCode(string data) : base(0)
    {
        if (string.IsNullOrEmpty(data)) throw new ArgumentException("Value cannot be null or empty.", nameof(data));
        Data = data;
    }

    public int Magnification { get; set; } = 2;
    public override string GetZpl()
    {
        var zpl = new StringBuilder();
        zpl.AppendLine($"{Codes.QrCode}{OrientationNormal},{ModelEnhanced},{Magnification},{ErrorCorrection.GetEnumMemberValue()},{MaskValue}");
        zpl.Append($"{Codes.FieldDataStart}{this.Data}{Codes.FieldDataEnd}");
        return zpl.ToString();
    }

    public int MaskValue { get; set; } = 7;

    public ErrorCorrectionEnum ErrorCorrection { get; set; } = ErrorCorrectionEnum.UltraHigh;

    public enum ErrorCorrectionEnum
    {
        [EnumMember(Value = "H")] UltraHigh,
        [EnumMember(Value = "Q")] HighReliability,
        [EnumMember(Value = "M")] Standard,
        [EnumMember(Value = "L")] HighDensity
    }
}