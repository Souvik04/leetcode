public class Solution {
    public int TotalStrength(int[] strength) {
        const long MOD = 1000000007;
        int n = strength.Length;

        // Step 1: Calculate prefix sums of strength array
        long[] prefixSum = new long[n + 1];
        for (int i = 0; i < n; i++) {
            prefixSum[i + 1] = (prefixSum[i] + strength[i]) % MOD;
        }

        // Step 2: Calculate prefix sums of the prefixSum array
        long[] doublePrefixSum = new long[n + 2];  // Extra size for easier indexing
        for (int i = 0; i <= n; i++) {
            doublePrefixSum[i + 1] = (doublePrefixSum[i] + prefixSum[i]) % MOD;
        }

        // Step 3: Calculate the next and previous smaller elements using a monotonic stack
        int[] prevSmaller = new int[n];
        int[] nextSmaller = new int[n];
        Stack<int> stack = new Stack<int>();

        // Monotonic stack for previous smaller element
        for (int i = 0; i < n; i++) {
            while (stack.Count > 0 && strength[stack.Peek()] >= strength[i]) {
                stack.Pop();
            }
            prevSmaller[i] = stack.Count > 0 ? stack.Peek() : -1;
            stack.Push(i);
        }

        // Clear the stack and use it for next smaller elements
        stack.Clear();
        for (int i = n - 1; i >= 0; i--) {
            while (stack.Count > 0 && strength[stack.Peek()] > strength[i]) {
                stack.Pop();
            }
            nextSmaller[i] = stack.Count > 0 ? stack.Peek() : n;
            stack.Push(i);
        }

        // Step 4: Calculate the total strength
        long totalStrength = 0;

        for (int i = 0; i < n; i++) {
            // Number of subarrays where `strength[i]` is the minimum element
            long leftCount = i - prevSmaller[i];  // How many subarrays on the left
            long rightCount = nextSmaller[i] - i;  // How many subarrays on the right

            // Calculate the contribution to the total strength
            long leftContribution = (doublePrefixSum[nextSmaller[i] + 1] - doublePrefixSum[i + 1] + MOD) % MOD * leftCount % MOD;
            long rightContribution = (doublePrefixSum[i + 1] - doublePrefixSum[prevSmaller[i] + 1] + MOD) % MOD * rightCount % MOD;

            // Accumulate the total strength, considering the contribution from the current element `strength[i]`
            totalStrength += ((leftContribution + MOD * 2 - rightContribution) % MOD) * strength[i] % MOD;
            totalStrength %= MOD;
        }

        return (int) totalStrength;
    }
}
