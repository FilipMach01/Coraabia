using System.Runtime.InteropServices;

namespace Coraabia;

public class Deck(List<Card> cards)
{
    public int Count => cards.Count;
    public Card TopCard => cards[0];

    public Card Draw()
    {
        var card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public (Deck Player, Deck Enemy) Deal()
    {
        List<Card> playerCards = [];
        List<Card> enemyCards = [];
        int cardCount = cards.Count;

        for (int i = 0; i < cardCount; i++)
        {
            var target = i % 2 == 0 ? playerCards : enemyCards;
            target.Add(Draw());
        }

        return (new Deck(playerCards), new Deck(enemyCards));
    }

    public void Shuffle()
    {
        Random.Shared.Shuffle(CollectionsMarshal.AsSpan(cards));
    }

    public override string ToString()
    {
        return $"{string.Join(Environment.NewLine, cards)}";
    }
}