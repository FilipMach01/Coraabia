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

    [Fact]
    public void Play_PlayerTopCardHigher_PlayerTakesBothCards()
    {
        var player = new Deck([TestCards.Make("Fila", danger: 6)]);
        var enemy = new Deck([TestCards.Make("Enemy", danger: 5)]);
        var game = new Game(player, enemy);

        game.Play(Parameter.Danger);

        Assert.Equal(2, player.Count);
        Assert.Equal(0, enemy.Count);
    }

    [Fact]
    public void Play_EnemyTopCardHigher_EnemyTakesBothCards()
    {
        var player = new Deck([TestCards.Make("Fila", danger: 5)]);
        var enemy = new Deck([TestCards.Make("Enemy", danger: 6)]);
        var game = new Game(player, enemy);

        game.Play(Parameter.Danger);

        Assert.Equal(0, player.Count);
        Assert.Equal(2, enemy.Count);
    }

    [Fact]
    public void Play_EqualStats_EachPlayerKeepsOwnCard()
    {
        var player = new Deck([TestCards.Make("Fila", danger: 5)]);
        var enemy = new Deck([TestCards.Make("Enemy", danger: 5)]);
        var game = new Game(player, enemy);

        game.Play(Parameter.Danger);

        Assert.Equal(1, player.Count);
        Assert.Equal(1, enemy.Count);
    }

    [Fact]
    public void IsOver_EnemyDeckEmpty_ReturnsTrue()
    {
        var player = new Deck([TestCards.Make("Fila")]);
        var enemy = new Deck([]);
        var game = new Game(player, enemy);

        var isOver = game.IsOver;

        Assert.True(isOver);
    }

    [Fact]
    public void Result_EnemyDeckEmpty_ReturnsPlayerWins()
    {
        var player = new Deck([TestCards.Make("Fila")]);
        var enemy = new Deck([]);
        var game = new Game(player, enemy);

        var result = game.Result;

        Assert.Equal(Outcome.PlayerWins, result);
    }

    [Fact]
    public void Result_PlayerDeckEmpty_ReturnsEnemyWins()
    {
        var player = new Deck([]);
        var enemy = new Deck([TestCards.Make("Enemy")]);
        var game = new Game(player, enemy);

        var result = game.Result;

        Assert.Equal(Outcome.EnemyWins, result);
    }

    [Fact]
    public void Play_GameIsOver_ThrowsInvalidOperationException()
    {
        var player = new Deck([TestCards.Make("Fila")]);
        var enemy = new Deck([]);
        var game = new Game(player, enemy);

        void Act() => game.Play(Parameter.Danger);

        Assert.Throws<InvalidOperationException>(Act);
    }

    [Fact]
    public void PlayerCard_PlayerHasCards_ReturnsTopCard()
    {
        var top = TestCards.Make("Fila");
        var player = new Deck([top, TestCards.Make("Other")]);
        var enemy = new Deck([TestCards.Make("Enemy")]);
        var game = new Game(player, enemy);

        var card = game.PlayerCard;

        Assert.Same(top, card);
    }

    [Fact]
    public void EnemyCard_EnemyHasCards_ReturnsTopCard()
    {
        var top = TestCards.Make("Enemy");
        var player = new Deck([TestCards.Make("Fila")]);
        var enemy = new Deck([top, TestCards.Make("Other")]);
        var game = new Game(player, enemy);

        var card = game.EnemyCard;

        Assert.Same(top, card);
    }
}
