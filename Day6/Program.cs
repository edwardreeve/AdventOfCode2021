var sourceData = File.ReadAllText("Day6Data.txt")
    .Trim()
    .Split(",")
    .Select(int.Parse)
    .ToList();

void Part1(int days)
{
    // not working. same issue.
    // there are only 9 possible values that a fish can have
    // find a way to calculate how many fish are in each of those positions after each day
    var fishes = sourceData.Select(x => new Fish(x));
    ulong totalFish = 0;
    foreach (var fish in fishes)
    {
        totalFish += fish.IncreaseAge(days).CountFamily();
    }
    Console.WriteLine($"After {days} days, there would be {totalFish} lanternfish");
}

// Part1(80);
Part1(256);

public class Fish
{
    private int _daysUntilBirth;
    private readonly List<Fish> _children = new();
    
    public Fish(int daysUntilBirth)
    {
        _daysUntilBirth = daysUntilBirth;
    }

    public Fish IncreaseAge(int days)
    {
        for (var i = 0; i < days; i++)
        {
            AddDay();
        }

        return this;
    }

    public ulong CountFamily()
    {
        ulong result = 1;
        foreach (var child in _children)
        {
            result += child.CountFamily();
        }

        return result;
    }

    private void AddDay()
    {
        var giveBirth = _daysUntilBirth == 0;
        _daysUntilBirth = giveBirth ? 6 : _daysUntilBirth - 1;
        foreach (var child in _children)
        {
            child.AddDay();
        }
        if (giveBirth) _children.Add(new Fish(8));
    }
}