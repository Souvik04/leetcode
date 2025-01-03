public class Solution {
    public long ContinuousSubarrays(int[] nums) {
        int count = 0;
        SortedDictionary<int, int> freqMap = new SortedDictionary<int, int>();
        int left = 0;
        int right = 0;

        while(right < nums.Length){
            if(!freqMap.ContainsKey(nums[right])){
                freqMap.Add(nums[right], 0);
            }

            freqMap[nums[right]]++;

            while(freqMap.Count > 0 && freqMap.Keys.Max() - freqMap.Keys.Min() > 2){
                freqMap[nums[left]]--;

                if(freqMap[nums[left]] == 0){
                    freqMap.Remove(nums[left]);
                }

                left++;
            }

            count += right - left + 1;
            right++;
        }

        return count;
    }
}

/*

1. initialize count, left, right to 0 and a SortedDictionary<int, int> to store nums values and freq
2. iterate over while loop: right < n
3. add nums[right] to freqMap and update the freq
4. check, while lfreqMpa count > 0 && freMap.Max - freqMap.Min > 2, remove from left
5. perform freqMap[nums[left]]-- till freq is > 0 and then remove the item from map and increment left
6. update count += right - left + 1 and increment right
7. return count as output

Time complexity: O(nlogn)
Space complexity: O(n)

*/