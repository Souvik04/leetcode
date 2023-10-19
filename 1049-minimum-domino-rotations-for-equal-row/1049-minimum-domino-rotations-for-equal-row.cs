public class Solution {
    public int MinDominoRotations(int[] tops, int[] bottoms) {
        int n = tops.Length;
        int[] tCount = new int[7];
        int[] bCount = new int[7];
        int[] sameCount = new int[7];

        for (int i = 0; i < n; i++) {
            tCount[tops[i]]++;
            bCount[bottoms[i]]++;
            if (tops[i] == bottoms[i]) {
                sameCount[tops[i]]++;
            }
        }

        for (int i = 1; i <= 6; i++) {
            if (tCount[i] + bCount[i] - sameCount[i] == n) {
                return n - Math.Max(tCount[i], bCount[i]);
            }
        }

        return -1;
    }
}


/*

2 1 2 4 2 2
5 2 6 2 3 2

2 2 2 2 1 4
5 6 3  2 2

*/