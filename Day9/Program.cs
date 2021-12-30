var sourceData = File.ReadLines("Day9Data.txt")
    .Select(x => x.ToArray()
        .Select(c => new depthRecord(c))
        .ToArray())
    .ToArray();

void Part1()
{
    for (var i = 0; i < sourceData.Length; i++)
    {
        var sourceRow = sourceData[i];
        for (var j = 0; j < sourceRow.Length; j++)
        {
            var record = sourceRow[j];
            var lowest = true;
            if (j > 0) // horizontal; check to the left if we're past the zero index
            {
                if (sourceRow[j - 1].Depth <= record.Depth)
                {
                    lowest = false;
                }
            }

            if (j < sourceRow.Length - 1) // horizontal; check to the right if we're not at the final row
            {
                if (sourceRow[j + 1].Depth <= record.Depth)
                {
                    lowest = false;
                }
            }

            if (i > 0) // vertical; check above if we're past the zero index
            {
                if (sourceData[i - 1][j].Depth <= record.Depth)
                {
                    lowest = false;
                }
            }

            if (i < sourceData.Length - 1) // vertical; check the next if we're not at the final row
            {
                if (sourceData[i + 1][j].Depth <= record.Depth)
                {
                    lowest = false;
                }
            }

            record.Lowest = lowest;
        }
    }

    var result = sourceData.SelectMany(row => row)
        .Where(record => record.Lowest.Value)
        .Select(x => x.Depth + 1)
        .Sum();

    Console.WriteLine($"The answer to part one is {result}");
}

Part1();

class depthRecord
{
    public int Depth { get; }
    public bool? Lowest { get; set; } = null;

    public depthRecord(char depth)
    {
        Depth = int.Parse(depth.ToString());
    }
}
