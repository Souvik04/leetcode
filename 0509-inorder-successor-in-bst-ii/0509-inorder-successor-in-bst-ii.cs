/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    public Node InorderSuccessor(Node inputNode) {
        // if right is not null, get min key from right subtree
        if(inputNode.right != null){
        return GetMinKey(inputNode.right);
        }
        
        Node ancestor = inputNode.parent;
        Node child = inputNode;
        
        // keep going up
        while(ancestor != null && child.Equals(ancestor.right)){
        child = ancestor;
        ancestor = child.parent;
        }
        
        return ancestor;        
    }

  // Gets min key from right subtree
  private Node GetMinKey(Node inputNode){
    while(inputNode.left != null){
      inputNode = inputNode.left;
    }
    
    return inputNode;
  }    
}