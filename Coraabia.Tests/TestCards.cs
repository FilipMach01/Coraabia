namespace Coraabia.Tests;

public static class TestCards
{
    public static Card Make(string name, int danger = 0) =>
        new(name, new Dictionary<Parameter, int> { [Parameter.Danger] = danger });
}
