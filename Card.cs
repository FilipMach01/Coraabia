namespace Coraabia;


class Card(string name, Dictionary<Parameter, int> stats)
{
    public string Name { get; } = name;
    public int GetStat(Parameter parameter) => stats[parameter];
}
