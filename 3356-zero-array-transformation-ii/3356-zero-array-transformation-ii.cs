public class Solution {
    public int MinZeroArray(int[] nums, int[][] queries) {
        int n = nums.Length;
        int k = 0;
        int sum = 0;
        int[] diffArr = new int[n + 1];

        for(int i = 0; i < n; i++){
            while(sum + diffArr[i] < nums[i]){
                if(k == queries.Length){
                    return -1;
                }

                int l = queries[k][0];
                int r = queries[k][1];
                int val = queries[k][2];
                k++;

                if(r < i){
                    continue;
                }

                diffArr[Math.Max(l, i)] += val;
                diffArr[r + 1] -= val;
            }

            sum += diffArr[i];
        }

        return k;
    }
}

/*

Time complexity: O(n + m)
Space complexity: O(n)

*/