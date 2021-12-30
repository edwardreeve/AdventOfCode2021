var data = File.ReadLines("Day1Data.txt")
    .Select(int.Parse)
    .ToArray();

void Part1()
{
    var counter = 0;
    for (var i = 1; i < data.Length; i++)
    {
        if (data[i] > data[i - 1]) counter += 1;
    }

    Console.WriteLine($"Part 1 answer is {counter}");
}

void Part2()
{
    var previousTotal = 0;
    var counter = 0;
    for (var i = 1; i < data.Length - 2; i++)
    {
        var total = data[i..(i + 3)].Sum();
        if (total > previousTotal) counter += 1;
        previousTotal = total;
    }

    Console.WriteLine($"Part 2 answer is {counter}");
}

Part1();
Part2();