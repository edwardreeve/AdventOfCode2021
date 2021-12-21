var sourceData = File.ReadLines("Day5Data.txt")
    .Select(x => x.Replace(" -> ", ",").Split(","))
    .Select(x =>
        new Line(int.Parse(x[0]), int.Parse(x[2]), int.Parse(x[1]), int.Parse(x[3])))
    .ToList();

void Part1()
{
    var filteredLines = sourceData.Where(line => line.x1 == line.x2 || line.y1 == line.y2).ToList();
    var coordinates = new List<(int, int)>();
    foreach (var line in filteredLines)
    {
        coordinates.AddRange(line.GetCoordinates());
    }

    var result = coordinates.GroupBy(x => x).Count(group => group.Count() >= 2);
    Console.WriteLine($"The part 1 answer is {result}");
}

void Part2()
{
    var coordinates = new List<(int, int)>();
    foreach (var line in sourceData)
    {
        coordinates.AddRange(line.GetCoordinates());
    }

    var result = coordinates.GroupBy(x => x).Count(group => group.Count() >= 2);
    Console.WriteLine($"The part 2 answer is {result}");
}

Part1();
Part2();


internal record Line(int x1, int x2, int y1, int y2)
{
    public IEnumerable<(int, int)> GetCoordinates()
    {
        var numberOfCoordinates = Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        var xDifference = x1 != x2;
        var yDifference = y1 != y2;
        var coordinates = new List<(int, int)>();
        
        for (var i = 0; i <= numberOfCoordinates; i++)
        {
            coordinates.Add((
                xDifference
                    ? x1 > x2 ? x1 - i : x1 + i
                    : x1,
                yDifference
                    ? y1 > y2 ? y1 - i : y1 + i
                    : y1));
        }

        return coordinates;
    }
};