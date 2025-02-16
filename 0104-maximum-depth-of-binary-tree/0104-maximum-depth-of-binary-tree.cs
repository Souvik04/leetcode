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
    public int MaxDepth(TreeNode root) {
        if(root == null){
            return 0;
        }

        int maxDepth = 0;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0){
            int count = queue.Count;

            for(int i = 0; i < count; i++){
                TreeNode cur = queue.Dequeue();

                if(cur.left != null){
                    queue.Enqueue(cur.left);
                }

                if(cur.right != null){
                    queue.Enqueue(cur.right);
                }
            }

            maxDepth++;
        }

        return maxDepth;

        /*
        // recursive
        if(root == null){
            return 0;
        }

        int left = MaxDepth(root.left);
        int right = MaxDepth(root.right);

        return Math.Max(left, right) + 1;
        */
    }
}