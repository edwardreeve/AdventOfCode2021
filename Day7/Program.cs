var sourceData = File.ReadAllText("Day7Data.txt")
    .Trim()
    .Split(",")
    .Select(int.Parse);

var minCrab = sourceData.Min();
var maxCrab = sourceData.Max();
var positionsInRange = maxCrab - minCrab + 1;

void Part1()
{
    var minFuelUsed = Enumerable.Range(minCrab, positionsInRange)
        .Select(x => sourceData.Select(d => Math.Abs(d - x)).Sum())
        .Min();

    Console.WriteLine($"The answer for part 1 is {minFuelUsed}");
}

void Part2()
{
}

Part1();
Part2();