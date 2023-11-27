
const int boardSize = 8; 
bool[,] board = new bool[boardSize, boardSize];

Console.WriteLine("Board");
PrintBoard(board);
Console.WriteLine();

bool result = SolveColumn(board, 0); 
if (result) Console.WriteLine("Resolved.");
PrintBoard(board);

// end of program 

void PrintBoard(bool[,] board)
{
    for (int i = 0; i < boardSize; i++)
    {
        for (int j = 0; j < boardSize; j++)
        {
            Console.Write(" {0} ", (board[i,j] ? 1 : 0));
        };
        Console.WriteLine();
    };
}

bool SolveColumn(bool[,] board, int column)
{
    if (column >= boardSize) return true;

    for (int r = 0; r < boardSize; r++)
    {
        if (TryPosition(board, r, column))
        {
            board[r, column] = true;
            if (SolveColumn(board, column+1)) return true;
            board[r, column] = false;
        }
    }
    return false;
}

bool TryPosition(bool[,] board, int row, int column)
{
    // 水平
    for (int i = 0; i < column; i++) if (board[row, i]) return false;

    // 左上
    int r = row;
    int c = column;
    while (--r >= 0 && --c >= 0) if (board[r, c]) return false;

    // 左下
    r = row;
    c = column;
    while (++r < boardSize && --c >= 0) if (board[r, c]) return false;

    return true;
}

