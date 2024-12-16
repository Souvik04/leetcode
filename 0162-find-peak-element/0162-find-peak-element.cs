public class Solution {
    public int FindPeakElement(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;

        while(left <= right){
            int mid = left + (right - left) / 2;

            if(mid > 0 && nums[mid] < nums[mid - 1]){
                right = mid - 1;
            }
            else if(mid < nums.Length - 1 && nums[mid] < nums[mid + 1]){
                left = mid + 1;
            }
            else{
                return mid;
            }
        }

        return -1;
    }
}

/*

Time complexity: O(logn)
Space complexity: O(1)

*/