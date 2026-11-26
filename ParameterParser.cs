namespace Coraabia;

public static class ParameterParser
{
    public static Parameter? Parse(string text)
    {
        if (Enum.TryParse(text, true, out Parameter result) && !int.TryParse(text, out _))
        {
             return result;
        }
        
        return null; 
    }
}