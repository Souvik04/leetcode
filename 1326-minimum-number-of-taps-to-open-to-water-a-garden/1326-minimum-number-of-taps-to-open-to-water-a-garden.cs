public class Solution {
    public int MinTaps(int n, int[] ranges) {
        int minTaps = 0;
        List<int[]> intervals=  new List<int[]>();

        // create intervals
        for(int r = 0; r < ranges.Length; r++){
            int left = Math.Max(0, r - ranges[r]);
            int right = Math.Min(n, r + ranges[r]);
            intervals.Add(new int[]{left, right});
        }

        // sort the intervals
        intervals.Sort((a, b) => a[0].CompareTo(b[0]));

        // apply greedy approach to select intervals and calculate update min taps
        int currentEnd = 0;
        int farthest = 0;
        int i = 0;

        while(currentEnd < n){
            // extend coverage to farthest right within ranges
            while(i < intervals.Count && intervals[i][0] <= currentEnd){
                farthest = Math.Max(farthest, intervals[i][1]);
                i++;
            }

            // farthest couldn't extend, interval broken and couldn't reach end
            if(farthest == currentEnd){
                return -1;
            }

            minTaps++;
            currentEnd = farthest;
        }

        return minTaps;
    }
}