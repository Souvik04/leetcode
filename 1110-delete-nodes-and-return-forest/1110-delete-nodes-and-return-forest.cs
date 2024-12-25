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
    IList<TreeNode> result = null;
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        result = new List<TreeNode>();
        HashSet<int> deletedNodes = new HashSet<int>();
        
        foreach(int d in to_delete){
            deletedNodes.Add(d);
        }
        
        root = GetForest(root, result, deletedNodes);
            
        if(root != null){
            result.Add(root);
        }
        
        return result;
    }
    
    private TreeNode GetForest(TreeNode node, IList<TreeNode> result, HashSet<int> deletedNodes){
        if(node == null){
            return null;
        }
        
        node.left = GetForest(node.left, result, deletedNodes);
        node.right = GetForest(node.right, result, deletedNodes);
        
        if(deletedNodes.Contains(node.val)){
            if(node.left != null){
                result.Add(node.left);
            }
            
            if(node.right != null){
                result.Add(node.right);
            }
            
            return null;
        }
        
        return node;
    }
}

/*

1. declare List<TreeNode> result and a hashset to store deleted nodes
2. perform post order traversal with a function- GetForest(root, result, deletedNodes)
3. set root = GetForest(root, result, deletedNodes)
4. if root != null add to result
5. return result

post order using GetForest(root, result, deletedNodes)

1. if root is null return null
2. set node.left = GetForest(root.left, result, deletedNodes)
3. set node.left = GetForest(root.left, result, deletedNodes)
4. check if node in deletedNodes, then add its left and right children in result and return null
5. else return node

Time complexity: O(n)
Space complexity: O(n)


*/