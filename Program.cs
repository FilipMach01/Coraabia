using System.Diagnostics;

namespace Coraabia;

public enum Parameter
{
    Intellect,
    Danger,
    Power
};
class Card(string name, Dictionary<Parameter, int> stats)
{
    private string _name = name ?? throw new ArgumentNullException(nameof(name));
    private Dictionary<Parameter, int> Stats = stats ?? throw new ArgumentNullException(nameof(stats));

    public int GetStats(Parameter parameter)
    {
        return Stats.GetValueOrDefault(parameter, 0);
    }

    public string Print()
    {
        return $"{_name}";
    }
    
}

class Game(Card player, Card enemy)
{
    public Card? Play(Parameter parameter)
    {
        int playerValue = player.GetStats(parameter);
        int enemyValue = enemy.GetStats(parameter);
        
        if (playerValue > enemyValue) return player;
        if (enemyValue > playerValue) return enemy;
        return null;

    }
    
}

class Program
{
    static void Main()
    {
        var playerStats = new Dictionary<Parameter, int>
        {
            { Parameter.Intellect, 3 },
            { Parameter.Danger, 5 },
            { Parameter.Power, 7 }
        };
        Card player = new Card("Fila", playerStats);
        
        var enemyStats = new Dictionary<Parameter, int>
        {
            { Parameter.Intellect, 4 },
            { Parameter.Danger, 3 },
            { Parameter.Power, 8 }
        };
        Card enemy = new Card("Zaporak", enemyStats);

        var game = new Game(player, enemy);
        Card? winner = game.Play(Parameter.Danger);
        Console.WriteLine(winner == null ? "Remíza" : winner.Print());
    }
}