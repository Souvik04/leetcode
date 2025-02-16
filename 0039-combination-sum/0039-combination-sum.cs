public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> output = new List<IList<int>>();
        Backtrack(candidates, target, output, new List<int>(), 0);
        return output;
    }

    private void Backtrack(int[] candidates, int target, IList<IList<int>> output, List<int> temp, int pos){
        int sum = temp.Sum();

        if(sum > target){
            return;
        }
        else if(sum == target){
            output.Add(temp.ToList());
        }
        else{
            for(int i = pos; i < candidates.Length; i++){
                temp.Add(candidates[i]);
                Backtrack(candidates, target, output, temp, i);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}