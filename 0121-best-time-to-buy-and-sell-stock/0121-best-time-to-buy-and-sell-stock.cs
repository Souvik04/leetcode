public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;
        int lastMin = int.MaxValue;

        foreach(int p in prices){
            lastMin = Math.Min(lastMin, p);
            maxProfit = Math.Max(maxProfit, p - lastMin);
        }

        return maxProfit;
    }
}

/*

1. initialize maxProfit = 0 and lastMin to int.MaxValue
2. iterate over the prices
3. set lastMin = min(lastMin, p)
4. set maxProfit = max(maxProfit, p - lastMin)
5. return maxProfit

Time complexity: O(n)
Space complexity: O(1)

*/