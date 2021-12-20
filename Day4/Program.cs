var sourceData = File.ReadLines("Day4Example.txt").ToArray();

void Part1()
{
    var bingoCalls = sourceData.First().Split(",");

    var bingoBoards = sourceData.Take(1..)
        .Where(dataRow => !string.IsNullOrEmpty(dataRow))
        .Chunk(5)
        .Select(boardData => new BingoBoard(boardData));

    foreach (var call in bingoCalls)
    {
        foreach (var board in bingoBoards)
        {
            board.MarkCall(call);
        }
    }
}

Part1();

public class BingoBoard
{
    private List<int> _boardData;
    private List<int> _results;
    private int _matchedNumber = -1;

    public BingoBoard(string[] boardData)
    {
        var allData = string.Join(" ", boardData);
        _boardData = allData.Split(" ")
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => int.Parse(x)).ToList();
        _results = _boardData.ToList();
    }

    public void MarkCall(string call)
    {
        var callNumber = int.Parse(call);
        if (_boardData.Contains(callNumber))
        {
            var index = _results.IndexOf(callNumber);
            _results[index] = _matchedNumber;
        }
    }
}