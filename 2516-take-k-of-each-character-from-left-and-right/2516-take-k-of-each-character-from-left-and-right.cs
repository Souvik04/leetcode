public class Solution {
    public int TakeCharacters(string s, int k) {
        int totalA = GetCount(s, 'a');
        int totalB = GetCount(s, 'b');
        int totalC = GetCount(s, 'c');        

        if(totalA < k || totalB < k || totalC < k){
            return -1;
        }

        int n = s.Length;
        int minNumber = 0;
        int countA = 0;
        int countB = 0;
        int countC = 0;
        int left = 0;
        int right = 0;

        while(right < n){
            if(s[right] == 'a'){
                countA++;
            }
            else if(s[right] == 'b'){
                countB++;
            }
            else if(s[right] == 'c'){
                countC++;
            }

            while(countA > totalA - k || countB > totalB - k || countC > totalC - k){
                if(s[left] == 'a'){
                    countA--;
                }
                else if(s[left] == 'b'){
                    countB--;
                }
                else if(s[left] == 'c'){
                    countC--;
                }

                left++;
            }

            minNumber = Math.Max(minNumber, right - left + 1);
            right++;
        }

        return n - minNumber;
    }

    private int GetCount(string s, char c){
        int count = 0;

        foreach(char ch in s){
            if(ch == c){
                count++;
            }
        }

        return count;
    }
}

/*

1. initialize totalA, totalB and totalC and get counts for a, b and c into these variables
2. if any of them is < k then return -1
3. initialize countA, countB and countC = 0 and minLength = 0
4. set left = 0 and right = 0
5. perform sliding window by expanding right
6. based on value of [right], increment countA or CcoutnB or countC accordingly
7. while (countA > totalA - k || countB > totalB - k || countC > totalC - k)
    - calculate minNumber = max(minNumber, right - left + 1)
    - shrink the counts of these from left: based on s[left] value and increment left by 1
8. increment right by 1 to expland the window right side
9. return n - minNumber

----

Time complexity: O(n)
Space complexity: O(1)

*/