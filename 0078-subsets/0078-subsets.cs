public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> output = new List<IList<int>>();
        Backtrack(output, nums, new Stack<int>(), 0);
        return output;
    }
    
    private void Backtrack(IList<IList<int>> output, int[] nums, Stack<int> temp, int start){
        //goal
        output.Add(temp.ToList());
        
        
        //choice
        for(int i = start; i < nums.Length; i++){
            if(temp.Contains(nums[i]))
                continue;
            temp.Push(nums[i]);
            Backtrack(output, nums, temp, i);
            temp.Pop();
        }
        
    }
}