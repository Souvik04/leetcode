public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        int[] output = new int[k];
        Dictionary<int, int> freqMap = new Dictionary<int, int>();
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach(int n in nums){
            if(!freqMap.ContainsKey(n)){
                freqMap[n] = 0;
            }

            freqMap[n]++;
        }

        foreach(var kv in freqMap){
            minHeap.Enqueue(kv.Key, kv.Value);

            if(minHeap.Count > k){
                minHeap.Dequeue();
            }
        }

        for(int i = 0; i < k; i++){
            output[i] = minHeap.Dequeue();
        }

        return output;
    }
}

/*

// quick select (Hoare's algorithm)

    public int[] TopKFrequent(int[] nums, int k) {
        IList<int> output = new List<int>();
        Dictionary<int, int> freqMap = new Dictionary<int, int>();
        IList<int>[] bucket = new List<int>[nums.Length + 1];

        foreach(int n in nums){
            if(!freqMap.ContainsKey(n)){
                freqMap.Add(n, 0);
            }

            freqMap[n]++;
        }

        foreach(var kv in freqMap){
            if(bucket[kv.Value] == null){
                bucket[kv.Value] = new List<int>();
            }

            bucket[kv.Value].Add(kv.Key);
        }

        for(int i = bucket.Length - 1; i >= 0 && output.Count < k; i--){
            if(bucket[i] != null){
                for(int c = 0; c < bucket[i].Count && output.Count < k; c++){
                    output.Add(bucket[i][c]);
                }
            }
        }

        return output.ToArray();
    }

*/