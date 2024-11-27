public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        int maxUnits = 0;
        Array.Sort(boxTypes, (a, b) => b[1].CompareTo(a[1]));

        foreach(int[] box in boxTypes){
            int currentBoxCount = box[0];
            int currentUnitCount = box[1];

            int boxesToTake = Math.Min(currentBoxCount, truckSize);
            maxUnits += (boxesToTake * currentUnitCount);
            truckSize -= boxesToTake;
            
            if(truckSize == 0){
                break;
            }
        }

        return maxUnits;
    }
}