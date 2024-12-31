public class Solution {
    public int MaxScoreSightseeingPair(int[] values) {
        int maxScore = 0;
        int bestValue = values[0];

        for(int i = 1; i < values.Length; i++){
            maxScore = Math.Max(maxScore, bestValue + values[i] - i);
            bestValue = Math.Max(bestValue, values[i] + i);
        }

        return maxScore;
    }
}

/*

Greedy approach:

1. initialize maxScore to 0 and bestValue to values[0]
2. iterate over values from 1 to n - 1
3. set maxScore = max(maxScore, values[i] - i)
4. update bestValue = max(bestValue, bestValue + values[i] + i)
5. return maxScore

Time complexity: O(n)
Space complexity: O(1)

*/