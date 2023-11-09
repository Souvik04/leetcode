public class Solution {
    int maxRequests = 0;
    public int MaximumRequests(int n, int[][] requests) {
        int[] inDegrees = new int[n];
        Backtrack(requests, inDegrees, 0, 0);
        return maxRequests;
    }

    private void Backtrack(int[][] requests, int[] inDegrees, int index, int count){
        if(index == requests.Length){
            for(int i = 0; i < inDegrees.Length; i++){
                if(inDegrees[i] != 0){
                    return;
                }
            }

            maxRequests = Math.Max(maxRequests, count);
            return;
        }

        inDegrees[requests[index][0]]--;
        inDegrees[requests[index][1]]++;
        Backtrack(requests, inDegrees, index + 1, count + 1);

        inDegrees[requests[index][0]]++;
        inDegrees[requests[index][1]]--;
        Backtrack(requests, inDegrees, index + 1, count);
    }
}