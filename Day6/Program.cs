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

void Attempt3(int days)
{
    // var fishAges = Enumerable.Range(0, 9)
    //     .Select(x => new
    //     {
    //         Age = x,
    //         Count = sourceData.Count(fishAge => fishAge == x)
    //     })
    //     .OrderByDescending(x => x.Age)
    //     .ToList();

    // var fishAges = new List<(int Age, int Count)>();
    // for (int i = 8; i >= 0; i--)
    // {
    //     fishAges.Add((i, sourceData.Count(fishAge => fishAge == i)));
    // }
    //
    // for (int i = 0; i < days; i++)
    // {
    //     foreach (var fishAge in fishAges)
    //     {
    //         fishAges[fishAge.Age].Count = fishAge.Count;
    //     }
    // }

    var fishAgeArray = new long[9];
    var groupedFishAges = sourceData.GroupBy(x => x);
    foreach (var group in groupedFishAges)
    {
        fishAgeArray[group.Key] = group.Count();
    }

    for (int i = 0; i < days; i++)
    {
        var newFish = fishAgeArray[0];
        fishAgeArray[0] = fishAgeArray[1];
        fishAgeArray[1] = fishAgeArray[2];
        fishAgeArray[2] = fishAgeArray[3];
        fishAgeArray[3] = fishAgeArray[4];
        fishAgeArray[4] = fishAgeArray[5];
        fishAgeArray[5] = fishAgeArray[6];
        fishAgeArray[6] = fishAgeArray[7] + newFish;
        fishAgeArray[7] = fishAgeArray[8];
        fishAgeArray[8] = newFish;
    }
    
    Console.WriteLine($"After {days} days, there would be {fishAgeArray.Sum(x => x)} lanternfish");
}

// Part1(80);
Attempt3(256);

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