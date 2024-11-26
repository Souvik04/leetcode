public class Solution {
    public int FindPairs(int[] nums, int k) {
        int count = 0;

        if(k < 0){
            return count;
        }

        Array.Sort(nums);
        int left = 0;
        int right = 1;

        while(right < nums.Length){
            // move right if left and right same or diff is smaller than k
            if(left == right || nums[right] - nums[left] < k){
                right++;
            }
            // move left if diff is larger than k
            else if(nums[right] - nums[left] > k){
                left++;
            }
            // found the pair
            else{
                count++;
                left++;
                right++;

                // skip duplicates on left and right
                while(left < nums.Length && nums[left] == nums[left - 1]){
                    left++;
                }

                // skip duplicates
                while(right < nums.Length && nums[right] == nums[right - 1]){
                    right++;
                }                
            }
        }

        return count;
    }
}