public class AutocompleteSystem {
    TrieNode root;
    StringBuilder inputPrefix;
    TrieNode currentNode;

    public AutocompleteSystem(string[] sentences, int[] times) {
        root = new TrieNode();
        inputPrefix = new StringBuilder();
        currentNode = root;

        for (int i = 0; i < sentences.Length; i++) {
            Insert(sentences[i], times[i]);
        }
    }

    public IList<string> Input(char c) {
        if (c == '#') {
            Insert(inputPrefix.ToString(), 1);
            inputPrefix.Clear();
            currentNode = root; // Reset to the root for new input
            return new List<string>();
        }

        inputPrefix.Append(c);

        if (currentNode != null && currentNode.children.ContainsKey(c)) {
            currentNode = currentNode.children[c];
        } else {
            currentNode = null;
        }

        if (currentNode == null) {
            return new List<string>();
        }

        // Use a priority queue to sort results based on frequency and lexicographical order
        PriorityQueue<(string sentence, int count), (int, string)> maxHeap =
            new PriorityQueue<(string, int), (int, string)>();

        foreach (var kv in currentNode.sentenceCounts) {
            maxHeap.Enqueue((kv.Key, kv.Value), (-kv.Value, kv.Key)); // Higher frequency, lexicographical tiebreaker
        }

        List<string> output = new List<string>();
        while (maxHeap.Count > 0 && output.Count < 3) {
            output.Add(maxHeap.Dequeue().sentence);
        }

        return output;
    }

    private void Insert(string s, int count) {
        TrieNode node = root;

        foreach (char c in s) {
            if (!node.children.ContainsKey(c)) {
                node.children[c] = new TrieNode();
            }
            node = node.children[c];
            if (!node.sentenceCounts.ContainsKey(s)) {
                node.sentenceCounts[s] = 0;
            }
            node.sentenceCounts[s] += count;
        }

        node.isEndOfWord = true;
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> children;
    public Dictionary<string, int> sentenceCounts;
    public bool isEndOfWord;

    public TrieNode() {
        children = new Dictionary<char, TrieNode>();
        sentenceCounts = new Dictionary<string, int>();
        isEndOfWord = false;
    }
}

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */
