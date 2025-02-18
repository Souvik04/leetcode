public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        int totalCourses = 0;
        Queue<int> queue = new Queue<int>();
        int[] inDegrees = new int[numCourses];
        List<int>[] graph = new List<int>[numCourses];

        for(int i = 0; i < numCourses; i++){
            graph[i] = new List<int>();
        }

        foreach(var p in prerequisites){
            int from = p[1];
            int to = p[0];
            graph[from].Add(to);
            inDegrees[to]++;
        }

        for(int i = 0; i < numCourses; i++){
            if(inDegrees[i] == 0){
                queue.Enqueue(i);
            }
        }

        while(queue.Count > 0){
            int cur = queue.Dequeue();
            totalCourses++;

            foreach(var neighbor in graph[cur]){
                inDegrees[neighbor]--;

                if(inDegrees[neighbor] == 0){
                    queue.Enqueue(neighbor);
                }
            }
        }

        return totalCourses == numCourses ? true : false;
    }
}