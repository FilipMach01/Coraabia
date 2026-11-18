using System.Runtime.InteropServices;

namespace Coraabia;

public class Deck(List<Card> cards)
{
    public int Count => cards.Count;

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
        while (cards.Count > 0)
        {
            playerCards.Add(Draw());
            enemyCards.Add(Draw());
        }

        return (new Deck(playerCards), new Deck(enemyCards));
    }

    public void Shuffle()
    {
        Random.Shared.Shuffle(CollectionsMarshal.AsSpan(cards));
    }

    public bool IsOver()
    {
        if (Count == 0)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{string.Join(Environment.NewLine, cards)}";
    }
}