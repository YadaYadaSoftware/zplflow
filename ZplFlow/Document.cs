using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    public StringBuilder Contents { get; } = new();
    

    public Document()
    {
        this.Contents.AppendLine(Codes.FileStart);
    }

    public void AddText(string text)
    {
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