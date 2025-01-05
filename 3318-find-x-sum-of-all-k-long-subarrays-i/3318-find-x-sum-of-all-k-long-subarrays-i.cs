public class Solution {
    public int[] FindXSum(int[] nums, int k, int x) {
        int n = nums.Length;
        List<int> output = new List<int>();
        Dictionary<int, int> freqMap = new Dictionary<int, int>();

        // get x sum of first k subarray
        for(int i = 0; i < k; i++){
            if(!freqMap.ContainsKey(nums[i])){
                freqMap[nums[i]] = 0;
            }

            freqMap[nums[i]]++;
        }

        output.Add(GetXSum(freqMap, x));

        // slide window and find other k subarray till end
        for(int i = 1; i <= n - k; i++){
            int leftNum = nums[i - 1];

            // update freq and remove elements from left
            if(freqMap[leftNum] == 1){
                freqMap.Remove(leftNum);
            }
            else{
                freqMap[leftNum]--;
            }

            int rightNum = nums[i + k - 1];

            if(!freqMap.ContainsKey(rightNum)){
                freqMap[rightNum] = 0;
            }

            freqMap[rightNum]++;

            // get x sum for current k subarray
            output.Add(GetXSum(freqMap, x));
        }

        return output.ToArray();
    }

    private int GetXSum(Dictionary<int, int> freqMap, int x){
        var topX = freqMap.OrderByDescending(n => n.Value).ThenByDescending(n => n.Key).Take(x);
        return topX.Sum(x => x.Key * x.Value);
    }
}

/*

Time complexity: O(n * klogk)
Space complexity: O(n)

*/