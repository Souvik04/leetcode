public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        IList<IList<int>> output = new List<IList<int>>();
        Array.Sort(candidates);
        Backtrack(candidates, target, output, new List<int>(), 0);

        return output;
    }

    private void Backtrack(int[] candidates, int target, IList<IList<int>> output, IList<int> temp, int pos){
        if(temp.Sum() == target){
            output.Add(temp.ToList());
        }
        else{
            for(int i = pos; i < candidates.Length; i++){
                if(i > pos && candidates[i] == candidates[i - 1]){
                    continue;
                }

                if(temp.Sum() + candidates[i] <= target){
                    temp.Add(candidates[i]);
                    Backtrack(candidates, target, output, temp, i + 1);
                    temp.RemoveAt(temp.Count - 1);                    
                }
            }
        }
    }
}