C# Eight Queens 八后問題解題
==============

這個專案是 Youtube 頻道 ITsLife OverAll 的 [C# 八后問題](https://youtu.be/xPOoAibZono) 原始程式碼。

.Net 6 (C# 10) 以上適用。


## 八馬問題怎麼解？

其實很簡單。我們還是一排一排往下解決。因此，只要改變 `TryPosition()` 定義，改成測試馬的攻擊點就可以了。

首先，我們需要先建立馬的攻擊點的陣列。我們先用相對位置表達出來，把這個陣列義定在程式的前面。
```cs
// Point.X : Row, Point.Y : Column
Point[] AttackPoints = new Point[]
{
    new(-2,1), new(-1, 2), new(1, 2), new(2, 1), new(2, -1), new(1, -2), new(-1, -2), new(-2, -1),
};
```

再來，變更 `TryPosition()` 如下：
```cs
bool TryPosition(bool[,] board, int row, int column)
{
    var attackPoints = AttackPoints.Select(x => new Point(row + x.X, column+x.Y))
        .Where(x => x.X >=0 && x.X < boardSize && x.Y >=0 && x.Y < column)
        .Any(x => board[x.X, x.Y] == true);
    if (attackPoints) return false;
    return true;
}
```

這樣就完成了。

跑出來的結果，可能會讓你嚇一跳。仔細一看，它的結果並沒有錯。

我們可以把第 0 排的 "馬"，事先排到第 1 格，因此，原本的程式變成了：

```cs
using System.Drawing;

const int boardSize = 8; 
bool[,] board = new bool[boardSize, boardSize];

// Point.X : Row, Point.Y : Column
Point[] AttackPoints = new Point[]
{
    new(-2,1), new(-1, 2), new(1, 2), new(2, 1), new(2, -1), new(1, -2), new(-1, -2), new(-2, -1),
};

board[1, 0] = true;  // 第 0 排的第 1 格，先放一隻馬。
var resolved = SolveColumn(board, 1);   // 然後由第 1 排開始解決 
if (resolved)
{
    Console.WriteLine("Resolved.");
    DisplayBoard(board);
}
else
{
     Console.WriteLine("Not resolved.");
}
```

這樣子的話，可以再看到它解決八馬問題的邏輯。

