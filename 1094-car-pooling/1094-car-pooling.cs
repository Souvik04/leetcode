public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        Array.Sort(trips, (a, b) => a[1].CompareTo(b[1]));
        PriorityQueue<(int endTime, int psgCount), int> minHeap = new();
        int psgCount = 0;

        foreach(var trip in trips){
            int curPsgCount = trip[0];
            int curStartTime = trip[1];
            int curEndTime = trip[2];

            while(minHeap.Count > 0 && minHeap.Peek().endTime <= curStartTime){
                psgCount -= curPsgCount;
                minHeap.Dequeue();
            }

            psgCount += curPsgCount;

            if(psgCount > capacity){
                return false;
            }

            minHeap.Enqueue((curEndTime, curPsgCount), curEndTime);
        }

        return true;
    }
}

