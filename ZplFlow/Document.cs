using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    private readonly int _padding;
    public Size Size { get; }
    public int Y { get; private set; } = 0;
    public LinkedList<Fragment> Fragments { get; } = new();

    protected Document()
    {
        this.Fragments.AddFirst(new FileStart());
        this.Fragments.AddLast(new FileEnd());
    }

    public Document(Size size, int padding = 20 ) : this()
    {
        _padding = padding;
        Size = size;
        this.AddBeforeFileEnd(new LabelHome(padding,padding));
    }


    private Fragment AddBeforeFileEnd(Fragment fragment)
    {
        this.Fragments.AddBefore(this.Fragments.Last!, new Origin(0, this.Y, Origin.JustificationEnum.Auto));
        this.Y += fragment.Height;
        this.Fragments.AddBefore(this.Fragments.Last!, new LinkedListNode<Fragment>(fragment));
        return fragment;
    }

    public Document AddLine(string text, int heightInDots = 30)
    {

        var fieldData = new FieldData{Text = text};
        this.AddBeforeFileEnd(fieldData);
        return this;
    }

    public Document AddText(FontBase font, string text)
    {
        this.AddBeforeFileEnd(new TextLine(font, text));
        return this;
    }
    public Document AddTextBlock(FontBase font, string text, int maxLines)
    {
        this.AddBeforeFileEnd(new TextBlock(font, text, this.Size.Width - _padding, maxLines));
        return this;
    }



    public Document AddQrCode(string data)
    {
        this.AddBeforeFileEnd(new QrCode(data));
        return this;
    }

    public Document SetDefaultFont(char? font = null, int? widthInDots = null, int? heightInDots = null)
    {
        var defaultFont = new DefaultFont(font, widthInDots, heightInDots);
        if (defaultFont != this.GetCurrentFont())
        {
            this.AddBeforeFileEnd(defaultFont);
        }

        return this;
    }

    private DefaultFont? GetCurrentFont()
    {
        return this.Fragments.OfType<DefaultFont>().LastOrDefault();
    }

    public string GetZpl()
    {
        var returnValue = new StringBuilder();
        foreach (var fragment in Fragments)
        {
            returnValue.AppendLine(fragment.GetZpl());
        }
        return returnValue.ToString();
    }

    public void Save(FileInfo fileInfo)
    {
        File.WriteAllText(fileInfo.FullName, this.GetZpl());
    }
}