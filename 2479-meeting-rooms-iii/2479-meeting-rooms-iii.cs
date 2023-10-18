public class Solution {
    public int MostBooked(int n, int[][] meetings) {
        int[] occupancyCounts = new int[n];

        // min-heap: (startTime, endTime, roomIndex), sorted by endTime
        PriorityQueue<(long, long, long), long> occupiedRooms = new PriorityQueue<(long, long, long), long>();

        // min-heap: roomIndex, sorted by roomIndex
        PriorityQueue<long, long> freeRooms = new PriorityQueue<long, long>();

        // create free rooms
        for(int i = 0; i < n; i++){
            freeRooms.Enqueue(i, i);
        }

        // sort meetings by startTime
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        long currentTime = 0;

        for(int i = 0; i < meetings.Length; i++){
            // update currentTime to startTime of next meeting
            currentTime = Math.Max(currentTime, meetings[i][0]);

            // if no rooms free, move currentTime to earliest time when a meeting ends
            if(freeRooms.Count == 0){
                long freeTime = occupiedRooms.Peek().Item2;
                currentTime = Math.Max(currentTime, freeTime);
            }

            // free up rooms when meeting is over
            while(occupiedRooms.Count > 0 && occupiedRooms.Peek().Item2 <= currentTime){
                long freeRoom = occupiedRooms.Dequeue().Item3;
                freeRooms.Enqueue(freeRoom, freeRoom);
            }

            // get free room
            long nextFreeRoom = freeRooms.Dequeue();
            long meetingEnd = currentTime + meetings[i][1] - meetings[i][0];
            occupiedRooms.Enqueue((currentTime, meetingEnd, nextFreeRoom), meetingEnd);
            occupancyCounts[nextFreeRoom] += 1;
        }

        // get lowest room index with max occupancy       
        int max = 0;
        int ans = 0;

        for(int i = n - 1; i >= 0; i--){
            if(occupancyCounts[i] >= max){
                max = occupancyCounts[i];
                ans = i;
            }
        }

        return ans;        
    }
}

/*
Algorithm:-

1. initialize rooms array of size len(meetings), default 0 values
2. min-heap to store occupiedRooms, with priority as the endTime
	- startTime
	- endTime
	- roomIndex
3. min-heap to store the freeRooms, with priority as the roomIndex
4. sort the input meetings by startTime
5. init currentTime to 0
6. iterate over each meetings in the input
7. update currentTime as max(currentTime, startTime of meetings[i][0])
8. check if no free rooms
	- get the freeTime (endTime -> occupiedRooms.Peek()) of the meeting which will get freed sooner from occupiedRooms
	- set currentTime = max(currentTime, freeTime)
9. free the rooms if they are done with meetings
	- while rooms are occupied occupiedRooms.Count > 0 and occupiedRooms.Peek <= currentTime
		- free the room. freedRoom = occupiedRooms.dequeue()
		- add freedRoom in freeRooms freeRooms.Enqueue(freeRoom)
10. get nextFreeRoom from freeRooms
11. increment the value of the room index for the nextFreeRoom which now will be used
	- nextFreeRoom = freeRooms.dequeue()
	- rooms[nextFreeRoom] += 1
	- add the next room into occupiedRooms
		- occupiedRooms.Enqueue((currentTime, currentime + meetings[i][1] - meetings[i][0], nextFreeRoom), currentTime + meetings[i][1] - meetings[i][0]
12. after the end of iteration of input meetings calculate the room with max value (max occupancy) and return the room with lowest index
	- max = 0, output = 0
	- reverse loop over rooms and check rooms[i] >= max
		- then set max = rooms[i]
		- and output = i
	- return output

—---------------------------------------------------------------------


*/