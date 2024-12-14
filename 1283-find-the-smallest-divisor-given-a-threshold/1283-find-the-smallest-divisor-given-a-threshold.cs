public class Solution {
    public int SmallestDivisor(int[] nums, int threshold) {
        int output = 0;
        int min = 1;
        int max = nums.Max();

        while(min <= max){
            int mid = min + (max - min) / 2;

            if(GetSum(nums, mid) <= threshold){
                output = mid;
                max = mid - 1;
            }
            else{
                min = mid + 1;
            }
        }

        return output;
    }

    private int GetSum(int[] nums, int divisor){
        int sum = 0;

        foreach(int n in nums){
            sum += Convert.ToInt32(Math.Ceiling(((double)n / divisor)));
        }

        return sum;
    }
}