using System.Drawing;

// See https://aka.ms/new-console-template for more information

CreateTree ct=new CreateTree();
LC_114 lc114=new LC_114();

TreeNode t=ct.createTree(new int?[]{1,2,5,3,4,null,6});
lc114.Flatten(t);
Console.WriteLine();

Console.WriteLine("finish");
Console.Read();




//判斷合理數獨結果
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

//回傳第二大數之組合
//未完成
static long NextBiggerNumber(long n)
{
    for (int i = n.ToString().Length - 2; i >= 0; i--)
    {
        string nStr = n.ToString().Substring(i, n.ToString().Length - 1);

        List<string> rslList = new List<string>();
        //permute(ref rslList, "", nStr);
        while (true)
        {

            break;
        }

        if (rslList.Count > 0)
        {
            rslList.Sort();
            return Convert.ToInt32(n.ToString().Substring(0, i - 1) + rslList[rslList.Count - 1]);
        }
    }

    return -1;
}

static void permute(ref List<string> rslList, string result, string now)
{
    if (now == "")
        rslList.Add(result);
    else
    {
        for (int i = 0; i < now.Length; i++)
            permute(ref rslList, result + now[i], now.Substring(0, i) + now.Substring(i + 1));
    }
}

//回傳去除特定字元之字串
static string StripComments(string text, string[] commentSymbols)
{
    string[] textLineArr = text.Split('\n');
    for (int i = 0; i < textLineArr.Length; i++)
        foreach (var sym in commentSymbols)
            textLineArr[i] = textLineArr[i].Split(sym)[0].TrimEnd();

    string rul = "";
    foreach (var txt in textLineArr)
        rul += txt + "\n";

    return rul.Remove(rul.Length - 1, 1);
}

//找出與分母n互質之數量
//使用歐拉函數最快取得結果
static long ProperFractions(long n)
{
    double count = 0;

    if (n == 1)
        return 0;
    else
    {
        //List<int> Divisor = new List<int>();

        //for (int i = 2; i < n / 2; i++)
        //    if (n % i == 0)
        //        Divisor.Add(i);

        //if (Divisor.Count == 0)
        //    count = n - 1;
        //else
        //{
        //    for (int i = 2; i <= n - 2; i++)
        //    {
        //        if (!Divisor.Any(m => m == i))
        //            if (!Divisor.Any(m => m < i && i % m == 0))
        //                count++;
        //    }
        //}

        //for (int i = 2; i < n; i++)
        //    if (Euclid_algorithm(n, i) == 1)
        //        count++;

        count = n;
        double a = n;
        for (int i = 2; i <= Math.Sqrt(a); i++)
        {
            if (a % i == 0)
            {
                count *= (1 - (1 / (double)i));

                while (a % i == 0)
                    a /= i;
            }
        }

        if (a > 1)
            count *= (1 - (1 / (double)a));
    }

    return (long)count;
}

//輾轉相除法
static long Euclid_algorithm(long m, long n)
{
    if (m % n == 0)
        return n;
    else
        return Euclid_algorithm(n, m % n);
}

static string FirstNonRepeatingLetter(string s)
{
    string ret = s.GroupBy(z => char.ToLower(z)).Where(g => g.Count() == 1).FirstOrDefault().Key.ToString();
    return (ret == null) ? string.Empty : ret;

    //while (s.Length > 0)
    //{
    //    string c = s[0].ToString();

    //    if (s.Count(m => m.ToString() == c.ToUpper() || m.ToString() == c.ToLower()) > 1)
    //        s.Replace(c, "");
    //    else
    //        return c;
    //}
    //return "";
}

//計算德州撲克手牌
static (string type, string[] ranks) Hand(string[] holeCards, string[] communityCards)
{
    string[] cards = new string[7];
    holeCards.CopyTo(cards, 0);
    communityCards.CopyTo(cards, 5);

    Dictionary<string, int> numRank = new Dictionary<string, int>
            {
                { "2", 1},
                { "3", 2},
                { "4", 3},
                { "5", 4},
                { "6", 5},
                { "7", 6},
                { "8", 7},
                { "9", 8},
                { "10", 9},
                { "J", 10},
                { "Q", 11},
                { "K", 12},
                { "A", 13}
            };
    Dictionary<string, int> picRank = new Dictionary<string, int>
            {
                { "♣", 1},
                { "♦", 2},
                { "♥", 3},
                { "♠", 4}
            };

    cards = cards.OrderBy(m => numRank[m]).ToArray();

    //檢查同花順

    return ("nothing", new[] { "A", "Q", "9", "6", "3" });
}

static int LengthOfLongestSubstring(string s)
{
    int maxRsl = 0;
    string rsl = "";
    foreach (var str in s)
    {
        if (rsl.IndexOf(str) == -1)
            rsl += str;
        else
        {
            if (rsl.Length > maxRsl)
                maxRsl = rsl.Length;
            rsl = rsl.Remove(0, rsl.IndexOf(str) + 1);
            rsl += str.ToString();
        }
    }

    if (rsl.Length > maxRsl)
        return rsl.Length;
    else
        return maxRsl;

}

static string MinWindow(string s, string t)
{
    string rul = "";
    Dictionary<char, int> td = new Dictionary<char, int>();
    foreach (var str in t)
    {
        if (td.ContainsKey(str))
            td[str]++;
        else
            td.Add(str, 1);
    }

    while (true)
    {
        int minId = s.Length;
        int maxId = 0;

        foreach (var str in td.Keys)
        {
            for (int i = 1; i <= td[str]; i++)
            {

            }




            int id = s.IndexOf(str);

            if (minId != s.Length && id == minId)
                id = s.IndexOf(str, minId + 1);
            if (maxId != 0 && id == maxId)
                id = s.IndexOf(str, maxId + 1);

            if (id == -1)
                return rul;
            if (minId > id)
                minId = id;
            if (maxId < id)
                maxId = id;
        }

        if (rul == "" || rul.Length > maxId - minId + 1)
            rul = s.Substring(minId, maxId - minId + 1);

        s = s.Substring(minId + 1);

        Point p = new Point(1, 1);

    }
}

//計算矩陣中有幾座島(相連的1)
static int CountOfIsland(int[][] grid)
{
    int islandCount = 0;
    Queue<Point> q = new Queue<Point>();

    for (int x = 0; x < grid.Length; x++)
    {
        for (int y = 0; y < grid[x].Length; y++)
        {
            if (grid[x][y] == 1)
            {
                islandCount++;
                q.Enqueue(new Point(x, y));
                do
                {
                    Point p = q.Dequeue();
                    grid[p.X][p.Y] = 0;
                    if (p.X > 0 && grid[p.X - 1][p.Y] == 1)
                        if (!q.Contains(new Point(p.X - 1, p.Y)))
                            q.Enqueue(new Point(p.X - 1, p.Y));
                    if (p.X < grid.Length - 1 && grid[p.X + 1][p.Y] == 1)
                        if (!q.Contains(new Point(p.X + 1, p.Y)))
                            q.Enqueue(new Point(p.X + 1, p.Y));
                    if (p.Y > 0 && grid[p.X][p.Y - 1] == 1)
                        if (!q.Contains(new Point(p.X, p.Y - 1)))
                            q.Enqueue(new Point(p.X, p.Y - 1));
                    if (p.Y < grid[x].Length - 1 && grid[p.X][p.Y + 1] == 1)
                        if (!q.Contains(new Point(p.X, p.Y + 1)))
                            q.Enqueue(new Point(p.X, p.Y + 1));
                } while (q.Count() > 0);
            }
        }
    }
    return islandCount;
}

//計算矩陣中島的最大面積
static int MaxAreaOfIsland(int[][] grid)
{
    int maxIslandArea = 0;
    Queue<Point> q = new Queue<Point>();

    for (int x = 0; x < grid.Length; x++)
    {
        for (int y = 0; y < grid[x].Length; y++)
        {
            if (grid[x][y] == 1)
            {
                int islandArea = 0;
                q.Enqueue(new Point(x, y));
                do
                {
                    Point p = q.Dequeue();
                    islandArea++;
                    grid[p.X][p.Y] = 0;
                    if (p.X > 0 && grid[p.X - 1][p.Y] == 1)
                        if (!q.Contains(new Point(p.X - 1, p.Y)))
                            q.Enqueue(new Point(p.X - 1, p.Y));
                    if (p.X < grid.Length - 1 && grid[p.X + 1][p.Y] == 1)
                        if (!q.Contains(new Point(p.X + 1, p.Y)))
                            q.Enqueue(new Point(p.X + 1, p.Y));
                    if (p.Y > 0 && grid[p.X][p.Y - 1] == 1)
                        if (!q.Contains(new Point(p.X, p.Y - 1)))
                            q.Enqueue(new Point(p.X, p.Y - 1));
                    if (p.Y < grid[x].Length - 1 && grid[p.X][p.Y + 1] == 1)
                        if (!q.Contains(new Point(p.X, p.Y + 1)))
                            q.Enqueue(new Point(p.X, p.Y + 1));
                } while (q.Count() > 0);

                if (maxIslandArea < islandArea)
                    maxIslandArea = islandArea;
            }
        }
    }
    return maxIslandArea;
}

//計算最長回文
static int LongestPalindromeSubseq(string s)
{
    int li = 0;
    int ri = 0;
    int rsl = 0;
    while (li <= s.Length / 2)
    {
        ri = s.Length - 1;
        while (ri >= li)
        {
            if (s[ri] == s[li])
                break;
            ri--;
        }

        string s2 = s.Substring(li, ri - li + 1);
        if (s2.Length > 2)
        {
            //while()
        }

        if (rsl < s2.Length)
            rsl = s2.Length;

        li++;
    }

    return rsl;
}