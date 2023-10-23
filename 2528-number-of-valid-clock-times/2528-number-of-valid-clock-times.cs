public class Solution {
    public int CountTime(string time) {
        int count = 0;

        for(int h = 0; h < 24; h++){
            for(int m = 0; m < 60; m++){
                if((time[0] == '?' || time[0] - '0' == h / 10) 
                && (time[1] == '?' || time[1] - '0' == h % 10)
                && (time[3] == '?' || time[3] - '0' == m / 10)
                && (time[4] == '?' || time[4] - '0' == m % 10)){
                    count++;
                }
            }
        }

        return count;
    }
}