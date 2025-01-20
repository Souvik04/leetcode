public class Solution {
    public int MaximumBeauty(int[] nums, int k) {
        int maxBeauty = 0;
        Array.Sort(nums);

        for(int i = 0; i < nums.Length; i++){
            int target = nums[i] + 2 * k;
            int upperBound = GetUpperBound(nums, target);
            //int upperBound = Array.BinarySearch(nums, target);
            maxBeauty = Math.Max(maxBeauty, upperBound - i + 1);
        }

        return maxBeauty;
    }

    private int GetUpperBound(int[] nums, int value){
        int left = 0;
        int right = nums.Length - 1;
        int result = 0;

        while(left <= right){
            int mid = left + (right - left) / 2;

            if(value >= nums[mid]){
                result = mid;
                left = mid + 1;
            }
            else{
                right = mid - 1;
            }
        }

        return result;
    }
}
