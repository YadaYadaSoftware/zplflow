using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    private int _x = 0;
    private int _y = 0;
    public LinkedList<Fragment> Fragments { get; } = new();

    public Document()
    {
        this.Fragments.AddFirst(new FileStart());
        this.Fragments.AddLast(new FileEnd());
    }


    private Fragment AddBeforeFileEnd(Fragment fragment)
    {
        this.Fragments.AddBefore(this.Fragments.Last!, new LinkedListNode<Fragment>(fragment));
        return fragment;
    }

    public Document AddLine(string text, int heightInDots = 30)
    {
        if (this.Fragments.OfType<ScalableBitmappedFont>().LastOrDefault() is not { } lastFont || lastFont.FontHeight != heightInDots)
        {
            this.AddBeforeFileEnd(new ScalableBitmappedFont { FontHeight = heightInDots });
        }
        
        var fieldData = new FieldData(text);
        this.AddBeforeFileEnd(fieldData);
        return this;
    }

    public int Y { get; set; }

    public string GetZpl()
    {
        var returnValue = new StringBuilder();
        foreach (var fragment in Fragments)
        {
            returnValue.AppendLine(fragment.GetZpl(this));
        }
        return returnValue.ToString();
    }
}