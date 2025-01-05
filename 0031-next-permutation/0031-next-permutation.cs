public class Solution {
    public void NextPermutation(int[] nums) {
        int n = nums.Length;
        int firstDecreasing = -1;
        int smallestIncreasing = -1;

        // find first decreasing from back
        for(int i = n - 2; i >= 0; i--){
            if(nums[i] < nums[i + 1]){
                firstDecreasing = i;
                break;
            }
        }

        // if not decreasing found then reverse and return
        if(firstDecreasing == -1){
            Array.Reverse(nums);
            return;
        }

        // find smallest increasing after firstDecreasing
        for(int i = n - 1; i > firstDecreasing; i--){
            if(nums[i] > nums[firstDecreasing]){
                // swap them
                int temp = nums[i];
                nums[i] = nums[firstDecreasing];
                nums[firstDecreasing] = temp;
                break;
            }
        }

        // reverse from position next of firstDecreasing
        Array.Reverse(nums, firstDecreasing + 1, n - firstDecreasing - 1);
    }
}

/*

Intution:-

1. find the index (firstDecreasing) of first decreasing element from the last
2. find the index (smallestIncreasing) smallest increasing element from the firstDecreasing and swap them
3. reverse the elements after the position firstDecreasing

Time complexity: O(n)
Space complexity: O(1)

-------

Brute force:-

1. generate all permutations and store in list in sorted order
2. get the next permutation from the list after nums

Time complexity: O(n!)
Space complexity: O(n!)


*/