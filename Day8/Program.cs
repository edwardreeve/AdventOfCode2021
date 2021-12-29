var sourceData = File.ReadLines("Day8Data.txt");

void Part1()
{
    var codes = sourceData.Select(x => x.Split("|")[1]
        .Trim()
        .Split(" ")
        .ToArray())
        .ToList();
    
    Console.WriteLine($"The answer to part 1 is {GetUniqueDigits(codes)}");
}

void Part2()
{
    var result = sourceData.Select(GetRowOutputNumber).Sum();
    Console.WriteLine($"The answer to part 2 is {result}");
}

int GetRowOutputNumber(string dataRow)
{
    var rowParts = dataRow.Split("|");
    var digits = GetDigitDictionary(rowParts[0]);
    var rowOutput = rowParts[1]
        .Trim()
        .Split(" ")
        .Select(x => string.Concat(x.OrderBy(c => c)));

    var rowOutputNumberAsString = rowOutput.Aggregate(string.Empty, (current, next) => current += digits[next].ToString());
    
    return int.Parse(rowOutputNumberAsString);
}

Dictionary<string, int> GetDigitDictionary(string data)
{
    Dictionary<string, int> digits = new Dictionary<string, int>();
    
    var examples = data.Trim()
        .Split(" ")
        .Select(x => string.Concat(x.OrderBy(c => c)))
        .ToArray();
    
    var eight = examples.Single(x => x.Length == 7);
    digits[eight] = 8;
    var one = examples.Single(x => x.Length == 2);
    digits[one] = 1;
    var four = examples.Single(x => x.Length == 4);
    digits[four] = 4;
    var seven = examples.Single(x => x.Length == 3);
    digits[seven] = 7;
    var six = examples.Single(x => x.Length == 6 && !ContainsDigit(x, one));
    digits[six] = 6;
    var five = examples.Single(x => x.Length == 5 && ContainsDigit(six, x));
    digits[five] = 5;
    var zero = examples.Single(x => x.Length == 6 && !digits.ContainsKey(x) && !ContainsDigit(x, four));
    digits[zero] = 0;
    var nine = examples.Single(x => x.Length == 6 && !digits.ContainsKey(x));
    digits[nine] = 9;
    var three = examples.Single(x => x.Length == 5 && ContainsDigit(x, one));
    digits[three] = 3;
    var two = examples.Single(x => !digits.ContainsKey(x));
    digits[two] = 2;
 
    return digits;
}

bool ContainsDigit(string source, string toCheck)
{
    return toCheck.All(character => source.Contains(character));
}

int GetUniqueDigits(List<string[]>? input)
{
    return input.Select(x => x.Count(IsUniqueDigit)).Sum();
}

bool IsUniqueDigit(string digit)
{
    int[] sectionsInUniqueDigits =
    {
        2,
        3,
        4,
        7
    };
    return sectionsInUniqueDigits.Contains(digit.Length);
}

Part1();
Part2();