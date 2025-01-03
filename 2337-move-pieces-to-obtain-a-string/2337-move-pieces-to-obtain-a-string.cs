public class Solution {
    public bool CanChange(string start, string target) {
        int left = 0;
        int right = 0;
        int n = start.Length;

        while(left < n && right < n){
            while(left < n && start[left] == '_'){
                left++;
            }

            while(right < n && target[right] == '_'){
                right++;
            }
            
            if(left >= n && right >= n){
                return true;
            }

            if(left >= n || right >= n){
                break;
            }

            if(target[right] == 'R' && left >= right){
                return false;
            }

            if(target[right] == 'L' && left <= right){
                return false;
            } 

            left++;
            right++;
        }

        while(left < n && start[left] == '_'){
            left++;
        }

        while(right < n && target[right] == '_'){
            right++;
        }        

        return left == right;
    }
}

/*

Time complexity: O(n)
Space complexity: O(1)

*/