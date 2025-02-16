public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0;
        int right = numbers.Length - 1;

        while(left < right){
            int sum = numbers[left] + numbers[right];

            if(sum == target){
                return new int[]{left + 1, right + 1};
            }
            else if(sum < target){
                left++;
            }
            else{
                right--;
            }
        }

        return new int[2];
    }
}

/*

1. initialize left = 0 and right = n - 1
2. perform binary search by setting sum = numbers[left] + numbers[right]
3. if sum == target, return output as {[left + 1], [right + 1]}
4. else move left or right towards the target based on sum value

Time complexity: O(logn)
Space complexity: O(1)

*/