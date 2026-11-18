namespace Coraabia;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Coraabia");
        List<Card> playerCards =
        [
            CreateCard("sigoue", 7, 5, 3),
            CreateCard("seg", 6, 6, 1),
            CreateCard("erh", 5, 9, 4),
            CreateCard("drky", 6, 9, 4),
            CreateCard("atw4", 6, 1, 4),
        ];
        Deck player = new Deck(playerCards);
        List<Card> enemyCards = playerCards.Select(card =>
                CreateCard(card.Name,
            card.GetStat(Parameter.Power),
            card.GetStat(Parameter.Intellect),
            card.GetStat(Parameter.Danger)))
            .ToList();
        Deck enemy = new Deck(enemyCards);
        player.Shuffle();
        enemy.Shuffle();

        Console.WriteLine(player);
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine(enemy);
        Console.WriteLine("drawn Card: ");
        Console.WriteLine(player.Draw());
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine(player);
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine(enemy);


        Card CreateCard(string name, int danger, int intellect, int power)
        {
            return new Card(name, new Dictionary<Parameter, int>()
            {
                { Parameter.Danger, danger },
                { Parameter.Intellect, intellect },
                { Parameter.Power, power }
            });
        }
    }
}