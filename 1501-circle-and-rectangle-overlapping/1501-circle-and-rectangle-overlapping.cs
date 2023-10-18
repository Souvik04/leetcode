public class Solution {
    public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2) {
        int closestX = Math.Max(x1, Math.Min(xCenter, x2));
        int closestY = Math.Max(y1, Math.Min(yCenter, y2));
        int eucDistance = (xCenter - closestX) * (xCenter - closestX) + (yCenter - closestY) * (yCenter - closestY);
        radius = radius * radius;

        return eucDistance <= radius;
    }
}

/*

1. get the closest point of the rectangle to the circle
    - closestX = max(x1, min(xCenter, x2))
    - closestY = max(y1, min(yCenter, y2))
2. calculate euclidian distance between the center and the closet point
    - distance = (xCenter - closestX) * (xCenter - closestX) - (yCenter - closestY) * (yCenter - closestY)
3. if distance <= radius, return true, else false
*/