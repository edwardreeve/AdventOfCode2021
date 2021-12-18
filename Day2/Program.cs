var data = File.ReadLines("Day2Data.txt")
    .Select(line => line.Split(" "))
    .ToArray();

void Part1()
{
    var horizontal = 0;
    var depth = 0;
    
    for (int i = 0; i < data.Length; i++)
    {
        switch (data[i][0])
        {
            case "forward":
                horizontal += int.Parse(data[i][1]);
                break;
            case "down":
                depth += int.Parse(data[i][1]);
                break;
            case "up":
                depth -= int.Parse(data[i][1]);
                break;
        }
    }
    
    Console.WriteLine($"Part 1 answer is {horizontal * depth}");
}

Part1();