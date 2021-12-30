var sourceData = File.ReadLines("Day9Data.txt")
    .Select(x => x.ToArray()
        .Select(c => int.Parse(c.ToString()))
        .ToArray())
    .ToArray();

void Part1()
{
    var lowestPoints = new List<int>();
    
    for (var rowIndex = 0; rowIndex < sourceData.Length; rowIndex++)
    {
        var row = sourceData[rowIndex];
        for (var depthIndex = 0; depthIndex < row.Length; depthIndex++)
        {
            var depth = row[depthIndex];
            
            if (depthIndex > 0) if (row[depthIndex - 1] <= depth) continue;
            if (depthIndex < row.Length - 1) if (row[depthIndex + 1] <= depth) continue;
            if (rowIndex > 0) if (sourceData[rowIndex - 1][depthIndex] <= depth) continue;
            if (rowIndex < sourceData.Length - 1) if (sourceData[rowIndex + 1][depthIndex] <= depth) continue;

            lowestPoints.Add(depth);
        }
    }

    var result = lowestPoints.Sum(x => x + 1);

    Console.WriteLine($"The answer to part one is {result}");
}

Part1();