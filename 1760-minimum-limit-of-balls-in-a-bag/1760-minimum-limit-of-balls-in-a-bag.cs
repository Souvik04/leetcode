public class Solution {
    public int MinimumSize(int[] nums, int maxOperations) {
        int left = 1;
        int right = nums.Max();

        while(left < right){
            int mid = left + (right - left) / 2;
            int totalSplits = GetTotalSplit(nums, mid);

            if(totalSplits <= maxOperations){
                right = mid;
            }
            else{
                left = mid + 1;
            }
        }

        return left;
    }

    private int GetTotalSplit(int[] nums, int x){
        int totalSplits = 0;

        foreach(int n in nums){
            // [n / x] - 1
            totalSplits += (int)Math.Ceiling(n * 1.0 / x) - 1;
        }

        return totalSplits;
    }
}

/*

Time complexity: O(nlogk)
Space complexity: O(1)

*/