public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for(int i = 1; i < amount + 1; i++){
            foreach(int c in coins){
                if(i - c >= 0){
                    dp[i] = Math.Min(dp[i], 1 + dp[i - c]);
                }
            }
        }

        return dp[amount] == amount + 1 ? -1 : dp[amount];
    }
}