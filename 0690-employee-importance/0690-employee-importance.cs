/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

class Solution {
    public int GetImportance(IList<Employee> employees, int id) {
        int importance = 0;

        // create adjacency list- graph
        Dictionary<int, (int, List<int>)> graph = new Dictionary<int, (int, List<int>)>();
        foreach(var e in employees){
            if(!graph.ContainsKey(e.id)){
                graph[e.id] = (e.importance, new List<int>());
            }

            foreach(var s in e.subordinates){
                graph[e.id].Item2.Add(s);
            }
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(id);

        while(queue.Count > 0){
            int count = queue.Count;

            for(int i = 0; i < count; i++){
                int cur = queue.Dequeue();

                importance += graph[cur].Item1;

                foreach(var s in graph[cur].Item2){
                    queue.Enqueue(s);
                }
            }
        }

        // perform BFS
        return importance;
    }
}