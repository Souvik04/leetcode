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
    public bool FindTarget(TreeNode root, int k) {
        HashSet<int> set = new HashSet<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        
        queue.Enqueue(root);
        
        while(queue.Count > 0){
            var cur = queue.Dequeue();
            
            if(set.Contains(cur.val)){
                return true;
            }
            
            set.Add(k - cur.val);
            
            if(cur.left != null){
                queue.Enqueue(cur.left);
            }
            
            if(cur.right != null){
                queue.Enqueue(cur.right);
            }
        }
        
        return false;        
    }
}