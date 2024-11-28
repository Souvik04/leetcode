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
    public IList<IList<int>> FindLeaves(TreeNode root) {
        IList<IList<int>> output = new List<IList<int>>();

        while(root != null){
            IList<int> leaves = new List<int>();
            root = GetLeaves(root, leaves);
            output.Add(leaves);
        }

        return output;
    }

    private TreeNode GetLeaves(TreeNode node, IList<int> leaves){
        if(node == null){
            return null;
        }

        if(node.left == null && node.right == null){
            leaves.Add(node.val);
            return null;
        }

        node.left = GetLeaves(node.left, leaves);
        node.right = GetLeaves(node.right, leaves);

        return node;
    }
}

/*

Time complexity: O(n)
Space complexity: O(n)

*/