public class Solution {
    public bool CheckValidCuts(int n, int[][] rectangles) {
        if(rectangles.Length < 2){
            return false;
        }

        // sort by x
        Array.Sort(rectangles, (a, b) => a[0].CompareTo(b[0]));
        int maxEndX = rectangles[0][2];
        int cuts = 0;

        for(int i = 1; i < rectangles.Length; i++){
            if(rectangles[i][0] >= maxEndX){
                cuts++;
            }

            if(cuts == 2){
                return true;
            }

            maxEndX = Math.Max(maxEndX, rectangles[i][2]);
        }

        // sort by y
        Array.Sort(rectangles, (a, b) => a[1].CompareTo(b[1]));
        int maxEndY = rectangles[0][3];
        cuts = 0;

        for(int i = 1; i < rectangles.Length; i++){
            if(rectangles[i][1] >= maxEndY){
                cuts++;
            }

            if(cuts == 2){
                return true;
            }
            
            maxEndY = Math.Max(maxEndY, rectangles[i][3]);
        }      

        return false;  
    }
}