public class LRUCache {
    LinkedList<KeyValuePair<int, int>> _cache = null;
    Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _map = null;
    int _capacity;
    public LRUCache(int capacity) {
        _cache = new LinkedList<KeyValuePair<int, int>>();
        _map = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
        _capacity = capacity;
    }
    
    public int Get(int key) {
        if(_map.ContainsKey(key)){
            var node = _map[key];
            _cache.Remove(node);
            _cache.AddFirst(node.Value);
            return _map[key].Value.Value;
        }

        return -1;
    }
    
    public void Put(int key, int value) {
        if(_map.ContainsKey(key)){
            var curNode = _map[key];
            _cache.Remove(curNode);
            curNode.Value = new KeyValuePair<int, int>(key, value);
            _cache.AddFirst(curNode);
            _map[key] = curNode;
        }
        else{
            if(_capacity == _map.Count){
                var rem = _cache.Last;
                _map.Remove(rem.Value.Key);
                _cache.RemoveLast();
            }

            var kv = new KeyValuePair<int, int>(key, value);
            var newNode = new LinkedListNode<KeyValuePair<int, int>>(kv);
            _cache.AddFirst(newNode);
            _map[key] = newNode;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */