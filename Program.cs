namespace Coraabia;
internal enum Parameter
{
    Intellect,
    Danger,
    Power
}

internal enum Outcome
{
    PlayerWins,
    EnemyWins,
    Draw
}
internal record GameResult(Outcome Outcome, Card? Winner);
internal class Game(Card player, Card enemy)
{
    
    public GameResult Play(Parameter p) =>
        player.GetStat(p).CompareTo(enemy.GetStat(p)) switch
        {
            > 0 => new GameResult(Outcome.PlayerWins, player),
            < 0 => new GameResult(Outcome.EnemyWins, enemy),
            _   => new GameResult(Outcome.Draw,null)
        };

}

internal static class Program
{
    private static void Main()
    {
        var playerStats = new Dictionary<Parameter, int>
        {
            { Parameter.Intellect, 3 },
            { Parameter.Danger, 5 },
            { Parameter.Power, 7 }
        };
        var player = new Card("Fila", playerStats);
        
        var enemyStats = new Dictionary<Parameter, int>
        {
            { Parameter.Intellect, 4 },
            { Parameter.Danger, 6 },
            { Parameter.Power, 8 }
        };
        var enemy = new Card("Enemy", enemyStats);

        var game = new Game(player, enemy);
        var result = game.Play(Parameter.Danger);
        Console.WriteLine(result.Outcome);
        Console.WriteLine(result.Winner?.PrintInfo() ?? "Draw");
    }
}