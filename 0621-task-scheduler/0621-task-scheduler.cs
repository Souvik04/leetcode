public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int time = 0;

        // Step 1: calculate frequencies
        int[] taskFreq = new int[26];

        foreach(char task in tasks){
            taskFreq[task - 'A']++;
        }

        // Step 2: create max-heap from frequencies
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        foreach(int freq in taskFreq){
            if(freq > 0){
                maxHeap.Enqueue(freq, -freq);
            }
        }

        // Step 3: process the tasks
        Queue<(int freq, int availableTime)> queue = new Queue<(int, int)>();

        while(maxHeap.Count > 0 || queue.Count > 0){
            time++;

            // process from max-heap
            if(maxHeap.Count > 0){
                int freq = maxHeap.Dequeue();

                if(freq > 1){
                    queue.Enqueue((freq - 1, time + n));
                }
            }

            // process waiting tasks
            if(queue.Count > 0 && queue.Peek().availableTime == time){
                var cur = queue.Dequeue();
                maxHeap.Enqueue(cur.freq, -cur.freq);
            }
        }

        return time;
    }
}

/*

1. store the frequencies of each tasks
2. enqueue the frequencies in max-heap
3. initialize time = 0 and a queue (int freq, availableTime) to simulate task scheduling and cooldown
4. while max-heap is not empty or there are tasks waiting in cooldown queue
    - increment time by 1
    - if max-heap has item, decrement freq and update availableTime
        - add to queue queue.Enqueue(freq - 1, time + n)
    - if cooldown queue is not empty, check if queue.peek().availableTime == time
        - then dequeue item
        - add it to max-heap (freq, -freq)
5. return time as output

----

Time complexity: O(n)
Space complexity: O(n)

*/