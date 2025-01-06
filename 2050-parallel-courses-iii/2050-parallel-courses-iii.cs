public class Solution {
    public int MinimumTime(int n, int[][] relations, int[] time) {
        if (relations.Length == 0) {
            return time.Max(); // All courses can be taken in parallel.
        }
                
        int outputTime = 0;
        IList<int>[] graph = new List<int>[n + 1];
        Queue<int> queue = new Queue<int>();
        int[] inDegrees = new int[n + 1];
        int[] completionTime = new int[n + 1];

        for(int i = 0; i < n; i++){
            completionTime[i + 1] = time[i];
        }

        for(int i = 1; i <= n; i++){
            graph[i] = new List<int>();
        }

        for(int i = 0; i < relations.Length; i++){
            int from = relations[i][0];
            int to = relations[i][1];
            graph[from].Add(to);
            inDegrees[to]++;
        }

        for(int i = 1; i <= n; i++){
            if(inDegrees[i] == 0){
                queue.Enqueue(i);
            }
        }

        while(queue.Count > 0){
            int count = queue.Count;

            for(int i = 0; i < count; i++){
                int curCourse = queue.Dequeue();

                foreach(int dependentCourse in graph[curCourse]){
                    completionTime[dependentCourse] = Math.Max(completionTime[dependentCourse], completionTime[curCourse] + time[dependentCourse - 1]);
                    outputTime = Math.Max(outputTime, completionTime[dependentCourse]);
                    inDegrees[dependentCourse]--;

                    if(inDegrees[dependentCourse] == 0){
                        queue.Enqueue(dependentCourse);
                    }
                }
            }
        }

        return outputTime;
    }
}


/*

1. initialize inDegrees, completionTime, queue, graph
2. perform topological sort
3. for each neighbour (dependendent course) update completionTime[nbr] = max(completionTime[nbr], completionTime[curCourse] + time[nbr - 1]);
4. update output = max(output, completionTime[nbr])

Time complexity: O(n + m)
Space complexity: O(n + m)

*/