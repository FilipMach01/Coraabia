namespace Coraabia;

class Card(string name, Dictionary<Parameter, int> stats)
{
    public readonly string Name = name ?? throw new ArgumentNullException(nameof(name));
    private readonly Dictionary<Parameter, int> _stats = stats ?? throw new ArgumentNullException(nameof(stats));

    public int GetStat(Parameter parameter)
    {
        return _stats.GetValueOrDefault(parameter, 0);
    }

    public string PrintInfo()
    {
        return $"{Name.ToUpper()} \n Intellect = {_stats[Parameter.Intellect]} \n Danger = {_stats[Parameter.Danger]} \n Power = {_stats[Parameter.Power]}";
    }
    
}