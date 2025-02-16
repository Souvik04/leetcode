public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> output = new List<int[]>();
        int index = 0;

        while(index < intervals.Length && intervals[index][1] < newInterval[0]){
            output.Add(intervals[index]);
            index++;
        }

        while(index < intervals.Length && intervals[index][0] <= newInterval[1]){
            newInterval[0] = Math.Min(newInterval[0], intervals[index][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[index][1]);
            index++;
        }

        output.Add(newInterval);

        while(index < intervals.Length){
            output.Add(intervals[index++]);
        }

        return output.ToArray();
    }
}

/*

1. create a new output array
2. add the intervals that come before newInterval
    while index < n - 1 && intervals[index][1] < newInterval[0]
        index++;
3. merge intervals that overlap with the newInterval
    while index < n - 1 && intervals[index][0] <= newInterval[1]
        newInterval[0] = min(intervals[index][0], newInterval[0])
        newInterval[1] = max(intervals[index][1], newInterval[1])
        index++;
4. add the new interval
    output.Add(newInterval)
5. add remaining intervals to output
    while index < n - 1
        output.Add(intervals[index])
6. return output as array

----
Time complexity: O(n)
Space complexity: O(1)

*/