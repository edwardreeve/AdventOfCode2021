var sourceData = File.ReadAllText("Day6Data.txt")
    .Trim()
    .Split(",")
    .Select(int.Parse)
    .ToList();

void Part1(int days)
{
    var fishToCount = sourceData.ToList();

    for (int j = 0; j < days; j++)
    {
        var extraFish = 0;
        for (int i = 0; i < fishToCount.Count; i++)
        {
            var number = fishToCount[i];
            var newFish = number == 0;
            fishToCount[i] = newFish ? 6 : number - 1;
            if (newFish) extraFish++;
        }

        var fishToAdd = new List<int>();
        for (int i = 0; i < extraFish; i++)
        {
            fishToAdd.Add(8);
        }
        fishToCount.AddRange(fishToAdd);
    }
    
    Console.WriteLine($"Part 1 answer: after {days} days, there would be {fishToCount.Count} lanternfish");
}

Part1(80);
// Part1(256);