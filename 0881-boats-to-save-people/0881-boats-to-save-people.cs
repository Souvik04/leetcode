public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        int boats = 0;
        Array.Sort(people);
        int left = 0;
        int right = people.Length - 1;

        while(left <= right){
            boats++;
            if(people[left] + people[right] <= limit){
                left++;
            }

            right--;
        }

        return boats;
    }
}