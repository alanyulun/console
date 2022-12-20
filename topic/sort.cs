public class Sort{
    public int[] quickSort(int[] nums, int low, int high)
    {
        if (low < high)
        {
            int mid = partition(nums, low, high);
            quickSort(nums, low, mid - 1);
            quickSort(nums, mid + 1, high);
        }

        return nums;
    }

    private int partition(int[] a, int low, int high)
    {
        int l = low, r = high, pivot = a[l];

        while (l < r)
        {
            while (l < r && a[r] > pivot)
                r--;
            while (l < r && a[l] <= pivot)
                l++;
            if (l < r)
                a = swap(a, l, r);
        }

        if (a[l] > pivot)
            a = swap(a, l--, low);
        else
            a = swap(a, l, low);

        return l;
    }

    private int[] swap(int[] a, int i1, int i2)
    {
        int temp = a[i1];
        a[i1] = a[i2];
        a[i2] = temp;
        return a;
    }
}