public class Solution {
    public int MinDifference(int[] nums) {
        int n = nums.Length;
        int k = 4;

        if(n <= k){
            return 0;
        }

        Array.Sort(nums);

        int minDiff = int.MaxValue;

        // 1 2 3 4 5 7 8 10
        for(int i = 0; i < k; i++){
            int tempDiff = nums[n - (k - i)] - nums[i];
            minDiff = Math.Min(minDiff, tempDiff);
        }

        return minDiff;
    }
}

/*

1. sort the input array nums
2. initialize k with 3 (+1)= 4 (or any other value as given)
3. initialize minDiff to maxint
4. loop through i 0 to k (i < k)
5. set tempDiff = nums[n - (k - i)] - nums[i]
6. set minDiff = min(minDiff, tempDiff)
7. return minDiff
*/