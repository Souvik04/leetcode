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
    public IList<int> RightSideView(TreeNode root) {
        if(root == null){
            return new List<int>();
        }
        
        IList<int> output = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0){
            int count = queue.Count;
            int rightVal = 0;
            
            for(int i = 0; i < count; i++){
                var cur = queue.Dequeue();
                rightVal = cur.val;

                if(cur.left != null){
                    queue.Enqueue(cur.left);
                }

                if(cur.right != null){
                    queue.Enqueue(cur.right);
                }
            }

            output.Add(rightVal);
        }

        return output;
    }
}