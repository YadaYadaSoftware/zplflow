﻿using System.Drawing;
using System.Runtime.Serialization;
using System.Text;

namespace YadaYada.ZplFlow;

public class Document
{
    public Size Size { get; }
    public int Padding { get; }
    private int _y = 0;
    public LinkedList<Fragment> Fragments { get; } = new();

    protected Document()
    {
        this.Fragments.AddFirst(new FileStart());
        this.Fragments.AddLast(new FileEnd());
    }

    public Document(Size size, int padding = 20 ) : this()
    {
        Size = size;
        Padding = padding;
    }


    private Fragment AddBeforeFileEnd(Fragment fragment)
    {
        if (fragment.FragmentHeight.HasValue)
        {
            _y += fragment.FragmentHeight.Value;
        }
        this.Fragments.AddBefore(this.Fragments.Last!, new LinkedListNode<Fragment>(fragment));
        return fragment;
    }

    public Document AddLine(string text, int heightInDots = 30)
    {

        var origin = new Origin(this.Padding, _y, Origin.JustificationEnum.Left);

        this.AddBeforeFileEnd(origin);

        if (this.Fragments.OfType<ScalableBitmappedFont>().LastOrDefault() is not { } lastFont || lastFont.FontHeight != heightInDots)
        {
            this.AddBeforeFileEnd(new ScalableBitmappedFont(this.GetCurrentFont().Font.Value, Orientation.Normal));
        }

        var fieldData = new FieldData(text){FragmentHeight = heightInDots};
        this.AddBeforeFileEnd(fieldData);
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

    public string GetZpl(bool withComments = false)
    {
        var returnValue = new StringBuilder();
        foreach (var fragment in Fragments)
        {
            returnValue.AppendLine(fragment.GetZpl(this));
        }
        return returnValue.ToString();
    }
}