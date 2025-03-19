public class MyHashMap {
    private LinkedList<KeyValuePair<int, int>>[] hashSet = null;
    private const int MAX_SIZE = 1000;

    public MyHashMap() {
        hashSet = new LinkedList<KeyValuePair<int, int>>[MAX_SIZE];
    }
    
    public void Put(int key, int value) {
        int hash = GetHash(key);

        if(hashSet[hash] == null){
            hashSet[hash] = new LinkedList<KeyValuePair<int, int>>();
        }

        var list = hashSet[hash];

        foreach(var pair in list){
            if(pair.Key == key){
                list.Remove(pair);
                break;
            }
        }

        hashSet[hash].AddLast(new KeyValuePair<int, int>(key, value));
    }
    
    public int Get(int key) {
        int hash = GetHash(key);

        if(hashSet[hash] != null){
            foreach(var pair in hashSet[hash]){
                if(pair.Key == key){
                    return pair.Value;
                }
            }
        }

        return -1;
    }
    
    public void Remove(int key) {
        int hash = GetHash(key);

        if(hashSet[hash] != null){
            foreach(var pair in hashSet[hash]){
                if(pair.Key == key){
                    hashSet[hash].Remove(pair);
                    break;
                }
            }
        }
    }

    private int GetHash(int key){
        return key % MAX_SIZE;
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */