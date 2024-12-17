public class Solution {
    public int[] AssignBikes(int[][] workers, int[][] bikes) {
        int n = workers.Length;
        int m = bikes.Length;
        int[] result = new int[n];        
        HashSet<int> assignedWorkers = new HashSet<int>();
        HashSet<int> assignedBikers = new HashSet<int>();
        
        // create list to store (distance, worker, bike)
        List<(int distance, int worker, int biker)> resources = new List<(int, int, int)>();
        
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                int distance = Math.Abs(workers[i][0] - bikes[j][0]) + Math.Abs(workers[i][1] - bikes[j][1]);
                resources.Add((distance, i, j));
            }
        }
        
        // sort by distance, then worker, then biker
        resources.Sort((a,b) => {
           if(a.distance != b.distance){
               return a.distance.CompareTo(b.distance);
           }
           else if(a.worker != b.worker){
               return a.worker.CompareTo(b.worker);
           }
            else{
                return a.biker.CompareTo(b.biker);                
            }
        });
        
        // assign bikes to workers
        foreach(var cur in resources){
            if(!assignedWorkers.Contains(cur.worker) && !assignedBikers.Contains(cur.biker)){
                assignedWorkers.Add(cur.worker);
                assignedBikers.Add(cur.biker);
                result[cur.worker] = cur.biker;
            }
            
            // all assignments completed
            if(assignedWorkers.Count == n){
                return result;
            }
        }
        
        return result;
    }
}