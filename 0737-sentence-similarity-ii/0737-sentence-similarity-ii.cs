public class Solution {
    Dictionary<string, Node> nodes = null;

    public bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs) {
        if (sentence1.Length != sentence2.Length) {
            return false;
        }

        nodes = new Dictionary<string, Node>();

        // Build the Union-Find structure
        foreach (IList<string> pair in similarPairs) {
            Union(pair[0], pair[1]);
        }

        // Compare sentences
        for (int i = 0; i < sentence1.Length; i++) {
            if (Find(sentence1[i]) != Find(sentence2[i])) {
                return false;
            }
        }

        return true;
    }

    private string Find(string word) {
        // Initialize node dynamically if not present
        if (!nodes.ContainsKey(word)) {
            nodes[word] = new Node(word);
        }

        // Path compression
        if (nodes[word].parent != word) {
            nodes[word].parent = Find(nodes[word].parent);
        }

        return nodes[word].parent;
    }

    private void Union(string word1, string word2) {
        string root1 = Find(word1);
        string root2 = Find(word2);

        if (root1 == root2) {
            return; // Already in the same set
        }

        // Union by rank
        if (nodes[root1].rank < nodes[root2].rank) {
            nodes[root1].parent = root2;
        } else if (nodes[root1].rank > nodes[root2].rank) {
            nodes[root2].parent = root1;
        } else {
            nodes[root2].parent = root1;
            nodes[root1].rank++; // Increment rank if equal
        }
    }
}

public class Node {
    public string parent { get; set; }
    public int rank { get; set; }

    public Node(string parent) {
        this.parent = parent;
        this.rank = 0;
    }
}
