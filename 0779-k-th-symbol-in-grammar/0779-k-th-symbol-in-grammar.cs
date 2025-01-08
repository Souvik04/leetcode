public class Solution {
    public int KthGrammar(int n, int k) {
        return GetKthVal(n, k);
    }

    private int GetKthVal(int n, int k){
        if(n == 1){
            return 0;
        }

        int lastRowCount = (int)Math.Pow(2, n -1);
        int mid = lastRowCount / 2;

        if(k > mid){
            return 1 - GetKthVal(n, k - mid);
        }
        
        return GetKthVal(n - 1, k);
    }
}

/*

   0
   01
  0110
01101001

1. each row has a prefix of prev row
2. each row when divided is a mirror or each other
3. so at nth row, kth element with be equal to its mirrored half
4. calculate recursively by reducing n and k based on where k lies

Time complexity: O(n)
Space complexity: O(n)

*/