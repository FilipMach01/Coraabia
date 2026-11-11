namespace Coraabia;

public class Deck(List<Card> cards)
{
    public int Count => cards.Count;

    public Card Draw()
    {
        var hand = cards[0];
        cards.RemoveAt(0);
        return hand;
    }
}