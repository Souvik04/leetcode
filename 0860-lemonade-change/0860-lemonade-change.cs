public class Solution {
    public bool LemonadeChange(int[] bills) {
        int fives = 0;
        int tens = 0;

        foreach(int bill in bills){
            if(bill == 5){
                fives++;
            }
            else if(bill == 10){
                tens++;
                
                if(fives <= 0){
                    return false;
                }

                fives--;
            }
            else if(bill == 20){
                if(tens > 0 && fives > 0){
                    tens--;
                    fives--;
                }
                else if(fives >= 3){
                    fives -= 3;
                }
                else{
                    return false;
                }
            }
        }

        return true;
    }
}