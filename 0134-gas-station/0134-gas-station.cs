public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int startingStation = 0;
        int currentTank = 0;
        int totalGas = 0;
        int totalCost = 0;

        for(int i = 0; i < cost.Length; i++){
            totalGas += gas[i];
            totalCost += cost[i];
            currentTank += gas[i] - cost[i];

            if(currentTank < 0){
                startingStation = i + 1;
                currentTank = 0;
            }
        }

        return totalGas < totalCost ? -1 : startingStation;
    }
}

/*

gas = [1,2,3,4,5], cost = [3,4,5,1,2]

1-3=-2
2-4=-2
3-5=-2
4-1=3
5-2=3

*move from i to i + 1 if gas sufficient
*if tank empties, discard the station and move to next station
*value of last position determines if we can move to first position

----

1. initialize variables- startingStation = 0, totalGas = 0, totalCost = 0, currentTank = 0
2. iterate over input 0 to n - 1
3. set totalGas += gas[i], totalCost += cost[i], currentTank += gas[i] - cost[i]
4. if currentTank < 0, reset- startingStation = i + 1, currentTank = 0
5. return totalGas < totalCost ? -1 : startingStation

----

Time complexity: O(n)
Space complexity: O(1)

*/