public class Solution {
    int maxTime = int.MinValue;
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        // employee to subordinates map
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++){
            map[i] = new List<int>();
        }

        for(int i = 0; i < n; i++){
            if(manager[i] != -1){
                map[manager[i]].Add(i);
            }
        }

        DFS(map, informTime, headID, 0);

        return maxTime;
    }

    private void DFS(Dictionary<int, List<int>> map, int[] informTime, int emp, int time){
        maxTime = Math.Max(maxTime, time);

        foreach(var s in map[emp]){
            DFS(map, informTime, s, time + informTime[emp]);
        }
    }
}