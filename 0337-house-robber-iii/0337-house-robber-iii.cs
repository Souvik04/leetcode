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
    public int Rob(TreeNode root) {
        int[] max = GetVal(root);
        return Math.Max(max[0], max[1]);
    }

    private int[] GetVal(TreeNode node){
        if(node == null){
            return new int[]{0, 0};
        }

        int[] left = GetVal(node.left);
        int[] right = GetVal(node.right);

        int rob = node.val + left[1] + right[1];
        int dontRob = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

        return new int[]{rob, dontRob};
    }
}

/*

1. create a function GetVal(TreeNode node) which take TreeNode as input and returns an int array of size 2 as output
2. check if node == null then return array with [0,0]
3. int[] = GetVal(node.left)
4. int[] = GetVal(node.right)
5. check for both scenarios if current node can be robbed or not robbed
    - rob current and dont rob immediate children: int rob = node.val + left[1] + right[1]
        - int rob = node.val + left[1] + right[1]
    - dont rob current and rob/dont rob immediate children
        - int dontRob = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1])
6. return int[]{rob, dontRob}
7. call GetVal(root) and return max(arr[0], arr[1])
*/