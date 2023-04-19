namespace ServiceLayer;

public static class ExportServiceExtensions
{

    public static float ToDPI(this float centimeter)
    {
        var inch = centimeter / 2.54;
        return (float)(inch * 72);
    }
}