public class MyHashSet {
    private LinkedList<int>[] hashSet = null;
    private const int MAX_SIZE = 1000;

    public MyHashSet() {
        hashSet = new LinkedList<int>[MAX_SIZE];
    }
    
    public void Add(int key) {
        int hash = GetHash(key);

        if(hashSet[hash] == null){
            hashSet[hash] = new LinkedList<int>();
        }

        if(!hashSet[hash].Contains(key)){
            hashSet[hash].AddLast(key);
        }
    }
    
    public void Remove(int key) {
        int hash = GetHash(key);

        if(hashSet[hash] != null){
            hashSet[hash].Remove(key);
        }
    }
    
    public bool Contains(int key) {
        int hash = GetHash(key);

        return hashSet[hash] != null && hashSet[hash].Contains(key);
    }

    private int GetHash(int key){
        return key % MAX_SIZE;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */