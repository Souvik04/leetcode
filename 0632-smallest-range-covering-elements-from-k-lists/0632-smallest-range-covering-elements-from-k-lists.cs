public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
        int[] output = new int[2];
        int minValue = int.MaxValue;
        int maxValue = int.MinValue;
        int bestStart = 0;
        int bestEnd = int.MaxValue;

        PriorityQueue<(int value, int listIndex, int valueIndex), int> minHeap = new();

        // Initialize the heap with the first element of each list
        for (int i = 0; i < nums.Count; i++) {
            int value = nums[i][0];
            minValue = Math.Min(minValue, value);
            maxValue = Math.Max(maxValue, value);
            minHeap.Enqueue((value, i, 0), value);
        }

        // Process the heap until one of the lists is exhausted
        while (minHeap.Count == nums.Count) { // Ensure all lists are represented
            var cur = minHeap.Dequeue();
            minValue = cur.value; // Update minValue with the dequeued value

            // Update the smallest range if the current range is smaller
            if (maxValue - minValue < bestEnd - bestStart) {
                bestStart = minValue;
                bestEnd = maxValue;
            }

            // Move to the next element in the same list
            if (cur.valueIndex < nums[cur.listIndex].Count - 1) {
                int newValue = nums[cur.listIndex][cur.valueIndex + 1];
                minHeap.Enqueue((newValue, cur.listIndex, cur.valueIndex + 1), newValue);
                maxValue = Math.Max(maxValue, newValue); // Update maxValue
            } else {
                break; // One list is exhausted
            }
        }

        output[0] = bestStart;
        output[1] = bestEnd;

        return output;
    }
}

/*

Time complexity: O(n * k * logk)
Space complexity: (k)

*/