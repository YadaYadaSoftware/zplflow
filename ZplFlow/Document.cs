using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    private int _x = 0;
    private int _y = 0;
    public List<Fragment> Fragments { get; } = new() {new FileStart()};


    public Document AddLine(string text, int heightInDots = 30)
    {
        if (this.Fragments.LastOrDefault(f => f is ScalableBitmappedFont) is not { })
        {
            this.Fragments.Add(new ScalableBitmappedFont { FontHeight = heightInDots });
        }
        
        var fieldData = new FieldData(text);
        Fragments.Add(fieldData);
        return this;
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
            returnValue.AppendLine(fragment.GetZpl(this));
        }
        return returnValue.ToString();
    }
}