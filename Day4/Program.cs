var sourceData = File.ReadLines("Day4Example.txt").ToArray();

void Part1()
{
    var bingoCalls = sourceData.First().Split(",");

    var bingoBoards = sourceData.Take(1..)
        .Where(dataRow => !string.IsNullOrEmpty(dataRow))
        .Chunk(5)
        .Select(boardData => new BingoBoard(boardData));
}

Part1();

public class BingoBoard
{
    private string[] BoardData;
    public BingoBoard(string[] boardData)
    {
        BoardData = boardData;
    }
}