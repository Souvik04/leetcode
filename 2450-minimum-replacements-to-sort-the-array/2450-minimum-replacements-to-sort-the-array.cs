public class Solution {
    public long MinimumReplacement(int[] nums) {
        int n = nums.Length;
        long minRepl = 0;
        int last = nums[n - 1];

        for(int i = n - 2; i >= 0; i--){
            if(nums[i] > last){
                int times = nums[i] / last;

                if(nums[i] % last != 0){
                    times += 1;
                }

                last = nums[i] / times;
                minRepl += times - 1;
            }
            else{
                last = nums[i];
            }
        }

        return minRepl;
    }
}

/*

1. initialize ans = 0, n = nums.Length, last = nums[n - 1];
2. iterate the given nums array in reverse order starting from n - 2
3. check
    if nums[i] > last
        calculate number of times nums[i] can be divided. times = nums[i] / last
        increment times by 1 if there is a remainder. if nums[i] % last != 0, times++
        update last for next comarision. last = nums[i] / times
        update ans. ans += times - 1

    else
        move to next element on left. last = nums[i]
4. return ans

Time complxity: O(n)
Space complexity: O(1)

*/