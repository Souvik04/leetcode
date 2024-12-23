public class Solution {
    public int CalculateTime(string keyboard, string word) {       
        int totalTime = 0;
        
        Dictionary<int, int> map = new Dictionary<int, int>();
        
        for(int i = 0; i < keyboard.Length; i++){
            map[keyboard[i]] = i;
        }
        
        int prevPos = 0;
        
        for(int i = 0; i < word.Length; i++){
            totalTime += Math.Abs(map[word[i]] - prevPos);
            prevPos = map[word[i]];
        }
        
        return totalTime;
    }
}

/*

1. iterate over the input keyboard
2. store the indices of respective character positions in a map
3. iterate over the input word
4. start for index 0 initially and set the time to |0 - map[word[0]]|
5. store the position of prev char a map[word[0]]
5. iterate over the next characters in word from 1 till word.length - 1 and update time
as time += prev - map[word[i]]
6. return time as output

Time complexity: O(n + w)
Space complexity: O(n)

pqrstuvwxyzabcdefghijklmno

*/