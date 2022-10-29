using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    public StringBuilder Contents { get; } = new();
    private int _x = 0;
    private int _y = 0;
    private List<Fragment> _fragments = new(){ new FileStart() };

    public Document()
    {
        this.Contents.AppendLine(Codes.FileStart);
    }

    public void AddLine(string text)
    {
        _fragments.Add(new TextLine(text));
        //if (!this.Contents.ToString().Contains(Codes.FieldOrigin))
        //{
        //    this.Contents.AppendLine($"{Codes.FieldOrigin}{_x},{_y}");
        //}
        //this.Contents.Append(Codes.FieldData);
        //this.Contents.AppendLine(text);
    }

    public int Y { get; set; }

    public string GetZpl()
    {
        if (_fragments.Last() is not FileEnd)
        {
            _fragments.Add(new FileEnd());
        }
        var returnValue = new StringBuilder();
        foreach (var fragment in _fragments)
        {
            if (fragment.SupportsOrigin)
            {
                returnValue.AppendLine($"{Codes.FieldOrigin}{_x},{_y}");
            }
            returnValue.Append(fragment.GetZpl(new List<Fragment>()));
        }
        return returnValue.ToString();
    }
}