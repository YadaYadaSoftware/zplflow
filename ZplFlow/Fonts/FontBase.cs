using YadaYada.ZplFlow.Fonts;

namespace YadaYada.ZplFlow;

public abstract class FontBase
{
    public static FontBase Arial1 = new Arial1();
    public static FontBase Arial2 = new Arial2();
    public static FontBase Arial3 = new Arial3();
    public static FontBase Arial4 = new Arial4();
    public static FontBase Arial5 = new Arial5();
    public static FontBase Arial6 = new Arial6();
    public static FontBase Arial7 = new Arial7();

    protected FontBase(char code, int heightInDots, decimal widthInDots)
    {
        Code = code;
        HeightInDots = heightInDots;
        WidthInDots = widthInDots;
    }

    public char Code { get; }
    public int HeightInDots { get; }
    public decimal WidthInDots { get; }

    public int GetCharactersPerLine(int lineWidth)
    {
        var returnValue = (int) Math.Floor(lineWidth / this.WidthInDots);
        return returnValue;
    }
}