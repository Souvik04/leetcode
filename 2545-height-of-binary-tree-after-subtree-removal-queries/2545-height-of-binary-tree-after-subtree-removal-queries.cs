/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int[] TreeQueries(TreeNode root, int[] queries) {
        var depthMap = new Dictionary<int, int>();
        var heightMap = new Dictionary<int, int>();
        
        DFS(root, 0, depthMap, heightMap);

        var cousins = new Dictionary<int, List<(int, int)>>();

        foreach (var kvp in depthMap){
            var val = kvp.Key;
            var depth = kvp.Value;
            cousins.TryAdd(depth, new List<(int, int)>());
            cousins[depth].Add((-heightMap[val], val));
            cousins[depth].Sort();

            if (cousins[depth].Count > 2)
                cousins[depth].RemoveAt(2);
        }

        var ans = new List<int>();
        foreach (var q in queries){
            var depth = depthMap[q];
            var cousinGroup = cousins[depth];

            if (cousinGroup.Count == 1){
                    ans.Add(depth - 1);
            }
            else{
                    var firstCousin = cousinGroup[0];
                    var secondCousin = cousinGroup[1];
                    if (q == firstCousin.Item2){
                            ans.Add(-secondCousin.Item1 + depth);
                    }
                    else{
                            ans.Add(-firstCousin.Item1 + depth);
                    }
            }
        }
        
        return ans.ToArray();
    }

    private int DFS(TreeNode node, int depth, Dictionary<int, int> depthMap, Dictionary<int, int> heightMap)
    {
        if (node == null)
            return -1;
        
        depthMap[node.val] = depth;
        var leftHeight = DFS(node.left, depth + 1, depthMap, heightMap);
        var rightHeight = DFS(node.right, depth + 1, depthMap, heightMap);
        var currentHeight = Math.Max(leftHeight, rightHeight) + 1;
        heightMap[node.val] = currentHeight;
        
        return currentHeight;
    }    
}


/*

1. Initialize two dictionaries: `depthMap` to store the depth of each node and `heightMap` to store the height of each node.

2. Perform a Depth-First Search (DFS) on the binary tree. For each node:
   - Calculate its depth and store it in `depthMap`.
   - Calculate its height and store it in `heightMap`.
   - Return the current height, which is the maximum of the heights of its left and right subtrees, plus 1.

3. Create a dictionary called `cousins` to group nodes at the same depth and keep track of the two deepest cousins for each depth.

4. For each depth in the `depthMap`, sort the cousins by their heights in descending order and keep only the two deepest cousins if there are more.

5. Initialize an empty list called `ans` to store the answers.

6. For each query node `q` in the `queries`:
   - Retrieve its depth and cousin group from the `cousins` dictionary.
   - If there is only one cousin in the group, subtract 1 from the depth and add it to the `ans`.
   - If there are two cousins in the group, compare `q` with both cousins and add the depth plus the difference in heights to the `ans`.

7. Return the `ans` list as the final result.

*/