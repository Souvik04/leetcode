public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int count = 0;
        int n = nums.Length;
        int[] prefixSum = new int[n + 1];

        for(int i = 1; i <= n; i++){
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
        }

        for(int i = 0; i < n; i++){
            for(int j = 1; j <= n; j++){
                if(prefixSum[j] - prefixSum[i] == k){
                    count++;
                }
            }
        }

        return count;
    }
}