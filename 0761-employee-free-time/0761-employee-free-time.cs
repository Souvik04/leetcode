/*
// Definition for an Interval.
public class Interval {
    public int start;
    public int end;

    public Interval(){}
    public Interval(int _start, int _end) {
        start = _start;
        end = _end;
    }
}
*/

public class Solution {
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule) {
        IList<Interval> freeTimes = new List<Interval>();

        // flatten and sort
        IList<Interval> intervals = schedule.SelectMany(s => s).OrderBy(s => s.start).ToList();
        
        // merge intervals
        // [1,2], [1,3], [4,10], [5,6]
        int lastEnd = intervals[0].end;
        for(int i = 1; i < intervals.Count; i++){
            if(intervals[i].start > lastEnd){
                freeTimes.Add(new Interval(lastEnd, intervals[i].start));
            }

            lastEnd = Math.Max(lastEnd, intervals[i].end);
        }

        return freeTimes;
    }
}

/*

1. Define a class `Interval` that represents an interval with a `start` and an `end` time. This class is used to store time intervals.

2. Create a class named `Solution` to implement the solution for finding employee free time.

3. Define a method `EmployeeFreeTime` that takes a list of lists of intervals `schedule` as input and returns a list of intervals representing free time.

4. Initialize an empty list of intervals `freeTimes` to store the calculated free time intervals.

5. Flatten and sort the input schedule by concatenating all sublists and sorting the intervals based on their start times. The result is stored in the `intervals` list.

6. Initialize a variable `lastEnd` with the end time of the first interval in the sorted `intervals` list.

7. Iterate through the sorted `intervals` list, starting from the second interval (index 1).

8. For each interval, check if its start time is greater than the `lastEnd`. If it is, there is a gap between the previous interval and the current one, indicating free time. Add a new interval representing the free time (from `lastEnd` to the start of the current interval) to the `freeTimes` list.

9. Update the `lastEnd` to be the maximum of its current value and the end time of the current interval. This ensures that the `lastEnd` always represents the end time of the most recent interval.

10. Continue this process for all intervals in the sorted list, detecting and adding free time intervals between them.

11. After processing all intervals, the `freeTimes` list will contain intervals representing free time between employee schedules.

12. Return the `freeTimes` list as the result of the `EmployeeFreeTime` function.

*/