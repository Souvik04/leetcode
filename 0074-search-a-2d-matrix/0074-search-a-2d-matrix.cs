public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length;

        if(m == 0){
            return false;
        }

        int n = matrix[0].Length;        

        int left = 0;
        int right = m * n - 1;

        while(left <= right){
            int mid = left + (right - left) / 2;
            int midVal = matrix[mid / n][mid % n];

            if(target > midVal){
                left = mid + 1;
            }
            else if(target < midVal){
                right = mid - 1;
            }
            else{
                return true;
            }
        }

        return false;
    }
}