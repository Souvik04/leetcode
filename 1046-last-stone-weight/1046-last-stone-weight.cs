public class Solution {
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        foreach(int stone in stones){
            maxHeap.Enqueue(stone, -stone);
        }

        while(maxHeap.Count > 1){
            int stone1 = maxHeap.Dequeue();
            int stone2 = maxHeap.Dequeue();
            
            if(stone1 != stone2){
                int diff = Math.Abs(stone1 - stone2);
                maxHeap.Enqueue(diff, -diff);
            }
        }

        return maxHeap.Count == 0 ? 0 : maxHeap.Dequeue();
    }
}