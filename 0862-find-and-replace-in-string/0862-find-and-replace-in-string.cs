public class Solution {
    public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets) {
        int n = s.Length;
        int[] match = new int[n];

        for (int i = 0; i < indices.Length; i++) {
            if (IsMatch(s, indices[i], sources[i])) {
                for (int j = indices[i]; j < indices[i] + sources[i].Length; j++) {
                    if (match[j] == 0 || sources[match[j] - 1].Length < sources[i].Length) {
                        match[j] = i + 1;
                    }
                }
            }
        }

        var result = new StringBuilder();
        int index = 0;

        while (index < n) {
            if (match[index] > 0) {
                int replacementIndex = match[index] - 1;
                result.Append(targets[replacementIndex]);
                index += sources[replacementIndex].Length;
            } else {
                result.Append(s[index]);
                index++;
            }
        }

        return result.ToString();
    }

    private bool IsMatch(string s, int index, string source) {
        return index + source.Length <= s.Length && s.Substring(index, source.Length) == source;
    }
}

/*

1. Create a class named `Solution` to implement the solution for finding and replacing substrings in a given string.

2. Define a method named `FindReplaceString` that takes the following arguments: `s` (the input string), `indices` (an array of indices where replacements should be applied), `sources` (an array of source substrings to match), and `targets` (an array of target substrings to replace the matching sources).

3. Calculate the length of the input string `s` and store it in the variable `n`.

4. Initialize an integer array `match` of length `n`. This array will be used to keep track of which source substring matches are made with.

5. Iterate through the `indices` array, which represents the starting indices for the find and replace operations.

6. For each `i` in the range from 0 to the length of `indices`, check if the source substring represented by `sources[i]` is found at the corresponding position in the input string `s`. This is done by calling the `IsMatch` method, which checks if the substring starting from `indices[i]` in `s` matches the source string `sources[i]`.

7. If a match is found, update the `match` array for each character position within the source substring. If the current character position `j` has not been assigned a matching source substring or if the source substring at the current position is shorter than the new match, set `match[j]` to `i + 1`. Here, we use `i + 1` to represent the index of the `sources` array.

8. After iterating through all find and replace operations, the `match` array will be populated with information about which source substrings match with parts of the input string.

9. Create a `StringBuilder` named `result` to build the final replaced string.

10. Initialize an integer `index` to keep track of the current character position in the input string.

11. Use a while loop that continues as long as `index` is less than the length of the input string `n`.

12. Within the loop, check if `match[index]` is greater than 0, which indicates that a match has been found and a replacement should be made.

13. If a match is found, get the index of the source substring in the `sources` array by subtracting 1 from `match[index]`. This is used to access the corresponding target substring from the `targets` array.

14. Append the target substring to the `result` using `result.Append(targets[replacementIndex])`.

15. Update the `index` by adding the length of the source substring, effectively skipping over the source substring that has been replaced.

16. If no match is found at the current `index`, simply append the character from the input string `s` to the `result` and increment the `index`.

17. After processing the entire input string, the `result` will contain the final string with replacements.

18. Convert the `result` to a string using the `ToString()` method and return it as the result of the `FindReplaceString` function.

19. Define a private method named `IsMatch` that checks if a substring of `s` starting at a given index matches a specified source string. It returns `true` if there is a match and `false` otherwise.

*/