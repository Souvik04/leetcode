using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int NumTilePossibilities(string tiles) {
        var freqMap = new Dictionary<char, int>();
        
        // Count frequency of each character
        foreach (var tile in tiles) {
            if (!freqMap.ContainsKey(tile)) {
                freqMap[tile] = 0;
            }
            freqMap[tile]++;
        }
        
        var result = 0;
        var visited = new HashSet<string>(); // This set stores unique sequences
        
        // Start DFS to generate all distinct sequences
        DFS(freqMap, visited, new StringBuilder(), ref result);
        
        return result;
    }

    // Backtracking function to generate sequences
    private void DFS(Dictionary<char, int> freqMap, HashSet<string> visited, StringBuilder current, ref int result) {
        if (current.Length > 0 && !visited.Contains(current.ToString())) {
            visited.Add(current.ToString());
            result++;
        }

        // Try each character
        foreach (var entry in freqMap.ToList()) {
            char c = entry.Key;
            int count = entry.Value;
            
            if (count > 0) {
                // Use this character and decrease its count
                freqMap[c]--;
                current.Append(c);
                
                // Recurse to add more characters
                DFS(freqMap, visited, current, ref result);
                
                // Backtrack, restore count of the character
                current.Length--; // Remove last character
                freqMap[c]++;
            }
        }
    }
}

/*

1. Count frequencies of all characters and store them in a dictionary.
2. Initialize a StringBuilder for building sequences and a HashSet to store unique strings.
3. Perform backtracking:
    If the current sequence is not in the set, add it to the set and increment the count.
    For each character in the frequency map:
        If its frequency > 0:
            Append the character to the current sequence.
            Decrement its frequency and recurse.
            Backtrack by removing the character and restoring its frequency.

Time complexity: O(n * 2 ^ n)
Space complexity: O(n)

*/