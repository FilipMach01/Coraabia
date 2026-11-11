using Xunit;

namespace Coraabia.Tests;

public class DeckTests
{
    [Fact]
    public void Count_DeckWithTwoCards_ReturnsTwo()
    {
        var deck = new Deck([TestCards.Make("Fila"), TestCards.Make("Enemy")]);

        var count = deck.Count;

        Assert.Equal(2, count);
    }

    [Fact]
    public void Draw_DeckWithTwoCards_ReturnsFirstCard()
    {
        var first = TestCards.Make("First");
        var deck = new Deck([first, TestCards.Make("Second")]);

        var card = deck.Draw();

        Assert.Same(first, card);
    }

    [Fact]
    public void Draw_DeckWithTwoCards_RemovesCardFromDeck()
    {
        var deck = new Deck([TestCards.Make("First"), TestCards.Make("Second")]);

        deck.Draw();

        Assert.Equal(1, deck.Count);
    }

    [Fact]
    public void Deal_DeckWithFourCards_GivesTwoCardsToEachPlayer()
    {
        var deck = new Deck([
            TestCards.Make("A"), TestCards.Make("B"), TestCards.Make("C"), TestCards.Make("D")
        ]);

        var (player, enemy) = deck.Deal();

        Assert.Equal(2, player.Count);
        Assert.Equal(2, enemy.Count);
    }

    [Fact]
    public void Shuffle_DeckWithManyCards_ChangesOrder()
    {
        var cards = Enumerable.Range(0, 20).Select(i => TestCards.Make($"Card{i}")).ToList();
        var deck = new Deck([..cards]);

        deck.Shuffle();

        Assert.NotEqual(cards, DrawAll(deck));
    }

    private static List<Card> DrawAll(Deck deck)
    {
        List<Card> drawn = [];
        while (deck.Count > 0)
            drawn.Add(deck.Draw());

        return drawn;
    }
}
