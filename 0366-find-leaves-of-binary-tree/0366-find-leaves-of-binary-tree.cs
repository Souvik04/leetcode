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

    private TreeNode GetLeaves(TreeNode node, IList<int> output){
        if(node == null){
            return null;
        }

        if(node.left == null && node.right == null){
            output.Add(node.val);
            return null;
        }

        node.left = GetLeaves(node.left, output);
        node.right = GetLeaves(node.right, output);

        return node;
    }
}

/*

1. Define a class `TreeNode` representing the structure of a binary tree node, which includes a value, left and right child nodes.

2. Create a function named `FindLeaves` that takes a `root` node of a binary tree as input and returns a list of lists of integers (IList<IList<int>>).

3. Initialize an empty list of lists named `output` to store the leaves of the binary tree.

4. Start a while loop that continues as long as the `root` node is not null. This loop is used to process the leaves of the tree.

5. Inside the loop, create an empty list of integers named `leaves` to store the leaves of the current level.

6. Call the `GetLeaves` function, passing the current `root` node and the `leaves` list as arguments. This function is responsible for finding and adding the leaves of the current level to the `leaves` list.

7. After calling `GetLeaves`, add the `leaves` list to the `output` list, effectively collecting the leaves of the current level.

8. Update the `root` node to the result of the `GetLeaves` function, which will be the root node of the next level.

9. Repeat steps 6-8 until the `root` becomes null, indicating that all leaves have been processed.

10. Return the `output` list, which now contains lists of leaves at each level of the binary tree.

11. Define a private function named `GetLeaves` that takes a `node` as input and an `output` list to store the leaves for the current level.

12. Inside the `GetLeaves` function, check if the `node` is null. If it is, return null, indicating the end of a branch.

13. Check if the `node` is a leaf node, meaning it has no left or right children. If it is a leaf node, add its value to the `output` list, and return null to remove it from the tree.

14. If the `node` is not a leaf, recursively call the `GetLeaves` function on its left and right children. This allows us to traverse the left and right subtrees and find the leaves of the current level.

15. Return the `node` after processing its children. This maintains the structure of the tree by updating its left and right children while removing any leaf nodes.


*/