public class MKAverage{
	private readonly int m;
    private readonly int k;
    private readonly Queue<int> numbersQueue;
    private readonly List<int> sortedNumbers;
    private long totalSum;
    private long sumOfSmallestK;
    private long sumOfLargestK;

    public MKAverage(int m, int k){
        this.m = m;
        this.k = k;
        this.sortedNumbers = new List<int>();
        this.numbersQueue = new Queue<int>();
    }

    public void AddElement(int num){
        numbersQueue.Enqueue(num);

        if(sortedNumbers.Count < m){
            sortedNumbers.Add(num);

            if(sortedNumbers.Count == m){
                InitializeKSmallestAndLargestSum();
            }
        }
        else{
            InsertElement(num);
            DeleteElement();
        }

        totalSum += num;
    }

    public int CalculateMKAverage(){
        if(sortedNumbers.Count < m){
            return -1;
        }

        return (int)(totalSum - sumOfLargestK - sumOfSmallestK) / (m - 2 * k);
    }

    private void InitializeKSmallestAndLargestSum(){
        sortedNumbers.Sort();

        for(int i = 0; i < k; i++){
            sumOfSmallestK += sortedNumbers[i];
            sumOfLargestK += sortedNumbers[m - 1 - i];
        }
    }

    private void InsertElement(int num){
        int index = sortedNumbers.BinarySearch(num);

        if(index < 0){
            index = ~index;
        }

        sortedNumbers.Insert(index, num);

        if(index < k){
            sumOfSmallestK -= sortedNumbers[k];
            sumOfSmallestK += num;
        }

        if(index > m - k){
            sumOfLargestK -= sortedNumbers[m - k];
            sumOfLargestK += num;
        }
    }

    private void DeleteElement(){
        int num = numbersQueue.Dequeue();
        int index = sortedNumbers.BinarySearch(num);

        if(index < k){
            sumOfSmallestK += sortedNumbers[k];
            sumOfSmallestK -= num;
        }

        if(index > m - k){
            sumOfLargestK += sortedNumbers[m - k];
            sumOfLargestK -= num;
        }

        sortedNumbers.RemoveAt(index);
        totalSum -= num;
    }
}

/*
 
1. Initialize the `MKAverage` class with `m` and `k` values, where `m` is the number of elements to consider, and `k` is the number of smallest and largest elements to exclude.

2. Initialize data structures:
   - `numbersQueue`: A queue to store the incoming numbers.
   - `sortedNumbers`: A list to store the sorted numbers.

3. Initialize three variables:
   - `totalSum` to keep track of the sum of all elements.
   - `sumOfSmallestK` to keep track of the sum of the smallest `k` elements.
   - `sumOfLargestK` to keep track of the sum of the largest `k` elements.

4. Implement the `AddElement` method:
   - Enqueue the incoming number `num` into `numbersQueue`.
   - If the number of elements in `sortedNumbers` is less than `m`:
     - Append `num` to `sortedNumbers`.
     - If the count of elements in `sortedNumbers` becomes equal to `m`, call `InitializeKSmallestAndLargestSum()` to sort and initialize the sums.
   - If the number of elements in `sortedNumbers` is greater than `m`, call `InsertElement(num)` to insert `num` while maintaining the sorted order, and call `DeleteElement()` to remove the oldest element.

5. Implement the `InitializeKSmallestAndLargestSum` method:
   - Sort `sortedNumbers` in ascending order.
   - Calculate `sumOfSmallestK` and `sumOfLargestK` by summing the first `k` elements and the last `k` elements, respectively.

6. Implement the `InsertElement` method:
   - Use binary search to find the correct index for `num` in `sortedNumbers`.
   - Insert `num` at the determined index.
   - Update `sumOfSmallestK` and `sumOfLargestK` based on the newly inserted element.

7. Implement the `DeleteElement` method:
   - Dequeue the oldest element from `numbersQueue`.
   - Use binary search to find the index of the element in `sortedNumbers`.
   - Update `sumOfSmallestK` and `sumOfLargestK` based on the element being removed.
   - Remove the element from `sortedNumbers`.

8. Implement the `CalculateMKAverage` method:
   - If the number of elements in `sortedNumbers` is less than `m`, return `-1` as there are not enough elements.
   - Calculate the MK Average as `(totalSum - sumOfSmallestK - sumOfLargestK) / (m - 2 * k)`.
   - Return the calculated MK Average as an integer.

 */