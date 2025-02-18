/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        /*
        // recursive
        if(root.val > p.val && root.val > q.val){
            return LowestCommonAncestor(root.left, p, q);
        }

        if(root.val < p.val && root.val < q.val){
            return LowestCommonAncestor(root.right, p, q);
        }

        return root;        
        */

        // iterative
        if(root == null || p == null || q == null){
            return null;
        }

        while(root != null){
            if(root.val > p.val && root.val > q.val){
                root = root.left;
            }
            else if(root.val < p.val && root.val < q.val){
                root = root.right;
            }
            else{
                return root;
            }
        }

        return null;
    }
}