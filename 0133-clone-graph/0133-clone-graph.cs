/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        return DFS(node, new Dictionary<Node, Node>());
    }

    private Node DFS(Node node, Dictionary<Node, Node> visited){
        if(node == null){
            return null;
        }

        if(visited.ContainsKey(node)){
            return visited[node];
        }

        Node newNode = new Node(node.val);
        visited.Add(node, newNode);

        foreach(Node neighbor in node.neighbors){
            Node newNeighbor = DFS(neighbor, visited);
            newNode.neighbors.Add(newNeighbor);
        }

        return newNode;
    }
}

/*

1. initialize a map<Node, Node> to store source node and cloned node and avoid revisitng/recloning a node
2. perform DFS from root
3. if root is null return null or check if node exists in map and return
4. create new Node() and add to map
5. perform DFS recursively on neighbors and create new neighbor nodes out of DFS and add to newNode's neighbors
6. return newNode
7. call DFS in parent function and return it

Time complexity: O(E + V)
Space complexity: O(E + V)

*/