public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1;
        int right = piles.Max();
        int speed = right; // start with max speed
        
        while(left <= right){
            // let k be speed
            int k = left + (right - left) / 2;
            long hours = 0;

            foreach(int p in piles){
                // time = number of banana / speed
                hours += (int)Math.Ceiling(p / (double)k);
            }

            if(hours <= h){
                // try a slower speed
                speed = Math.Min(k, speed);
                right = k - 1;
            }
            else{
                // try a higher speed
                left = k + 1;
            }
        }

        return speed;
    }
}

/*

Time complexity: O(nlogn)
Space complexity: O(1)

*/