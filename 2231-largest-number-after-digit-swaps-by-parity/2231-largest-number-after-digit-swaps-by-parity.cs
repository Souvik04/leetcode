public class Solution {
    public int LargestInteger(int num) {
        char[] digits = num.ToString().ToCharArray();
        List<int> evens = new List<int>();
        List<int> odds = new List<int>();

        foreach(char c in digits){
            int cur = c - '0';

            if(cur % 2 == 0){
                evens.Add(cur);
            }
            else{
                odds.Add(cur);
            }
        }

        evens.Sort((a, b) => b.CompareTo(a));
        odds.Sort((a, b) => b.CompareTo(a));

        int evenIndex = 0;
        int oddIndex = 0;

        for(int i = 0; i < digits.Length; i++){
            int cur = digits[i] - '0';

            if(cur % 2 == 0){
                digits[i] = (char)(evens[evenIndex++] + '0');
            }
            else{
                digits[i] = (char)(odds[oddIndex++] + '0');
            }
        }

        return int.Parse(new string(digits));
    }
}

/*

1. convert the given input number to char array digits
2. create 2 lists to store even and odd numbers
3. iterate over the char array and put the digits in even and odd lists respectively
4. sort the even and odd array in descending order
5. initialize 2 pointers for even and odd and iterate over the main char array
6. for each char take the even or odd element based on the current digit and update the digits array
7. increment even and odd indices accordingly
8. convert the output to string and then to int and return as output

*/