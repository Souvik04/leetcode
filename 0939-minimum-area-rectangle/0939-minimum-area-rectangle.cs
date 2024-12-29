public class Solution {
    public int MinAreaRect(int[][] points) {
        if(points.Length < 4){
            return 0;
        }

        int minArea = int.MaxValue;

        Dictionary<int, HashSet<int>> pointMap = new Dictionary<int, HashSet<int>>();

        foreach(int[] p in points){
            if(!pointMap.ContainsKey(p[0])){
                pointMap[p[0]] = new HashSet<int>();
            }

            pointMap[p[0]].Add(p[1]);
        }

        foreach(int[] p1 in points){
            foreach(int[] p2 in points){
                if(p1[0] == p2[0] || p1[1] == p2[1]){
                    continue;
                }

                // 1: 1,3
                // 3: 1,3
                // p1: 1,1 p2: 3,3
                if(pointMap[p1[0]].Contains(p2[0]) || pointMap[p2[0]].Contains(p1[0])){
                    if(pointMap[p1[0]].Contains(p2[1]) && pointMap[p2[0]].Contains(p1[1])){
                        int area = Math.Abs(p1[0] - p2[0]) * Math.Abs(p1[1] - p2[1]);
                        minArea = Math.Min(area, minArea);
                    }
                }
            }
        }

        return minArea == int.MaxValue ? 0 : minArea;
    }
}   

/*

1. Create a class named `Solution` to implement the solution for finding the minimum area of a rectangle.

2. Define a method `MinAreaRect` that takes a 2D array of points `points` as input and returns an integer 
representing the minimum area of a rectangle.

3. Check if the number of points in the input array is less than 4 (points.Length < 4). If there are fewer
 than 4 points, it is not possible to form a rectangle, so return 0.

4. Initialize a variable `minArea` with a maximum integer value (int.MaxValue). This variable will be used 
to keep track of the minimum area found during the iterations.

5. Create a dictionary named `pointMap`, where the keys are x-coordinates, and the values are sets of
 corresponding y-coordinates. This data structure is used to efficiently map x-coordinates to y-coordinates.

6. Iterate through each point `p` in the input `points` array.

7. For each point, check if the x-coordinate of the point `p[0]` exists as a key in the `pointMap`
 dictionary. If it doesn't exist, create a new entry with an empty set to store y-coordinates for
  that x-coordinate. Then, add the y-coordinate `p[1]` to the set associated with `p[0]`.

8. After processing all points, the `pointMap` dictionary will contain x-coordinates mapped to sets
 of y-coordinates.

9. Iterate through each point `p1` in the input `points` array using a nested loop.

10. For each pair of points `p1` and `p2`, check if they share the same x-coordinate `p1[0] == p2[0]`
 or the same y-coordinate `p1[1] == p2[1]`. If either of these conditions is met, skip to the next pair 
 of points.

11. If the x-coordinate of `p1` is different from the x-coordinate of `p2`, and the y-coordinate
 of `p1` is different from the y-coordinate of `p2`, it indicates that `p1` and `p2` are potential
  diagonal points of a rectangle.

12. Check if the `pointMap` contains `p1[0]` as a key and `p2[1]` as a value in the set, and also 
check if the `pointMap` contains `p2[0]` as a key and `p1[1]` as a value in the set. This means that 
there are two pairs of points with the same x-coordinates as p1 and p2 and the same y-coordinates 
as p1 and p2, respectively.

13. If these conditions are met, calculate the current area of the rectangle formed by `p1` and `p2`
 by taking the absolute difference between their x-coordinates and the absolute difference between 
 their y-coordinates, and multiply these differences to get the area.

14. Update the `minArea` with the minimum value between the current area and the current `minArea`.

15. After processing all pairs of points, the `minArea` will store the minimum area of a rectangle
 formed by the points, or it will still have its initial maximum value if no rectangle was found.

16. Check if `minArea` is still equal to its initial maximum value (int.MaxValue). If it is, 
it means no rectangle was found, and return 0 as the minimum area.

17. If `minArea` is not equal to its initial maximum value, return `minArea` as the minimum area
 of the rectangle.

*/