public class LC_96{
    public int NumTrees(int n)
    {
        int[] arr = new int[n];
        for (int i = 1; i <= n; i++)
            arr[i - 1] = i;

        return count(arr);
    }

     private int count(int[] arr)
    {
        if (arr.Length == 0)
            return 1;

        int rul = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int lc = count(arr.Where(m => m < arr[i]).ToArray());
            int rc = count(arr.Where(m => m > arr[i]).ToArray());
            rul += lc * rc;
        }

        return rul;
    }
}
