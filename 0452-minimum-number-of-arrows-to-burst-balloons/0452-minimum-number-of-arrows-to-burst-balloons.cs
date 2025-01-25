public class Solution {
    public int FindMinArrowShots(int[][] points) {
        int minArrows = points.Length;
        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
        int[] prev = points[0];

        for(int i = 1; i < points.Length; i++){
            int[] cur = points[i];
            
            if(cur[0] <= prev[1]){
                minArrows--;
                prev = new int[]{cur[0], Math.Min(prev[1], cur[1])};
            }
            else{
                prev = cur;
            }
        }

        return minArrows;
    }
}