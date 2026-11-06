using Xunit;

namespace Coraabia.Tests;

public class CardTests
{
    [Fact]
    public void Name_CardCreatedWithName_ReturnsThatName()
    {
        var card = new Card("Fila", new Dictionary<Parameter, int>());

        Assert.Equal("Fila", card.Name);
    }

    [Fact]
    public void GetStat_StatProvided_ReturnsItsValue()
    {
        var stats = new Dictionary<Parameter, int> { [Parameter.Danger] = 5 };
        var card = new Card("Fila", stats);

        Assert.Equal(5, card.GetStat(Parameter.Danger));
    }
}
