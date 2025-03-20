public class Solution {  
    public int[] GetOrder(int[][] tasks) {  
        List<int> output = new List<int>();
        List<(int enqueueTime, int processingTime, int index)> indexedTasks = new();

        // Step 1: Initialize an empty list of tasks.
        for(int t = 0; t < tasks.Length; t++){
            indexedTasks.Add((tasks[t][0], tasks[t][1], t));
        }

        // Step 2: Sort the task list by enqueue time.
        indexedTasks.Sort((a, b) => a.enqueueTime.CompareTo(b.enqueueTime));

        PriorityQueue<(int processingTime, int index), (int, int)> tasksQueue = new();
        int time = 0;
        int i = 0;

        // Step 3: Process tasks based on the conditions
        while(i < indexedTasks.Count || tasksQueue.Count > 0){
            if(tasksQueue.Count == 0){
                time = Math.Max(time, indexedTasks[i].enqueueTime);
            }

            // Step 4: Advance time to the next available task
            while(i < indexedTasks.Count && indexedTasks[i].enqueueTime <= time){
                // Step 5: Add available tasks to the priority queue
                tasksQueue.Enqueue((indexedTasks[i].processingTime, i), (indexedTasks[i].processingTime, i));
                i++;
            }

            // Step 6: Process the next task from the priority queue
            var task = tasksQueue.Dequeue();
            time += task.processingTime;
            output.Add(task.index);
        }

        // Step 7: Return the output as array
        return output.ToArray();
    }  
}


/*

1. Prepare tasks: Convert each task into a tuple (enqueueTime, processingTime, index) and store them in a list.
2. Sort tasks: Sort the list based on enqueue time.
3. Initialize data structures:
	- Use a priority queue to process tasks in order of (processingTime, index).
	- Maintain a time variable to track the current time.
	- Keep an output list to store the order of completed tasks.
4. Process tasks:
	- If no tasks are available in the queue, fast-forward time to the next available task.
	- Add all tasks that can start at the current time to the priority queue.
	- Pick the task with the smallest processing time (or smallest index in case of ties), execute it, and update time.
	- Store the task index in output.
5. Repeat until all tasks are processed, then return the output list.

----

Time complexity: O(nlogn)
Space complexity: O(n)

*/ 