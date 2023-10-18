public class Solution {
    public int[] FindOriginalArray(int[] changed) {
        if(changed.Length % 2 != 0){
            return new int[0];
        }

        Dictionary<int, int> freq = new Dictionary<int, int>();
        List<int> output = new List<int>();

        Array.Sort(changed);

        foreach(int n in changed){
            if(!freq.ContainsKey(n)){
                freq.Add(n, 0);
            }

            freq[n]++;
        }

        foreach(int n in changed){
            if(freq.ContainsKey(n) && freq[n] > 0){
                output.Add(n);
                freq[n]--;

                int doubleVal = n * 2;

                if(freq.ContainsKey(doubleVal) && freq[doubleVal] > 0){
                    freq[doubleVal]--;
                }
                else{
                    return new int[0];
                }                
            }
        }

        return output.ToArray();
    }
}

/*

1. Create a function named `FindOriginalArray` that takes an integer array `changed` as input and returns an integer array.

2. Check if the length of the input array `changed` is odd (not divisible by 2). If it is odd, return an empty array (an array with length 0) because it's impossible to create pairs from an odd-sized array.

3. Initialize a dictionary named `freq` to keep track of the frequency of each integer in the input array, and initialize an empty list called `output` to store the original array.

4. Sort the `changed` array in ascending order. Sorting the array will make it easier to identify pairs of integers.

5. Iterate through each integer `n` in the sorted `changed` array.

6. For each integer `n`, check if it exists as a key in the `freq` dictionary. If it doesn't exist, add it as a key with a frequency count of 0.

7. Increment the frequency count of integer `n` in the `freq` dictionary.

8. Now, iterate through the sorted `changed` array again.

9. For each integer `n`, check if it exists in the `freq` dictionary and its frequency count is greater than 0. If it's not in the dictionary or its count is 0, it means this integer cannot be part of a pair, so return an empty array (an array with length 0).

10. If the integer `n` can be part of a pair, add it to the `output` list.

11. Decrement the frequency count of integer `n` in the `freq` dictionary to indicate that one instance of this integer has been used.

12. Calculate the double value of the integer `n` as `doubleVal = n * 2`.

13. Check if the double value `doubleVal` exists in the `freq` dictionary and its frequency count is greater than 0. If it does, decrement the frequency count of `doubleVal` in the `freq` dictionary to indicate that one instance of `doubleVal` has been used in a pair.

14. If the double value `doubleVal` doesn't exist in the `freq` dictionary or its frequency count is 0, return an empty array because you cannot find a valid pair for `n`.

15. Repeat steps 8 to 14 for all integers in the sorted `changed` array.

16. After processing all integers, the `output` list will contain the original array.

17. Convert the `output` list to an integer array using the `ToArray()` method and return it as the final result of the function.

*/