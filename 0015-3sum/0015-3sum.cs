public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> output = new List<IList<int>>();
        Array.Sort(nums);

        for(int i = 0; i < nums.Length - 2; i++){
            if(i > 0 && nums[i] == nums[i - 1]){
                continue;
            }

            int left = i + 1;
            int right = nums.Length - 1;

            while(left < right){
                int sum = nums[i] + nums[left] + nums[right];

                if(sum == 0){
                    output.Add(new List<int>{nums[i], nums[left], nums[right]});

                    while(left < right && nums[left] == nums[left + 1]){
                        left++;
                    }

                    while(left < right && nums[right] == nums[right - 1]){
                        right--;
                    }

                    left++;
                    right--;          
                }
                else if(sum < 0){
                    left++;
                }
                else{
                    right--;
                }
            }            
        }

        return output;
    }
}

/*

1. sort the input nums
2. iterate i over nums from 0 to n - 2 skip if nums[i] == nums[i - 1]
3. initialize 2 pointers left = i + 1 and right = n - 1
4. set sum = nums[i] + nums[left] + nums[right]
5. check if sum == 0 add the values to output
  - while nums[left] == nums[left + 1], left++
  - while nums[right] == nums[right - 1], right--
  - do left++ and right--;
6. else if sum sum < 0, left++ else right--
7. return output

Time complexity: O(n^2)
Space complexity: O(n)

*/