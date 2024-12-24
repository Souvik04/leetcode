public class Solution {
    public double TrimMean(int[] arr) {
        Array.Sort(arr);
        int n = arr.Length;
        int rem = (int)(0.05 * n); // Correctly calculate 5% of n
        
        int sum = arr.Skip(rem).Take(n - (2 * rem)).Sum(); // Sum after removing 5% from both ends
        return (double)sum / (n - (2 * rem)); // Ensure floating-point division
    }
}
