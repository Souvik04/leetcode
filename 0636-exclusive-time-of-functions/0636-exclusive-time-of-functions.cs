public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int[] output = new int[n];
        Stack<(int jobId, int startTime)> stack = new Stack<(int jobId, int startTime)>();

        foreach(string log in logs){
            string[] strArr = log.Split(":");
            int jobId = Convert.ToInt32(strArr[0]);
            bool isStart = strArr[1] == "start";
            int curTime = Convert.ToInt32(strArr[2]);            

            if(isStart){
                stack.Push((jobId, curTime));
            }
            else{
                var popped = stack.Pop();
                int duration = curTime - popped.startTime + 1;
                output[jobId] += duration;

                if(stack.Count > 0){
                    output[stack.Peek().jobId] -= duration;
                }
            }
        }

        return output;
    }
}

/*


0 1 2 3 4 5 6 7
0   0       0


e:7
e:6
s:6
e:5
s:2
s:0
*/