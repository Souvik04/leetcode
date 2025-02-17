public class Solution {
    public int[][] Merge(int[][] intervals) {
        List<int[]> output = new List<int[]>();
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        for(int i = 0; i < intervals.Length; i++){
            int lastIndex = output.Count - 1;

            if(lastIndex >= 0 && output[lastIndex][1] >= intervals[i][0]){
                output[lastIndex][1] = Math.Max(output[lastIndex][1], intervals[i][1]);
            }
            else{
                output.Add(intervals[i]);
            }
        }

        return output.ToArray();
    }
}