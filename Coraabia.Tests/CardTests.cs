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

    [Fact]
    public void ToString_CardWithStats_ListsNameAndStats()
    {
        var stats = new Dictionary<Parameter, int>
        {
            [Parameter.Intellect] = 3,
            [Parameter.Danger] = 5,
            [Parameter.Power] = 7
        };
        var card = new Card("Fila", stats);

        var text = card.ToString();

        Assert.Equal("Fila (Intellect 3, Danger 5, Power 7)", text);
    }

    [Fact]
    public void GetStat_StatNotProvided_ReturnsZero()
    {
        var card = new Card("Fila", new Dictionary<Parameter, int>());

        var value = card.GetStat(Parameter.Power);

        Assert.Equal(0, value);
    }
}
