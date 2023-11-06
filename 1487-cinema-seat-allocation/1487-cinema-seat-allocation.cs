public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        int maxGroups = 0;
        Dictionary<int, IList<int>> rowSeats = new Dictionary<int, IList<int>>();

        foreach(var seat in reservedSeats){
            if(!rowSeats.ContainsKey(seat[0])){
                rowSeats.Add(seat[0], new List<int>());
            }

            rowSeats[seat[0]].Add(seat[1]);
        }

        maxGroups = 2 * (n - rowSeats.Count);

        foreach(var kv in rowSeats){
            bool flag = false;
            var resSeats = kv.Value;
            // possibility 1: left column
            if(!resSeats.Contains(2) && !resSeats.Contains(3) && !resSeats.Contains(4) && !resSeats.Contains(5)){
                flag = true;
                maxGroups++;
            }

            // possibility 2: right column
            if(!resSeats.Contains(6) && !resSeats.Contains(7) && !resSeats.Contains(8) && !resSeats.Contains(9)){
                flag = true;
                maxGroups++;
            }  

            // possibility 3: mid column only if left and right column unused
            if(!flag && !resSeats.Contains(4) && !resSeats.Contains(5) && !resSeats.Contains(6) && !resSeats.Contains(7)){
                maxGroups++;
            }
        }

        return maxGroups;
    }
}