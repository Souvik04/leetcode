/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;
    
    public Node() {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }
    
    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public Node FindRoot(List<Node> tree) {
        int rootVal = 0;
        
        foreach(Node node in tree){
            rootVal ^= node.val; // can also do + here
            foreach(Node child in node.children){
                rootVal ^= child.val; // can also do - here
            }
        }
        
        foreach(Node node in tree){
            if(node.val == rootVal){
                return node;
            }
        }
        
        return null;
    }
}

/*

This approach is based on the idea of finding an element in an array which is not repeated twice
int[] arr = [4, 3, 5, 3, 4]

we apply xor operation on a running sum and return sum as answer

Time complexity: O(n)
Space complexity: O(1)

*/