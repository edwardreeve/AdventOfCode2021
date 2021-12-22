// See https://aka.ms/new-console-template for more information

var sourceData = File.ReadAllText("Day7Data.txt")
    .Trim()
    .Split(",")
    .Select(int.Parse);

void Part1()
{
    var halfIndex = sourceData.Count() / 2;
    var sortedCrabs = sourceData.OrderBy(n=>n).ToList();
    var median = sourceData.Count() % 2 == 0
        ? (sortedCrabs[halfIndex] + sortedCrabs[halfIndex - 1]) / 2
        : sortedCrabs[halfIndex];

    var fuelUsed = 0;
    foreach (var crab in sourceData)
    {
        fuelUsed += Math.Abs(crab - median);
    }
    
    Console.WriteLine($"The answer for part 1 is {fuelUsed}");
}

Part1();