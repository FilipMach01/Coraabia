using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Coraabia;

public class Game(Card player, Card enemy)
{
    public Outcome Play(Parameter parameter)
    {
        var playerStat = player.GetStat(parameter);
        var enemyStat = enemy.GetStat(parameter);

        return playerStat.CompareTo(enemyStat) switch
        {
            < 0 => Outcome.EnemyWins,
            0 => Outcome.Draw,
            > 0 => Outcome.PlayerWins
        };

        
    }
}