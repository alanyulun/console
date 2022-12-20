public class LC_523{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        //時間複雜度 O(^2)
        /* int sum=0;
        for(int i=0;i<nums.Length;i++){
            sum=nums[i];
            for(int i2=i+1;i2<nums.Length;i2++){
                sum+=nums[i2];
                if(sum==0||(sum>=k&&sum%k==0))
                    return true;
            }
        }
        return false; */

        //時間複雜度 O(n)
        Dictionary<int, int> map = new Dictionary<int, int>();
        map.Add(0, -1);
        int remainder = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            remainder = (remainder + nums[i]) % k;
            if (map.ContainsKey(remainder) && i - map[remainder] > 1)
                return true;
            else if (!map.ContainsKey(remainder))
                map.Add(remainder, i);
        }

        return false;
    }
}