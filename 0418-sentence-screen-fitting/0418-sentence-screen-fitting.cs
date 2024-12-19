public class Solution {
    public int WordsTyping(string[] sentence, int rows, int cols) {
        int count = 0;
        int wordIndex = 0;        
        
        for(int i = 0; i < rows; i++){
            int remCols = cols;

            while(wordIndex < sentence.Length && remCols >= sentence[wordIndex].Length){
                remCols -= sentence[wordIndex].Length + 1;
                wordIndex++;

                if(wordIndex >= sentence.Length){
                    count++;
                    wordIndex = 0;
                }                
            }
        }

        return count;
    }
}

/*

Time complexity: O(m * n)
Space complexity: O(1)

*/