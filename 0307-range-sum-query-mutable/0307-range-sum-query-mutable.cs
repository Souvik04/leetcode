public class NumArray {
    int[] tree = null;
    int[] nums = null;
    int n = 0;
    public NumArray(int[] nums) {
        n = nums.Length;
        this.tree = new int[n + 1];
        this.nums = new int[n];

        for(int i = 0; i < n; i++){
            Update(i, nums[i]);
        }
    }
    
    public void Update(int index, int val) {
        int delta = val - nums[index];
        nums[index] = val;
        int i = index + 1;

        while(i <= n){
            tree[i] += delta;
            i += i & -i;
        }
    }
    
    public int SumRange(int left, int right) {
        return GetPrefixSum(right + 1, tree) - GetPrefixSum(left, tree);
    }

    private int GetPrefixSum(int index, int[] tree){
        int sum = 0;
        
        while(index > 0){
            sum += tree[index];
            index -= index & -index;
        }

        return sum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */