using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    public StringBuilder Contents { get; } = new();
    private int _x = 0;
    private int _y = 0;


    public Document()
    {
        this.Contents.AppendLine(Codes.FileStart);
    }

    public void AddText(string text)
    {
        if (!this.Contents.ToString().Contains(Codes.FieldOrigin))
        {
            this.Contents.AppendLine($"{Codes.FieldOrigin}{_x},{_y}");
        }
        this.Contents.Append(Codes.FieldData);
        this.Contents.AppendLine(text);
    }

    public int Y { get; set; }

    public string GetZpl()
    {
        if (!Contents.ToString().EndsWith(Codes.FileEnd)) Contents.AppendLine(Codes.FileEnd);
        return Contents.ToString();
    }

    
}