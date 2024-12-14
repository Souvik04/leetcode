public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        int minCapacity = 0;
        int maxCapacity = 0;

        foreach(int w in weights){
            minCapacity = Math.Max(minCapacity, w);
            maxCapacity += w;
        }

        while(minCapacity < maxCapacity){
            int mid = minCapacity + (maxCapacity - minCapacity) / 2;

            if(CanShip(mid, weights, days)){
                maxCapacity = mid;
            }
            else{
                minCapacity = mid + 1;
            }
        }

        return minCapacity;
    }

    private bool CanShip(int capacity, int[] weights, int days){
        int sum = 0;

        foreach(int w in weights){
            if(w + sum > capacity){
                days--;
                sum = w;
            }
            else{
                sum += w;
            }

            if(days <= 0){
                return false;
            }
        }

        return true;
    }
}