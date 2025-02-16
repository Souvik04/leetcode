public class Trie {
    TrieNode root = null;
    public Trie() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
        TrieNode node = root;

        foreach(char c in word){
            if(!node.children.ContainsKey(c)){
                node.children[c] = new TrieNode();
            }

            node = node.children[c];
        }

        node.isEndOfWord = true;
    }
    
    public bool Search(string word) {
        TrieNode node = root;

        foreach(char c in word){
            if(!node.children.ContainsKey(c)){
                return false;
            }

            node = node.children[c];
        }

        return node.isEndOfWord;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode node = root;

        foreach(char c in prefix){
            if(!node.children.ContainsKey(c)){
                return false;
            }

            node = node.children[c];
        }

        return true;
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
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */