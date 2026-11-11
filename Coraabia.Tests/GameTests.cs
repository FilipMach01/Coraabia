using Xunit;

namespace Coraabia.Tests;

public class GameTests
{
    [Fact]
    public void Play_PlayerHasHigherStat_ReturnsPlayerWins()
    {
        var player = TestCards.Make("Fila", danger: 6);
        var enemy = TestCards.Make("Enemy", danger: 5);
        var game = new Game(player, enemy);

        var outcome = game.Play(Parameter.Danger);

        Assert.Equal(Outcome.PlayerWins, outcome);
    }
}
