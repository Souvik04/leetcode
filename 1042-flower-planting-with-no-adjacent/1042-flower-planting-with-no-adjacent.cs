public class Solution {
    public int[] GardenNoAdj(int n, int[][] paths) {
        int[] output = new int[n];
        List<int>[] graph = new List<int>[n + 1];

        // create graph
        for(int i = 1; i <= n; i++){
            graph[i] = new List<int>();
        }

        foreach(int[] p in paths){
            graph[p[0]].Add(p[1]);
            graph[p[1]].Add(p[0]);
        }

        // assign flowers to each garden
        for(int i = 1; i <= n; i++){
            bool[] usedFlowers = new bool[5];

            // mark flowers used by neighbors
            foreach(int nbr in graph[i]){
                if(output[nbr - 1] != 0){
                    usedFlowers[output[nbr - 1]] = true;
                }
            }

            // assign first available flower to current garden
            for(int f = 1; f <= 4; f++){
                if(!usedFlowers[f]){
                    output[i - 1] = f;
                    break;
                }
            }
        }

        return output;
    }
}

/*

Time complexity: O(n + e)
Space complexity: O(n + e)

*/