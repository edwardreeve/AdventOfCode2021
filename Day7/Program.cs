var sourceData = File.ReadAllText("Day7Data.txt")
    .Trim()
    .Split(",")
    .Select(int.Parse);

void Part1()
{
    var midpoint = sourceData.Count() / 2;
    var sortedCrabs = sourceData.OrderBy(n=>n).ToList();
    var median = sourceData.Count() % 2 == 0
        ? (sortedCrabs[midpoint] + sortedCrabs[midpoint - 1]) / 2
        : sortedCrabs[midpoint];

    var fuelUsed = sourceData.Sum(x => Math.Abs(x - median));
    
    Console.WriteLine($"The answer for part 1 is {fuelUsed}");
}

// Tried doing the equivalent as part one, but by calculating the mean instead of the median
// Didn't work. Reddit says there are rounding errors. Trying another way.
void Part2()
{
    var minCrab = sourceData.Min();
    var maxCrab = sourceData.Max();
    var positionsInRange = maxCrab - minCrab + 1;
    var answer = Enumerable.Range(minCrab, positionsInRange)
        .Select(x => sourceData.Select(d => Math.Abs(d - x)).Sum()).Min();
    Console.WriteLine($"Alternative method question 1 answer = {answer}");
}

Part1();
Part2();
