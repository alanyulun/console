public class LC_15{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Sort sort=new Sort();
        int[] sortedArray = sort.quickSort(nums, 0, nums.Length - 1);

        List<IList<int>> rsl = new List<IList<int>>();
        int i = 0;
        while (i < sortedArray.Length && sortedArray[i] <= 0)
        {
            //若i值與前一次相同則結果將一樣，可忽略
            if (i > 0 && sortedArray[i] == sortedArray[i - 1])
            {
                i++;
                continue;
            }

            int i2 = i + 1;
            int i3 = sortedArray.Length - 1;
            while (i2 < i3)
            {
                //若i2值與前一次相同則結果將一樣，可忽略
                if (sortedArray[i2] == sortedArray[i2 - 1] && i2 > i + 1)
                {
                    i2++;
                    continue;
                }

                int sum = sortedArray[i] + sortedArray[i2] + sortedArray[i3];
                if (sum == 0)
                {
                    rsl.Add(new List<int>() { sortedArray[i], sortedArray[i2], sortedArray[i3] });
                    i2++;
                    i3--;
                }
                else if (sum < 0)
                    i2++;
                else
                    i3--;
            }
            i++;
        }

        return rsl;
    }
}