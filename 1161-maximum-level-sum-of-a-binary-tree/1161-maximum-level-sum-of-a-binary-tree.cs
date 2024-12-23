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
    public int MaxLevelSum(TreeNode root) {
        int maxLevel = 0;
        int curLevel = 0;
        int maxLevelSum = int.MinValue;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int level = 0;
        
        while(queue.Count > 0){
            curLevel++;
            int count = queue.Count;;
            int curLevelSum = 0;
            
            for(int i = 0; i < count; i++){
                var cur = queue.Dequeue();
                curLevelSum += cur.val;
                
                if(cur.left != null){
                    queue.Enqueue(cur.left);
                }
                
                if(cur.right != null){
                    queue.Enqueue(cur.right);
                }                
            }
            
            if(curLevelSum > maxLevelSum){
                maxLevel = curLevel;
                maxLevelSum = curLevelSum;
            }
        }
        
        return maxLevel;
    }
}

/*

Time complexity: O(n)
Space complexity: O(n)

*/