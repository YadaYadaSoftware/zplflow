using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    public Size Size { get; }
    public decimal Y { get; private set; } = 0;
    public LinkedList<Fragment> Fragments { get; } = new();

    protected Document()
    {
        this.Fragments.AddFirst(new FileStart());
        this.Fragments.AddLast(new FileEnd());
    }

    public Document(Size size, int padding = 20 ) : this()
    {
        Size = size;
        this.AddBeforeFileEnd(new LabelHome(padding,padding));
    }


    private Fragment AddBeforeFileEnd(Fragment fragment)
    {
        //if (fragment.FragmentHeight.HasValue)
        //{
        //    Y += fragment.FragmentHeight.Value;
        //}
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
        this.AddBeforeFileEnd(new TextFragment(font, text));
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

public record TextFragment : Fragment
{
    public TextFragment(FontBase font, string text) : base(font.HeightInDots)
    {
        this.Font = font;
        this.Text = text;
    }

    public string Text { get; set; }

    public FontBase Font { get; set; }
    public override string GetZpl()
    {

        return $"{Codes.ScalableBitmappedFont}{this.Font.Code}{Codes.FieldDataStart}{this.Text}{Codes.FieldDataEnd}";

    }
}