public class Solution {
    public string ShiftingLetters(string s, int[][] shifts) {
        int n = s.Length;
        char[] result = new char[n];        
        int[] diffArr = new int[n + 1];

        // Apply the shifts to the difference array
        foreach(int[] shift in shifts){
            int left = shift[0];
            int right = shift[1];
            int dir = shift[2] == 1 ? 1 : -1;
            diffArr[left] += dir;

            if(right + 1 < n){
                diffArr[right + 1] -= dir;
            }
        }

        // Accumulate the shifts and apply them to the string
        int cumulativeSum = 0;

        for(int i = 0; i < n; i++){
            cumulativeSum = (cumulativeSum + diffArr[i]) % 26;

            if(cumulativeSum < 0){
                cumulativeSum += 26;
            }

            result[i] = (char)('a' + (s[i] - 'a' + cumulativeSum) % 26);
        }

        return new string(result);
    }
}

/*

1. initialize result[], diffArr[]
2. iterate over input shifts and update diffArr
3. iterate over 0 to n - 1 and apply cumulativeSum to result[i]
4. cumulativeSum = (cumulativeSum + diffArr[i]) % 26
5. result[i] = (char)'a' + (s[i] - 'a' + cumulativeSum) % 26
6. convert result[] to string and return

----

Time complexity: O(n)
Space complexity: O(n)

*/