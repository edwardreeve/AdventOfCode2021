var sourceData = File.ReadLines("Day8Data.txt")
    .Select(x => x.Split("|")[1]
        .Trim()
        .Split(" ")
        .ToArray())
    .ToList();

void Part1()
{
    var result = GetUniqueDigits(sourceData);
    Console.WriteLine($"The answer to part 1 is {result}");
}

int GetUniqueDigits(List<string[]>? input)
{
    int[] sectionsInUniqueDigits =
    {
        2,
        3,
        4,
        7
    };
    return input.Select(x => x.Count(y => sectionsInUniqueDigits.Contains(y.Length))).Sum();
}

Part1();
