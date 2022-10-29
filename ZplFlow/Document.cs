using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    public StringBuilder Contents { get; } = new();
    private int _x = 0;
    private int _y = 0;
    public List<Fragment> Fragments { get; } = new() {new FileStart()};

    public Document()
    {
        this.Contents.AppendLine(Codes.FileStart);
    }


    public FieldData AddLine(string text)
    {
        var fieldData = new FieldData(text);
        if (!this.Fragments.Any(fragment => fragment is ScalableBitmappedFont)) this.Fragments.Add(new ScalableBitmappedFont());
        Fragments.Add(fieldData);
        return fieldData;
    }

    public int Y { get; set; }

    public string GetZpl()
    {
        if (Fragments.Last() is not FileEnd)
        {
            Fragments.Add(new FileEnd());
        }
        var returnValue = new StringBuilder();
        foreach (var fragment in Fragments)
        {
            if (fragment.SupportsOrigin)
            {
                returnValue.AppendLine($"{Codes.FieldOrigin}{_x},{_y}");
            }
            returnValue.Append(fragment.GetZpl(this));
        }
        return returnValue.ToString();
    }
}