public class Solution {
    public int CountKSubsequencesWithMaxBeauty(string s, int k) {
        int n = s.Length;
        int[] charCount = new int[26];

        foreach (char c in s){
            charCount[c - 'a']++;
        }

        Array.Sort(charCount);

        if (k > 26){
            return 0;
        }

        long result = 1;
        long combinations = 1;
        long modulo = (long)1e9 + 7;
        long maxCount = charCount[26 - k];
        long pendingCounts = 0;

        foreach (int count in charCount) {
            if (count > maxCount) {
                k--;
                result = (result * count) % modulo;
            }
            if (count == maxCount) {
                pendingCounts++;
            }
        }

        for (int i = 0; i < k; ++i) {
            combinations = (combinations * (pendingCounts - i)) / (i + 1);
            result = (result * maxCount) % modulo;
        }

        return (int)((result * combinations) % modulo);
    }
}

/*


1. Initialize an array `charCount` to keep track of the frequency of each character in the input string `s`. Initialize other variables for result, combinations, modulo, maxCount, and pendingCounts.

2. Loop through each character in the string `s` and update the corresponding character count in the `charCount` array.

3. Sort the `charCount` array in ascending order. This will allow us to find the maximum and minimum character frequencies easily.

4. Check if `k` is greater than 26 or if the `charCount` for the 26 - `k`-th element is zero. If true, return 0 because it's impossible to form K-subsequences.

5. Initialize `result` to 1, `combinations` to 1, and other variables to calculate the maximum beauty and combinations.

6. Iterate through the sorted `charCount` array. For each character count:
   - If it's greater than `maxCount`, decrement `k` and update the `result` by multiplying it with the character count.
   - If it's equal to `maxCount`, increment `pendingCounts`.

7. Calculate combinations by iterating from 0 to `k`. For each iteration:
   - Update `combinations` by multiplying it with `(pendingCounts - i)` and dividing it by `(i + 1)`.

8. Finally, calculate the result by multiplying `result` with `maxCount`. Return the result modulo the predefined constant `modulo`.


*/