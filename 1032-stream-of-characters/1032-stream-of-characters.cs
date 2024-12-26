public class StreamChecker {
    TrieNode root = null;
    Queue<char> stream = null;
    int maxLength = 0;
    public StreamChecker(string[] words) {
        root = new TrieNode();
        
        // insert into trie
        foreach(string word in words){
            maxLength = Math.Max(maxLength, word.Length);
            Insert(word, root);
        }
        
        stream = new Queue<char>();
    }
    
    public bool Query(char letter) {
        stream.Enqueue(letter);
        if (stream.Count > maxLength) {
            stream.Dequeue(); // Maintain the relevant portion of the stream.
        }

        TrieNode node = root;
        foreach (char c in stream.Reverse()) { // Traverse in reverse order.
            if (!node.children.ContainsKey(c)) {
                return false;
            }
            node = node.children[c];
            if (node.isEndOfWord) {
                return true;
            }
        }

        return false;
    }

    
    private void Insert(string word, TrieNode root){
        TrieNode node = root;

        // reverse insert
        for(int i = word.Length - 1; i >= 0; i--){
            if(!node.children.ContainsKey(word[i])){
                node.children[word[i]] = new TrieNode();
            }

            node = node.children[word[i]];
        }

        node.isEndOfWord = true;
    }
}

public class TrieNode{
    public Dictionary<char, TrieNode> children;
    public bool isEndOfWord;
    
    public TrieNode(){
        this.children = new Dictionary<char, TrieNode>();
        this.isEndOfWord = false;
    }
}

/**
 * Your StreamChecker object will be instantiated and called as such:
 * StreamChecker obj = new StreamChecker(words);
 * bool param_1 = obj.Query(letter);

 Time complexity: O(m)
 Space complexity: O(m)

 */