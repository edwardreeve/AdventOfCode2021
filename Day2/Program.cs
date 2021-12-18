var data = File.ReadLines("Day2Data.txt")
    .Select(line => line.Split(" "))
    .ToArray();

void Part1()
{
    var horizontal = 0;
    var depth = 0;
    
    for (int i = 0; i < data.Length; i++)
    {
        var movement = int.Parse(data[i][1]);

        switch (data[i][0])
        {
            case "forward":
                horizontal += movement;
                break;
            case "down":
                depth += movement;
                break;
            case "up":
                depth -= movement;
                break;
        }
    }
    
    Console.WriteLine($"Part 1 answer is {horizontal * depth}");
}

void Part2()
{
    var horizontal = 0;
    var depth = 0;
    var aim = 0;
    
    for (int i = 0; i < data.Length; i++)
    {
        var movement = int.Parse(data[i][1]);
        
        switch (data[i][0])
        {
            case "forward":
                horizontal += movement;
                depth += aim * movement;
                break;
            case "down":
                aim += movement;
                break;
            case "up":
                aim -= movement;
                break;
        }
    }
    
    Console.WriteLine($"Part 2 answer is {horizontal * depth}");
}

Part1();
Part2();