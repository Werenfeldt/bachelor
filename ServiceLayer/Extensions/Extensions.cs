namespace ServiceLayer;

public static class Extensions
{

    public static float ToDPI(this float centimeter)
    {
        var inch = centimeter / 2.54;
        return (float)(inch * 72);
    }
}