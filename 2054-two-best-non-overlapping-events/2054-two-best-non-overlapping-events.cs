public class Solution {
    public int MaxTwoEvents(int[][] events) {
        int maxSum = 0;
        Array.Sort(events, (a, b) => a[1].CompareTo(b[1]));
        int n = events.Length;

        // precomupte running max values for each point from start
        int[] maxValues = new int[n];
        maxValues[0] = events[0][2];

        for(int i = 1; i < n; i++){
            maxValues[i] = Math.Max(maxValues[i - 1], events[i][2]);
        }

        // find best pair comibination
        for(int i = 0; i < n; i++){
            int bestIndex = BinarySearch(events, i);
            int currentPairSum = events[i][2];
            
            if(bestIndex != -1){
                currentPairSum += maxValues[bestIndex];
            }
            
            maxSum = Math.Max(maxSum, currentPairSum);
        }

        return maxSum;
    }

    private int BinarySearch(int[][] events, int current){
        int left = 0;
        int right = current - 1;
        int bestIndex = -1;

        while(left <= right){
            int mid = left + (right - left) / 2;

            if(events[mid][1] < events[current][0]){
                bestIndex = mid;
                left = mid + 1;
            }
            else{
                right = mid - 1;
            }
        }

        return bestIndex;
    }
}

/*

Intution:

1. we select pairs which are non-overlapping to each other
2. once we get such pair, we calculate the sum of their values and update the maxSum
3. brute force- requires checking each pair to others
4. optimized- binary search from current event and find the last previous event ended before current event start which maximizes the value

steps:

1. sort the events by end time in ascending order
2. pre-compute running max values upto each index
    - declare an array maxValue of int to store max value from start to each point
    - iterate over the events and update the array: maxValue[i] = max(maxValue[i], events[i][2])
3. perform binary search to find the best compatible index
    - iterate over the events
    - perform binary search from current index
        - binary search condtion- events[mid][1] < events[current][0] ? left = mid + 1 : right = mid - 1
4. calculate the sum of the event pairs- current and best compatible one and update maxSum
5. return maxSum as output

Time complexity: O(nlogn)
Space complexity: O(n)

*/