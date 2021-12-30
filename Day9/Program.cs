var sourceData = File.ReadLines("Day9Data.txt")
    .Select(x => x.ToArray()
        .Select(c => int.Parse(c.ToString()))
        .ToArray())
    .ToArray();

void Part1()
{
    var lowestPoints = new List<int>();
    
    for (var i = 0; i < sourceData.Length; i++)
    {
        var sourceRow = sourceData[i];
        for (var j = 0; j < sourceRow.Length; j++)
        {
            var depthReading = sourceRow[j];
            if (j > 0) 
            {
                if (sourceRow[j - 1] <= depthReading)
                {
                    continue;
                }
            }

            if (j < sourceRow.Length - 1) 
            {
                if (sourceRow[j + 1] <= depthReading)
                {
                    continue;
                }
            }

            if (i > 0) 
            {
                if (sourceData[i - 1][j] <= depthReading)
                {
                    continue;
                }
            }

            if (i < sourceData.Length - 1)
            {
                if (sourceData[i + 1][j] <= depthReading)
                {
                    continue;
                }
            }

            lowestPoints.Add(depthReading);
        }
    }

    var result = lowestPoints.Sum(x => x + 1);

    Console.WriteLine($"The answer to part one is {result}");
}

Part1();