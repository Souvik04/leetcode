public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize != 0){
            return false;
        }

        Dictionary<int, int> freqMap = new Dictionary<int, int>();

        foreach(int h in hand){
            if(!freqMap.ContainsKey(h)){
                freqMap.Add(h, 0);
            }

            freqMap[h]++;
        }

        foreach(int currentCard in hand){
            int startSequence = currentCard;

            while(freqMap.GetValueOrDefault(startSequence) > 0){
                startSequence--;
            }

            while(startSequence <= currentCard){
                while(freqMap.GetValueOrDefault(startSequence) > 0){
                    for(int sequence = startSequence; sequence < startSequence + groupSize; sequence++){
                        if(freqMap.GetValueOrDefault(sequence) == 0){
                            return false;
                        }

                        freqMap[sequence]--;
                    }
                }

                startSequence++;
            }
        }

        return true;
    }
}

/*

Approach 1: using sorted map (not optimal)

1. edge case: check if hand.length % groupSize != 0 return false
2. initialize a sorted map <int, int> to store frequencies
3. iterate over the input and store the value and update frequencies
4. while map.count > 0
    - pick smallest card: currentCard from map: map.first().key
    - iterate from 0 to groupSize
        - check if map doesn't containskey (currentCard + i)), return false
        - decrement map[currentCard + i]
        - if map[currentCard + i] == 0 remove the card
5. return true at end

----

Time complexity: O(nlogn + n * k)
Space complexity: O(n)

--------

public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if(hand.Length % groupSize != 0){
            return false;
        }

        SortedDictionary<int, int> freqMap = new SortedDictionary<int, int>();

        foreach(int h in hand){
            if(!freqMap.ContainsKey(h)){
                freqMap.Add(h, 0);
            }

            freqMap[h]++;
        }

        while(freqMap.Count > 0){
            int currentCard = freqMap.First().Key;

            for(int i = 0; i < groupSize; i++){
                if(!freqMap.ContainsKey(currentCard + i)){
                    return false;
                }

                freqMap[currentCard + i]--;

                if(freqMap[currentCard + i] == 0){
                    freqMap.Remove(currentCard + i);
                }
            }
        }

        return true;
    }
}

-----------------------------------

Approach 2: Reverse decrement (most optimal)

1. edge case: check if hand.length % groupSize != 0 return false
2. initialize a sorted map <int, int> to store frequencies
3. iterate over the input and store the value and update frequencies
4. iterate over hand
    - pick currentCard and keep decrementing it and checking in the map to get the startSequence
    - while startSequence <= currentCard
        - while map contains startSequence and frequency > 0
            - iterate over sequence = startSequence to startSequence + groupSize
            - check if map contain sequence and frquency == 0, return false
            - decrement the sequence from map
        - increment startSequence by 1
5. return true at end

----

Time complexity: O(n)
Space complexity: O(n)

*/