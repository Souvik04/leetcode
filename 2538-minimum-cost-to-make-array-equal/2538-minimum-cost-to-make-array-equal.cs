public class Solution {
    public long MinCost(int[] nums, int[] cost) {
        long minCost = 0;
        int n = nums.Length;

        // create and array to store nums and cost sorted by nums
        int[][] numsAndCost = new int[n][];
        for(int i = 0; i < n; i++){
            numsAndCost[i] = new int[2];
            numsAndCost[i][0] = nums[i];
            numsAndCost[i][1] = cost[i];
        }

        Array.Sort(numsAndCost, (a, b) => a[0].CompareTo(b[0]));

        // create prefix sum of costs
        long[] prefixCost = new long[n];
        prefixCost[0] = numsAndCost[0][1];
        for(int i = 1; i < n; i++){
            prefixCost[i] = numsAndCost[i][1] + prefixCost[i - 1];
        }

        // iterate over nums from 1 to n and make elements equal to nums[i]
        long tempCost = 0;
        for(int i = 1; i < n; i++){
            tempCost += (long)numsAndCost[i][1] * (numsAndCost[i][0] - numsAndCost[0][0]);
        }

        minCost = tempCost;

        // Then we try nums[1], nums[2] and so on. The cost difference is made by the change of
        // two parts: 1. prefix sum of costs. 2. suffix sum of costs. 
        // During the iteration, record the minimum cost we have met.        
        for(int i = 1; i < n; i++){
            int gap = numsAndCost[i][0] - numsAndCost[i - 1][0];
            tempCost += (long)prefixCost[i - 1] * gap;
            tempCost -= (long)(prefixCost[n - 1] - prefixCost[i - 1]) * gap;
            minCost = Math.Min(minCost, tempCost);
        }

        return minCost;
    }
}