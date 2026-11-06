using Xunit;

namespace Coraabia.Tests;

public class GameTests
{
    [Fact]
    public void Play_PlayerHasHigherStat_ReturnsPlayerWins()
    {
        var player = MakeCard("Fila", danger: 6);
        var enemy = MakeCard("Enemy", danger: 5);
        var game = new Game(player, enemy);

        var outcome = game.Play(Parameter.Danger);

        Assert.Equal(Outcome.PlayerWins, outcome);
    }

    private static Card MakeCard(string name, int danger) =>
        new(name, new Dictionary<Parameter, int> { [Parameter.Danger] = danger });
}
