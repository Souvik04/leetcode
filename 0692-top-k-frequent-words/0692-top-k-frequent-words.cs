public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        Dictionary<string, int> freq = new Dictionary<string, int>();
        foreach(string w in words){
            if(freq.ContainsKey(w)){
                freq[w]++;
            }
            else{
                freq[w] = 1;
            }
        }

        SortedSet<string> minHeap = new SortedSet<string>(Comparer<string>.Create((a, b) => {
            if(freq[a] == freq[b])
                return b.CompareTo(a);
            return freq[a] != freq[b] ? freq[a] - freq[b] : a.CompareTo(b);
        }));

        foreach(string w in freq.Keys){
            minHeap.Add(w);

            if(minHeap.Count > k){
                minHeap.Remove(minHeap.Min);
            }
        }

        var output = new List<string>(minHeap);
        output.Reverse();

        return output;
    }
}

/*

1. Create a class named `Solution` to implement the solution for finding the top K frequent words.

2. Define a method named `TopKFrequent` that takes an array of strings `words` and an integer `k` as input and returns a list of the top K frequent words.

3. Initialize a dictionary named `freq` to store the frequency of each word. Iterate through the array of words and populate the dictionary. If a word is encountered, check if it already exists as a key in the dictionary. If it does, increment the associated frequency. If not, add a new entry with a frequency of 1.

4. Create a `SortedSet<string>` named `minHeap` to maintain the K most frequent words in ascending order, considering both frequency and lexicographical order. Use a custom comparer to achieve this sorting behavior.

5. Define the custom comparer for the `minHeap` using `Comparer<string>.Create(...)`. The comparer compares words based on their frequency and lexicographical order. If two words have the same frequency, they are compared lexicographically. Otherwise, words with higher frequencies are placed ahead in the sorted set.

6. Iterate through the keys of the `freq` dictionary. For each word, add it to the `minHeap`.

7. After adding a word to the `minHeap`, check if the size of the `minHeap` exceeds the limit `k`. If it does, remove the minimum element (lexicographically smallest word with the lowest frequency) from the `minHeap`. This ensures that the `minHeap` always contains the top K frequent words.

8. Convert the `minHeap` to a list named `output` to obtain the top K frequent words.

9. To meet the requirement of returning words in descending order of frequency, reverse the order of elements in the `output` list.

10. Return the `output` list, which now contains the top K frequent words, ordered by frequency in descending order and lexicographically when frequencies are equal.

*/