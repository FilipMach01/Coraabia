namespace Coraabia;

public static class ParameterParser
{
    public static Parameter? Parse(string text)
    {
        if (Enum.IsDefined(typeof(Parameter), text))
        {
            if (Enum.TryParse(text, true, out Parameter result))
            {
                return result;
            }
        }

        return null; 
    }
}