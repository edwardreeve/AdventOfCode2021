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
    Console.WriteLine($"The part1 answer is {result}");
}

Part1();

record Line(int x1, int x2, int y1, int y2)
{
    public List<(int, int)> GetCoordinates()
    {
        var numberOfCoordinates = Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
        var largestX = Math.Max(x1, x2);
        var largestY = Math.Max(y1, y2);
        var xDifference = x1 != x2;
        var yDifference = y1 != y2;
        var coordinates = new List<(int, int)>();
        
        for (int i = 0; i <= numberOfCoordinates; i++)
        {
            coordinates.Add((xDifference ? largestX - i : largestX, yDifference ? largestY - i : largestY));
        }

        return coordinates;
    }
};