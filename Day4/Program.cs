var sourceData = File.ReadLines("Day4Data.txt").ToArray();

void Part1()
{
    var bingoCalls = sourceData.First().Split(",");

    var bingoBoards = sourceData.Take(1..)
        .Where(dataRow => !string.IsNullOrEmpty(dataRow))
        .Chunk(5)
        .Select(boardData => new BingoBoard(boardData))
        .ToList();

    var winner = false;
    foreach (var call in bingoCalls)
    {
        foreach (var board in bingoBoards)
        {
            board.MarkCall(call);
            winner = board.HasWinningLine();
            if (winner)
            {
                var score = board.CalculateScore(call);
                Console.WriteLine($"Winning board found. Score = {score}");
                break;
            }
        }

        if (winner) break;
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

    public bool HasWinningLine()
    {
        var rows = new List<(int, int, int, int, int)>
        {
            (0, 1, 2, 3, 4),
            (5, 6, 7, 8, 9),
            (10, 11, 12, 13, 14),
            (15, 16, 17, 18, 19),
            (20, 21, 22, 23, 24)
        };

        var columns = new List<(int, int, int, int, int)>
        {
            (0, 5, 10, 15, 20),
            (2, 6, 11, 16, 21),
            (2, 7, 12, 17, 22),
            (3, 8, 13, 18, 23),
            (4, 9, 14, 19, 24)
        };
        
        var winningLines = rows.Union(columns);
        bool winner = false;
        foreach (var (a, b, c, d, e) in winningLines)
        {
            if (new[] {_results[a], _results[b], _results[c], _results[d], _results[e]}.Distinct().Count() != 1) continue;
            winner = true;
            break;
        }

        return winner;
    }

    public int CalculateScore(string call)
    {
        var sumOfUnmarkedBoard = _results.Where(x => x > 0).Sum();
        return sumOfUnmarkedBoard * int.Parse(call);
    }
}