public class Solution {
    public int MinDifference(int[] nums) {
        int minDiff = int.MaxValue;
        int n = nums.Length;
        Array.Sort(nums);
        int k = 4;

        if(n <= k){
            return 0;
        }

        for(int i = 0; i < k; i++){
            int tempDiff = nums[n - (k - i)] - nums[i];
            minDiff = Math.Min(minDiff, tempDiff);
        }

        return minDiff;
    }
}

/*

Intuition:

After sorting the array, we can remove top 3 (or k)

1. remove 3 from end
2. remove 3 from start
3. remove 1 from start and 2 from end
4. remove 2 from start and 1 from end

anything in between can be ignored and if nums.length <= 4 (k + 1) can be 0

so we run a loop from 0 to k + 1 and check for mindiff between start and end

Time complexity: O(nlogn)
Space complexity: O(logn)

*/