var sourceData = File.ReadLines("Day3Data.txt")
    .Select(line => line.ToArray())
    .ToArray();

var numberOfBits = sourceData.First().Length;

char GetCharacter(int columnIndex, char[][] data, bool mostCommon = true)
{
    var numberOfRows = data.GetLength(0);

    var groupedColumn = Enumerable.Range(0, numberOfRows)
        .Select(x => data[x][columnIndex])
        .GroupBy(character => character);
    
    groupedColumn = mostCommon
        ? groupedColumn.OrderByDescending(grouping => grouping.Count()).ThenByDescending(group => group.Key)
        : groupedColumn.OrderBy(grouping => grouping.Count()).ThenBy(group => group.Key);

    var character = groupedColumn.Select(grouping => grouping.Key).First();
    return character;
}

string GetFilteredList(char[][] data, bool mostCommon = true)
{
    for (int i = 0; i < numberOfBits && data.Length > 1; i++)
    {
        var character = GetCharacter(i, data, mostCommon);
        data = data.Where(entry => entry[i] == character).ToArray();
    }

    return new string(data.Single());
}

int BitStringToInt(string bitString)
{
    return Convert.ToInt32(bitString, 2);
}

void Part1()
{
    var gammaString = string.Empty;

    for (int i = 0; i < numberOfBits; i++)
    {
        gammaString += GetCharacter(i, sourceData);
    }

    var epsilonString = new string(gammaString.Select(character => character == '1' ? '0' : '1').ToArray());
    var gamma = BitStringToInt(gammaString);
    var epsilon = BitStringToInt(epsilonString);

    Console.WriteLine($"The answer for part 1 is gamma({gamma}) x epsilon" +
                      $"({epsilon}) = {gamma * epsilon}");
}

void Part2()
{
    var oxygenGeneratorRating = GetFilteredList(sourceData);
    var co2ScrubberRating = GetFilteredList(sourceData, false);
    var oxInt = BitStringToInt(oxygenGeneratorRating);
    var co2Int = BitStringToInt(co2ScrubberRating);

    Console.WriteLine($"Part 2 answer: ox rating is {oxygenGeneratorRating} / {oxInt}, co2 is {co2ScrubberRating} / {co2Int} \n" +
                      $"Life Support rating is {oxInt * co2Int}");
}

Part1();
Part2();