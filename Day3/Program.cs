using System.Xml.Schema;

var data = File.ReadLines("Day3Data.txt")
    .Select(line => line.ToArray())
    .ToArray();

void Part1()
{
    var numberOfLines = data.Length;
    var numberOfBits = data.First().Length;
    var aggregate = new char[numberOfBits, numberOfLines];
    for (int i = 0; i < numberOfLines; i++)
    {
        for (int j = 0; j < numberOfBits; j++)
        {
            aggregate[j, i] = data[i][j];
        }
    }

    var gammaString = string.Empty;
    
    for (int i = 0; i < numberOfBits; i++)
    {
        var commonCharacter = Enumerable.Range(0, numberOfLines)
            .Select(x => aggregate[i, x])
            .ToArray()
            .GroupBy(character => character)
            .OrderByDescending(grouping =>grouping.Count())
            .Select(grouping => grouping.Key)
            .First();

        gammaString += commonCharacter;
    }

    var epsilonString = new string(gammaString.Select(character => character == '1' ? '0' : '1').ToArray());
    var gamma = Convert.ToInt32(gammaString, 2);
    var epsilon = Convert.ToInt32(epsilonString, 2);

    Console.WriteLine($"The answer for part 1 is gamma({gamma}) x epsilon" +
                      $"({epsilon}) = {gamma * epsilon}");
}

Part1();