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

int CalculateFuel(int positionsMoved)
{
    return Enumerable.Range(1, positionsMoved).Select(x => x).Sum();
}

void Part2()
{
    var minFuelUsed = Enumerable.Range(minCrab, positionsInRange)
        .Select(x => sourceData.Select(d => CalculateFuel(Math.Abs(d - x))).Sum())
        .Min();

    Console.WriteLine($"The answer for part 2 is {minFuelUsed}");
}

Part1();
Part2();