public class LC_162{
    public int FindPeakElement(int[] nums)
    {
        if (nums.Length == 1)
            return 0;

        int n = nums.Length;
        int h = n - 1;
        int l = 0;

        while (h > l)
        {
            int m = (h + l) / 2;
            if (nums[m] < nums[m + 1])
                l = m + 1;
            else
                h = m;
        }

        return l;
    }
}