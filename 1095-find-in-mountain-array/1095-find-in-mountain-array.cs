/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        int n = mountainArr.Length();
        
        // find peak
        int peakIndex = FindPeak(mountainArr, n);
        
        // search in the increasing part first to get min index
        int index = BinarySearch(mountainArr, target, 0, peakIndex, true);
        
        if(index != -1){
            return index;
        }
        
        // search in the decreasing part next if previous search did not work
        return BinarySearch(mountainArr, target, peakIndex + 1, n - 1, false);
    }
    
    private int FindPeak(MountainArray mountainArr, int n){
        int left = 0;
        int right = n;
        
        while(left <= right){
            int mid = left + (right - left) / 2;
            
            if(mid > 0 && mountainArr.Get(mid) < mountainArr.Get(mid - 1)){
                right = mid - 1;
            }
            else if(mid < n - 1 && mountainArr.Get(mid) < mountainArr.Get(mid + 1)){
                left = mid + 1;
            }
            else{
                return mid;
            }
        }
        
        return - 1;
    }
    
    private int BinarySearch(MountainArray mountainArr, int target, int left, int right, bool ascending){
        
        while(left <= right){
            int mid = left + (right - left) / 2;
            int midVal = mountainArr.Get(mid);
            
            if(target == midVal){
                return mid;
            }
            
            if(ascending){
                if(midVal < target){
                    left = mid + 1;
                }
                else{
                    right = mid - 1;
                }
            }
            else{
                if(midVal > target){
                    left = mid + 1;
                }
                else{
                    right = mid - 1;
                }
            }
        }
        
        return - 1;
    }
}