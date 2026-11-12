using Xunit;

namespace Coraabia.Tests;

public class GameTests
{
    [Fact]
    public void Play_PlayerTopCardHigher_ReturnsPlayerWins()
    {
        var player = new Deck([TestCards.Make("Fila", danger: 6)]);
        var enemy = new Deck([TestCards.Make("Enemy", danger: 5)]);
        var game = new Game(player, enemy);

        var outcome = game.Play(Parameter.Danger);

        Assert.Equal(Outcome.PlayerWins, outcome);
    }
}
