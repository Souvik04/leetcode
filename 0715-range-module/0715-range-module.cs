public class RangeModule{
    private SortedDictionary<int, int> ranges;

    public RangeModule(){
        ranges = new SortedDictionary<int, int>();
    }

    public void AddRange(int left, int right){
        int mergedLeft = left;
        int mergedRight = right;

        List<int> toRemove = new List<int>();

        // iterate over all stored ranges
        foreach (var entry in ranges.Where(entry => entry.Value >= left)){
            // 5 10 .. 1 3
            if (entry.Key > right){
                break;
            }
            
            // 2 10 .. 5 7
            if (entry.Key < left){
                mergedLeft = entry.Key;
            }

            // 4 5 .. 1 2   
            if (entry.Value > right){
                mergedRight = entry.Value;
            }

            toRemove.Add(entry.Key);
        }

        // iterate over removals and remove from ranges
        foreach (var key in toRemove){
            ranges.Remove(key);
        }

        ranges[mergedLeft] = mergedRight;
    }

    public void RemoveRange(int left, int right){
        // Mark the portion of ranges that intersects with [left, right) as inactive
        List<int> toRemove = new List<int>();
        // iterate over stored ranges
        foreach (var range in ranges){
            // 5 10 .. 1 4
            if (range.Key >= right){
                break;
            }
                
            // 4 10 .. 9 11
            if (range.Value > left){
                toRemove.Add(range.Key);
            }
        }

        // iterate over removals and remove from ranges
        foreach (var key in toRemove){
            var value = ranges[key];
            ranges.Remove(key);
            
            // if prev left (key) was less than incoming left 
            // then range updates to key:left
            if (key < left){
                ranges[key] = left;
            }
                
            // if prev right (value) is greater than incoming right
            // then range updates to right:value
            if (value > right){
                ranges[right] = value;
            }
        }
    }

    public bool QueryRange(int left, int right){
        var floorEntry = ranges.LastOrDefault(entry => entry.Key <= left);
        return floorEntry.Value >= right;
    }
}

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.AddRange(left,right);
 * bool param_2 = obj.QueryRange(left,right);
 * obj.RemoveRange(left,right);

 -----------

 /*

### Initialization
1. Initialize an empty data structure to store ranges (e.g., a `SortedDictionary`).

### Adding a Range (`AddRange` Method)
1. Start with the given left and right values.
2. Iterate through the existing ranges:
   - If an existing range's right boundary is less than the given left, continue to the next range.
   - If an existing range's left boundary is greater than the given right, break the loop.
   - If the existing range overlaps with the given range, merge the ranges by updating the left and right boundaries.
   - Mark the overlapping range for removal.
3. Remove the marked ranges.
4. Insert the merged range (left, right) into the data structure.

### Removing a Range (`RemoveRange` Method)
1. Iterate through the existing ranges:
   - If an existing range's right boundary is less than the given left, continue to the next range.
   - If an existing range's left boundary is greater than or equal to the given right, break the loop.
   - If the existing range partially or fully overlaps with the given range:
     - Mark the overlapping part for removal.
     - If the range's left boundary is less than the given left, update its right boundary to be the given left.
     - If the range's right boundary is greater than the given right, insert a new range with boundaries (given right, original right).
2. Remove the marked ranges.

### Querying a Range (`QueryRange` Method)
1. Find the closest lower or equal key to the given left using a method like `LastOrDefault` in the data structure.
2. Check if the value associated with that key (right boundary) is greater than or equal to the given right.
3. If step 2 is true, the queried range is fully covered, and you return `true`; otherwise, return `false`.
 */