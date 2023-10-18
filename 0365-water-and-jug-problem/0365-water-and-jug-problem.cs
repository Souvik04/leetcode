public class Solution {
    public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity) {
        HashSet<(int, int)> visited = new HashSet<(int, int)>();
        Queue<(int, int)> queue = new Queue<(int, int)>();

        queue.Enqueue((0, 0));

        while(queue.Count > 0){
            var cur = queue.Dequeue();
            int curJug1 = cur.Item1;
            int curJug2 = cur.Item2;

            if(curJug1 == targetCapacity || curJug2 == targetCapacity || curJug1 + curJug2 == targetCapacity){
                return true;
            }

            visited.Add((curJug1, curJug2));

            // fill jug1 only
            if(!visited.Contains((jug1Capacity, curJug2))){
                queue.Enqueue((jug1Capacity, curJug2));
            }

            // fill jug2 only
            if(!visited.Contains((curJug1, jug2Capacity))){
                queue.Enqueue((curJug1, jug2Capacity));
            }

            // empty jug1 only
            if(!visited.Contains((0, curJug2))){
                queue.Enqueue((0, curJug2));
            }

            // empty jug2 only
            if(!visited.Contains((curJug1, 0))){
                queue.Enqueue((curJug1, 0));
            }

            // pour from jug1 to jug2
            int pour1 = Math.Min(curJug1, jug2Capacity - curJug2);
            if(!visited.Contains((curJug1 - pour1, curJug2 + pour1))){
                queue.Enqueue((curJug1 - pour1, curJug2 + pour1));
            }

            // pour from jug2 to jug1
            int pour2 = Math.Min(jug1Capacity - curJug1, curJug2);
            if(!visited.Contains((curJug1 + pour2, curJug2 - pour2))){
                queue.Enqueue((curJug1 + pour2, curJug2 - pour2));
            }
        }

        return false;
    }
}

/*
1. create a HashSet<(int, int)> to mark as visited
2. create a Queue<(int, int)> for BFS
3. enqueue (0, 0) into queue as starting
4. while queue not empty perform BFS
    - dequeue cur from BFS and set curJug1 = cur.Item1 and curJug2 = cur.Item2
    - if curJug1 + curJug2 == targetCapacity, return true
    - perform all three operations
        - fill jug 1 or jug 2 and mark visited
        - empty jug 1 or jug 2 and mark visited
        - pour from jug 1 to jug 2 or jug 2 to jug 1 and mark visited
5. return false after BFS ends
*/