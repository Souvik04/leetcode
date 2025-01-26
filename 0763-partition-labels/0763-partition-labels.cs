public class Solution {
    public IList<int> PartitionLabels(string s) {
        IList<int> output = new List<int>();
        Dictionary<char, int> freqMap = new Dictionary<char, int>();
        int start = 0;
        int end = 0;

        // store last index of every elements
        for(int i = 0; i < s.Length; i++){
            freqMap[s[i]] = i;
        }

        // calculate paritions
        for(int i = 0; i < s.Length; i++){
            end = Math.Max(end, freqMap[s[i]]);

            // if a parition criteria achieved
            if(i == end){
                output.Add(end - start + 1);
                start = i + 1;
            }
        }
        return output;
    }
}

/*

1. initialize a map<int, int> to store each character and their last occurence index
2. initialize 2 variables size = 0 and end = 0, assuming end is a partition
3. iterate over s and set end = max(end, map[s[i]])
4. if i == end, add parition: end - start + 1 to output and increment start by 1
5. return output

----

 Time complexity: O(n)
 Space complexity: O(n)

*/