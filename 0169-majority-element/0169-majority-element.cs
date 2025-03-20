public class Solution {
    public int MajorityElement(int[] nums)
    {
        int mid = 0 + (nums.Length - 0) / 2;
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                dict[nums[i]]++;
                if (dict[nums[i]] > mid)
                    return nums[i];
            }
            else
            {
                dict.Add(nums[i], 1);
                if (dict[nums[i]] > mid)
                    return nums[i];
            }
        }
        return 0;
    }
}