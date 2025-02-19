public class Solution {
    public int Trap(int[] height) {
        int sum = 0;
        int left = 0;
        int right = height.Length - 1;
        int leftMax = height[0];
        int rightMax = height[right];

        while(left < right){
            if(leftMax < rightMax){
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                sum += leftMax - height[left];
            }
            else{
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                sum += rightMax - height[right];
            }
        }

        return sum;
    }
}

/*

Approach 1: Two pass

1. initialize left[] and right[], set left[0] = height[0] and right[n - 1] = height[n - 1]
2. iterate over input heights from 1 to n - 1 and update left[]
    - left[i] = max(left[i - 1], height[i])
3. iterate over input heights from n - 2 to 0 and update right[]
    - right[i] = max(right[i + 1], height[i])
4. iterate over both from 0 to n - 1 and calculate output
    - output = min(left[i], right[i]) - height[i]

----

Time complexity: O(n)
Space complexity: O(n)

------------

public class Solution {
    public int Trap(int[] height) {
        int output = 0;
        int n = height.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        left[0] = height[0];
        right[n - 1] = height[n - 1];

        for(int i = 1; i < n; i++){
            left[i] = Math.Max(left[i - 1], height[i]);
        }

        for(int i = n - 2; i >= 0; i--){
            right[i] = Math.Max(right[i + 1], height[i]);
        }

        for(int i = 0; i < n; i++){
            output += Math.Min(left[i], right[i]) - height[i];
        }

        return output;
    }
}

------------------------

Approach 2: One pass

1. initialize left = 0, right = n - 1, leftMax = height[left], rightMax = height[right]
2. you 2 pointer- while left < right
    - if leftMax < rightMax
        - left++
        - leftMax = max(leftMax, height[left])
        - sum += leftMax - height[left]
    - else
        - right--
        - rightMax = max(rightMax, height[right])
        - sum += rightMax - height[right]
3. return sum

----

Time complexity: O(n)
Space complexity: O(1)

*/