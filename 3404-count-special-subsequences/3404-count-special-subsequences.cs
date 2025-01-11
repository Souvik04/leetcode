public class Solution {
    public long NumberOfSubsequences(int[] nums) {
        long count = 0;
        Dictionary<double, double> map = new Dictionary<double, double>();

        for(int r = 4; r < nums.Length; r++){
            for(int p = 0, q = r - 2; p < q - 1; p++){
                double key = (double)nums[p] / nums[q];
                
                if(!map.ContainsKey(key)){
                    map[key] = 0;
                }

                map[key]++;
            }

            for(int s = r + 2; s < nums.Length; s++){
                double key = (double)nums[s] / nums[r];
                
                if(map.ContainsKey(key)){
                    count += (long)map[key];
                }
            }
        }

        return count;
    }
}

/*

p q r s

p * r == q * s

p/q == s/r

*/
