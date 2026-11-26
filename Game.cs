namespace Coraabia;

public class Game(Deck player, Deck enemy)
{
    public Card PlayerCard => player.TopCard;

    public int PlayerCount => player.Count;
    public Card EnemyCard => enemy.TopCard;
    public int EnemyCount => enemy.Count;

    public bool IsOver => player.Count == 0 || enemy.Count == 0;

    private Outcome _lastWinner = Outcome.PlayerWins;
    public bool IsPlayerTurn => _lastWinner == Outcome.PlayerWins;

    public Parameter ChooseEnemyParameter() =>
        Enum.GetValues<Parameter>().MaxBy(parameter => EnemyCard.GetStat(parameter));

    public Outcome? Result => (player.Count, enemy.Count) switch
    {
        (0, _) => Outcome.EnemyWins,
        (_, 0) => Outcome.PlayerWins,
        (_, _) => null
    };
    
    private void Take(Deck winner, Card a, Card b)
    {
        winner.AddCard(a);
        winner.AddCard(b);
    }
    
    
    public Outcome Play(Parameter parameter)
    {
        if (IsOver) { throw new InvalidOperationException("The game is over."); }
        Card playerCard = player.Draw();
        Card enemyCard = enemy.Draw();
        var playerStat = playerCard.GetStat(parameter);
        var enemyStat = enemyCard.GetStat(parameter);

        var outcome = playerStat.CompareTo(enemyStat) switch
        {
            < 0 => Outcome.EnemyWins,
            0 => Outcome.Draw,
            > 0 => Outcome.PlayerWins
        };
        
        _lastWinner = outcome == Outcome.Draw ? _lastWinner : outcome;
        var winner = outcome switch
        {
            Outcome.EnemyWins => enemy,
            Outcome.PlayerWins => player,
            _ => null
        };

        if (winner != null)
        {
            Take(winner,playerCard,enemyCard);
        }
        else
        {
            player.AddCard(playerCard);
            enemy.AddCard(enemyCard);
        }
        return outcome;
    }
}