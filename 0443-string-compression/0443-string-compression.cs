public class Solution {
    public int Compress(char[] chars) {
        int mIndex = 0;
        int i = 0;

        while(i < chars.Length){
            int groupLength = 1;

            while(i + groupLength < chars.Length && chars[i + groupLength] == chars[i]){
                groupLength++;
            }

            chars[mIndex++] = chars[i];
            string strGroupLength = Convert.ToString(groupLength);

            if(groupLength > 1){
                for(int c = 0; c < strGroupLength.Length; c++){
                    chars[mIndex++] = strGroupLength[c];
                }
            }

            i += groupLength;
        }

        return mIndex;
    }
}

/*

1. initialize mIndex = 0, i = 0
2. iterate over chars while i < char.length
3. start with groupLength = 1
4. while i + groupLength < chars.length && chars[i + groupLength] == chars[i] increment groupLength by 1
5. set chars[mIndex++] = chars[i]
6. if groupLength > 1, for the groupLength, convert to strGroupLength and set chars[mIndex++] = strGroupLength[c]
7. increment i += groupLength after inner while loop
8. return mIndex as output

----

Time comeplexity: O(n)
Space complexity: O(1)

*/