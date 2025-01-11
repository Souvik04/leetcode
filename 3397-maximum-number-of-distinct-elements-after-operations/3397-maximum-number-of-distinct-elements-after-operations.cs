public class Solution {
    public int MaxDistinctElements(int[] nums, int k) {
        int count = 0;
        Array.Sort(nums);
        int prevNum = int.MinValue;

        foreach(int n in nums){
            if(prevNum < n + k){
                count++;
                prevNum = Math.Max(prevNum + 1, n - k);
            }
        }

        return count;
    }
}