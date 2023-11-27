public class EightQueens
{
    private const int Rows = 8;  // can be started from 4 
    private int[,] _board = new int[Rows, Rows];
    
    
    public bool IsSafePutQueen(int[,] board, int row, int col)
    {
        int i, j;
 
        /* Check this row on left side */
        for (i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;
 
        /* Check upper diagonal on left side */
        for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;
 
        /* Check lower diagonal on left side */
        for (i = row, j = col; j >= 0 && i < Rows; i++, j--)
            if (board[i, j] == 1)
                return false;
 
        return true;
    }
    
    public bool SolveQueen(int[,] board, int col)
    {
        /* base case: If all queens are placed
           then return true */
        if (col >= Rows)
            return true;
 
        /* Consider this column and try placing
           this queen in all rows one by one */
        for (int row = 0; row < Rows; row++)
        {
            /* Check if the queen can be placed on
               board[i][col] */
            if (IsSafePutQueen(board, row, col))
            {
                /* Place this queen in board[i][col] */
                board[row, col] = 1;
 
                /* recur to place rest of the queens */
                if (SolveQueen(board, col + 1) == true)
                    return true;
 
                /* If placing queen in board[i][col]
                   doesn't lead to a solution, then
                   remove queen from board[i][col] */
                board[row, col] = 0; // BACKTRACK
            }
        }
 
        /* If the queen can not be placed in any row in
           this colum col, then return false */
        return false;
    }

    public void Solve()
    {
        SolveQueen(_board, 0);
    }
    
    public void DisplayBoardResult()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Rows; col++)
            {
                Console.Write(_board[row, col] == 1 ? ".Q." : "...");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
