namespace Coraabia;

public class Game(Deck player, Deck enemy)
{
    public Card PlayerCard => player.TopCard;
    public Card EnemyCard => enemy.TopCard;
    public bool IsOver => player.Count == 0 || enemy.Count == 0;

    public Outcome Result => (player.Count, enemy.Count) switch
    {
        (0, _) => Outcome.EnemyWins,
        (_, 0) => Outcome.PlayerWins,
        (_, _) => Outcome.Draw
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
        
        var winner = outcome switch
        {
            Outcome.EnemyWins => enemy,
            Outcome.PlayerWins => player,
            _ => null
        };
        
        if (winner != null)
        {Take(winner,playerCard,enemyCard);}
        else
        {
            player.AddCard(playerCard);
            enemy.AddCard(enemyCard);
        }
        
        

        
        return outcome;

    }
}