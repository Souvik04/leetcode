public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        List<int>[] graph = new List<int>[numCourses];
        int[] inDegrees = new int[numCourses];
        Queue<int> queue = new Queue<int>();
        int coursesCompleted = 0;

        // build the graph
        for(int i = 0; i < numCourses; i++){
            graph[i] = new List<int>();
        }

        foreach(int[] p in prerequisites){
            int a = p[0];
            int b = p[1];
            graph[b].Add(a);
            inDegrees[a]++;
        }

        // enqueue all nodes with in-degree 0 into the queue
        for(int i = 0; i < numCourses; i++){
            if(inDegrees[i] == 0){
                queue.Enqueue(i);
            }
        }

        // explore the queue
        while(queue.Count > 0){
            int curCourse = queue.Dequeue();
            coursesCompleted++;

            foreach(int neighbour in graph[curCourse]){
                inDegrees[neighbour]--;

                if(inDegrees[neighbour] == 0){
                    queue.Enqueue(neighbour);
                }
            }
        }

        return coursesCompleted == numCourses;
    }
}