//判斷合理數獨結果
public class CW_SudokuSolutionValidator{
    static bool ValidateSolution(int[][] board)
    {
        //含0者不符
        if (board.Where(m => m.Where(m2 => m2 == 0).Count() > 0).Count() > 0)
            return false;

        //行列重複同值者不符
        for (int i = 0; i < 9; i++)
        {
            int[] arr = board[i];
            if (arr.Distinct().Count() < 9)
                return false;

            arr = new int[9];
            for (int i2 = 0; i2 < 9; i2++)
                arr[i2] = board[i2][i];
            if (arr.Distinct().Count() < 9)
                return false;
        }

        //9宮格內重複同值者不符
        for (int i = 0; i < 9; i += 3)
        {
            for (int i2 = 0; i2 < 9; i2 += 3)
            {
                List<int> arr = new List<int>();
                for (int ii = i; ii < i + 3; ii++)
                    for (int ii2 = i2; ii2 < i2 + 3; ii2++)
                        arr.Add(board[ii][ii2]);
                if (arr.Distinct().Count() < 9)
                    return false;
            }
        }

        return true;
    }
}