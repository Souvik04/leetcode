public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        int maxTime = 0;
        // create subordinates
        List<List<int>> subordinates = new List<List<int>>();
        for(int i = 0; i < n; i++){
            subordinates.Add(new List<int>());
        }

        for(int i = 0; i < n; i++){
            if(manager[i] != -1){
                subordinates[manager[i]].Add(i);
            }
            
        }

        // create min-heap (Priority Queue): [(subordinate, currentTime), currentTime]
        PriorityQueue<(int, int), int> queue = new PriorityQueue<(int, int), int>();

        // enqueue head and currentTime as 0 initially
        queue.Enqueue((headID, 0), 0);

        // process the queue
        while(queue.Count > 0){
            var (curSub, currentTime) = queue.Dequeue();

            // update maxTime
            maxTime = Math.Max(maxTime, currentTime);

            // process for each subordinates
            foreach(var s in subordinates[curSub]){
                // enqueue the subordinate and updated infom time into queue
                queue.Enqueue((s, informTime[curSub] + currentTime), informTime[curSub] + currentTime);
            }
        }

        return maxTime;
    }
}

/*

1. create a list of subordinates where each employess item has a list of subordinate IDs for it
2. create a maxTime variable and a priority queue (min-heap) to store the subordinate and current time and order by current time
    - maxTime = 0
    - PriorityQueue<(int, int, int>: [(subordinate, currentTime), currentTime]
3. enqueue head and time 0 into the priority queue
    - queue.Enqueue((head, 0), 0);
4. while queue is not empty dequeue and store in current
    - update maxTime with max(maxTime, current.Item2)
    - foreach of subordinates[current.Item1]
        enqueue to queue [(s, current.Item2 + informTime[s]), current.Item2 + informTime[s]]


1. Initialize a list `subordinates` to represent the subordinates of each employee. Each element of `subordinates` is a list containing the IDs of subordinates for a given employee.

2. Populate the `subordinates` list by iterating through the `manager` array. For each employee, add their ID to the list of subordinates for their direct manager.

3. Initialize a variable `maxTime` to store the maximum time needed to inform all employees. Set it initially to 0.

4. Create a Priority Queue (min-heap) to efficiently process employees. Each element in the queue is a tuple `(employee, currentTime)` where `employee` is the ID of the employee to process, and `currentTime` is the accumulated time to inform this employee and their subordinates.

5. Enqueue the head of the company (the employee with ID `headID`) into the priority queue with `currentTime` set to 0.

6. While the priority queue is not empty:
   - Dequeue an element from the priority queue, obtaining the `current` employee ID and the `currentTime` needed to inform them and their subordinates.
   - Update `maxTime` by taking the maximum of `maxTime` and `currentTime`.

7. For each subordinate of the `current` employee, calculate the time needed to inform them, which is `currentTime + informTime[current]`, and enqueue them into the priority queue.

8. Repeat steps 6 and 7 until the priority queue is empty, processing employees in the order of their inform times.

9. After processing all employees, `maxTime` contains the maximum time needed to inform all employees.

10. Return `maxTime` as the result.
 

*/