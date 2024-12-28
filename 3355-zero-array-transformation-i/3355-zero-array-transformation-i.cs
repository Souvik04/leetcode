public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        int n = nums.Length;
        int[] diffArr = new int[n + 1];

        // Step 1: Apply the difference array technique for each query
        foreach (int[] q in queries) {
            int l = q[0], r = q[1];
            diffArr[l] -= 1;
            diffArr[r + 1] += 1;
        }

        // Step 2: Apply prefix sum
        int current = 0;
        for (int i = 1; i < n; i++) {
            diffArr[i] += diffArr[i - 1];
        }

        // Step 3: Check if all values in nums <= 0
        for(int i = 0; i< n; i++){
            if(nums[i] + diffArr[i] > 0){
                return false;
            }
        }

        return true;
    }
}

/*

1. create difference array diffArr of size n + 1 initialized with 0 values
2. iterate over the queries and update diffArr[l] -= 1 and diffArr[r + 1] += 1
3. restore nums by prefix sum and check if nums[i] not 0 false
4. return true in the end

Time complexity: O(n)
Space complexity: O(n)

*/