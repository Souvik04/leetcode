public class Solution {  
    public int[] GetOrder(int[][] tasks) {  
        List<int> output = new List<int>();
        List<(int, int, int)> indexedTasks = new List<(int, int, int)>();

        for(int t = 0; t < tasks.Length; t++){
            int startTime = tasks[t][0];
            int procTime = tasks[t][1];

            indexedTasks.Add(new (startTime, procTime, t));
        }

        // Sort the indexedTasks by startTime
        indexedTasks.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        int time = 0;
        int i = 0;
        SortedSet<(int, int)> tasksQueue = new SortedSet<(int, int)>();

        while(i < indexedTasks.Count || tasksQueue.Count > 0){
            if(tasksQueue.Count == 0){
                time = Math.Max(time, indexedTasks[i].Item1);
            }

            while(i < indexedTasks.Count && indexedTasks[i].Item1 <= time){
                tasksQueue.Add(new (indexedTasks[i].Item2, indexedTasks[i].Item3));
                i++;
            }

            var task = tasksQueue.Min;
            tasksQueue.Remove(task);
            time += task.Item1;
            output.Add(task.Item2);
        }

        return output.ToArray();
    }  
}  

/*
1. Initialize an empty list of tasks, where each task is represented as a tuple containing its enqueue time, processing time, and original index.
2. Fill the task list by iterating over the input array, creating a tuple for each task and adding it to the list.
3. Sort the task list by enqueue time.
4. Initialize an empty SortedSet to be used as a priority queue, where tasks with smaller processing times and indices are given higher priority.
5. Initialize a time variable to keep track of the current time and an index variable to keep track of the current task.
6. Initialize an empty list to store the output, which will be the order in which tasks are completed.
7. Start a loop that continues until all tasks have been processed. In each iteration of the loop:
	- If the priority queue is empty, advance the current time to the enqueue time of the next task.
	- Add all tasks that can be executed at the current time to the priority queue.
	- Remove the task at the top of the priority queue, add its processing time to the current time, and add its original index to the output list.
8. Once all tasks have been processed, convert the output list to an array and return it.
*/ 
