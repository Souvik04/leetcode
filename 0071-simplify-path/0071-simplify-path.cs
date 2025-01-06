public class Solution {
    public string SimplifyPath(string path) {
        Stack<string> stack = new Stack<string>();
        List<string> output = new List<string>();
        string[] strArr = path.Split("/");

        foreach(string p in strArr){
            if(string.IsNullOrEmpty(p) || p == "."){
                continue;
            }

            if(p == ".."){
                if(stack.Count > 0){
                    stack.Pop();
                }
            }
            else{
                stack.Push(p);
            }
        }

        while(stack.Count > 0){
            output.Add(stack.Pop());
        }

        output.Reverse();

        return "/" + string.Join("/", output);
    }
}

/*

Time complexity: O(n)
Space complexity: O(n)

*/