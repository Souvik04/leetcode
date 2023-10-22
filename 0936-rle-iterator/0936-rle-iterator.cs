public class RLEIterator {
    int[] encoding;
    int index;

    public RLEIterator(int[] encoding) {
        this.encoding = encoding;
        index = 0;
    }
    
    public int Next(int n) {
        // keep reducing the n by current count value of the specific index
        // and increment i by 2
        while(index < encoding.Length && n > encoding[index]){
            n -= encoding[index];
            index += 2;
        }

        // index is reached to end return -1
        if(index >= encoding.Length){
            return -1;
        }

        // reduce the encoding count value by n and return the element at i + 1 position
        encoding[index] -= n;
        return encoding[index + 1];
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(encoding);
 * int param_1 = obj.Next(n);
 */