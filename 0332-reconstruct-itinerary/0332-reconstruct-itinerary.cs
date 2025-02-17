public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        Stack<string> output = new Stack<string>();
        Dictionary<string, PriorityQueue<string, string>> map = new();
        
        foreach(var ticket in tickets){
            if(!map.ContainsKey(ticket[0])){
                map[ticket[0]] = new PriorityQueue<string, string>();
            }

            map[ticket[0]].Enqueue(ticket[1], ticket[1]);
        }

        DFS(map, "JFK", output);

        return output.ToList();
    }

    private void DFS(Dictionary<string, PriorityQueue<string, string>> map, string current, Stack<string> output){
        if(map.ContainsKey(current)){
            var temp = map[current];
            
            while(temp.Count > 0){
                string neighbour = temp.Dequeue();
                DFS(map, neighbour, output);
            }
        }

        output.Push(current);        
    }
}

/*

1. create a map <string, PriorityQueue<string, string>> to represent the adjacency list
2. create a queue<string> and enqueue the starting airport "JFK"
3. while queue is not empty perform DFS
4. in DFS, check if current airport (current) is in map and if it has any adjacent items
5. while count of adjacency items not 0, dequeue each item from priority queue nad push to call DFS for dequeued item
6. push the current airport (current) to stack
7. return stack.ToList() as output at the end

Time complexity: O(E + V * dlogd)
Space complexity: O(E + V)

*/