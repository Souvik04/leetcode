public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1;
        int right = piles.Max();

        while(left < right){
            int mid = left + (right - left) / 2;

            if(GetSpeed(mid, piles) <= h){
                right = mid;
            }
            else{
                left = mid + 1;
            }
        }

        return left;
    }

    private int GetSpeed(int k, int[] piles){
        int speed = 0;

        foreach(int pile in piles){
            speed += (int)Math.Ceiling((double)pile/k);
        }
        return speed;
    }
}

/*

1. perform binary search from 1 to max(piles)
2. for each mid (k), calculate speed if Koko can finish within h hours
3. move left (mid = right), if speed <= h, else move right (left = mid + 1)
4. use a calculateSpeed(int k) function to calculate the speed
    - iterate over each piles
    - speed += ceil(pile / k)
    - return speed <= h

*/