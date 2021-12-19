var sourceData = File.ReadLines("Day3Data.txt")
    .Select(line => line.ToArray())
    .ToArray();

var numberOfBits = sourceData.First().Length;

char[,] GetTransformedData(char[][] originalData)
{
    var numberOfLines = originalData.Length;
    var transformedData = new char[numberOfBits, numberOfLines];
    for (int i = 0; i < numberOfLines; i++)
    {
        for (int j = 0; j < numberOfBits; j++)
        {
            transformedData[j, i] = originalData[i][j];
        }
    }

    return transformedData;
}

char GetCharacter(int columnIndex, char[,] data, bool mostCommon = true)
{
    var numberOfLines = data.GetLength(1);

    var c = Enumerable.Range(0, numberOfLines)
        .Select(x => data[columnIndex, x])
        .ToArray()
        .GroupBy(character => character);

    c = mostCommon
        ? c.OrderByDescending(grouping => grouping.Count()).ThenByDescending(group => group.Key)
        : c.OrderBy(grouping => grouping.Count()).ThenBy(group => group.Key);

    var result = c.Select(grouping => grouping.Key).First();
    return result;
}

string GetFilteredList(char[][] data, bool mostCommon = true)
{
    var listToFilter = data;
    for (int i = 0; i < numberOfBits && listToFilter.Length > 1; i++)
    {
        var transformedData = GetTransformedData(listToFilter);
        var character = GetCharacter(i, transformedData, mostCommon);
        listToFilter = listToFilter.Where(entry => entry[i] == character).ToArray();
    }

    return new string(listToFilter.Single());
}

int BitStringToInt(string bitString)
{
    return Convert.ToInt32(bitString, 2);
}

void Part1()
{
    var gammaString = string.Empty;
    var transformedData = GetTransformedData(sourceData);

    for (int i = 0; i < numberOfBits; i++)
    {
        gammaString += GetCharacter(i, transformedData);
    }

    var epsilonString = new string(gammaString.Select(character => character == '1' ? '0' : '1').ToArray());
    var gamma = BitStringToInt(gammaString);
    var epsilon = BitStringToInt(epsilonString);

    Console.WriteLine($"The answer for part 1 is gamma({gamma}) x epsilon" +
                      $"({epsilon}) = {gamma * epsilon}");
}

void Part2()
{
    // Oxygen - most common bit, if equal, '1' takes precedence
    // Filter until there's only one entry

    var oxygenGeneratorRating = GetFilteredList(sourceData);
    var co2ScrubberRating = GetFilteredList(sourceData, false);
    var oxInt = BitStringToInt(oxygenGeneratorRating);
    var co2Int = BitStringToInt(co2ScrubberRating);

    Console.WriteLine($"Part 2 answer: ox rating is {oxygenGeneratorRating} / {oxInt}, co2 is {co2ScrubberRating} / {co2Int} \n" +
                      $"Life Support rating is {oxInt * co2Int}");
}

Part1();
Part2();