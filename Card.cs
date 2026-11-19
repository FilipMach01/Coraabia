namespace Coraabia;

public class Card(string name, Dictionary<Parameter, int> stats)
{
    public string Name { get; } = name;
    public int GetStat(Parameter parameter) => stats.GetValueOrDefault(parameter, 0);

    public override string ToString()
    {
        return $"{name} (Intellect {GetStat(Parameter.Intellect)}, Danger {GetStat(Parameter.Danger)}, Power {GetStat(Parameter.Power)})";
    }
}
