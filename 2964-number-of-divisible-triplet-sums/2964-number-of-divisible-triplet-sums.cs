public class Solution {
    public int DivisibleTripletCount(int[] nums, int d) {
        int count = 0;
        Dictionary<int, int> map = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++){
            int complement = (d - nums[i] % d) % d;

            if(map.ContainsKey(complement)){
                count += map[complement];
            }

            for(int j = 0; j < i; j++){
                int lookVal = (nums[i] + nums[j]) % d;
                
                if(!map.ContainsKey(lookVal)){
                    map[lookVal] = 0;
                }

                map[lookVal]++;
            }
        }

        return count;
    }
}

/*

Time complexity: O(n^2)
Space complexity: O(n^2)

*/