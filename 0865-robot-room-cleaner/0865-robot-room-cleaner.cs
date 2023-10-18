/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */

class Solution {
    HashSet<(int, int)> visited = new HashSet<(int, int)>();
    public void CleanRoom(Robot robot) {
        Backtrack(0, 0, 0, robot);
    }

    private void Backtrack(int r, int c, int d, Robot robot){
        visited.Add(new (r, c));
        robot.Clean();

        int[][] roomDirs = new int[4][]{new int[]{-1, 0}, new int[]{0, 1}, new int[]{1, 0}, new int[]{0, -1}};

        // clockwise directions
        for(int i = 0; i < 4; i++){
            int newD = (d + i) % 4;
            int newR = r + roomDirs[newD][0];
            int newC = c + roomDirs[newD][1];

            if(!visited.Contains(new (newR, newC)) && robot.Move()){
                Backtrack(newR, newC, newD, robot);
                GoBack(robot);
            }

            robot.TurnRight();
        }
    }

    private void GoBack(Robot robot){
        robot.TurnRight();
        robot.TurnRight();
        robot.Move();
        robot.TurnLeft();
        robot.TurnLeft();
    }
}

/*

1. Define a class named `Solution` and declare a HashSet named `visited` to keep track of visited cells.

2. Create a method `CleanRoom` that takes a `Robot` as an argument to control the cleaning process. This method will be the entry point for cleaning the entire room.

3. Inside the `CleanRoom` method, call the `Backtrack` method with the initial position (0, 0), initial direction (0), and the robot instance.

4. Define the `Backtrack` method, which recursively explores and cleans the room. It takes the parameters `r` (current row), `c` (current column), `d` (current direction), and the robot.

5. Add the current cell (r, c) to the `visited` set to mark it as visited.

6. Use the robot to clean the current cell by calling `robot.Clean()`.

7. Create a 2D array `roomDirs` to represent four possible directions: up, right, down, and left.

8. Start a loop to explore the adjacent cells in clockwise order, as the robot's direction changes with each iteration. Loop from `i = 0` to `i < 4`.

9. Calculate the new direction `newD` by taking the current direction `d`, adding `i`, and taking the remainder when divided by 4 to ensure it wraps around.

10. Calculate the new row `newR` and new column `newC` based on the new direction. Update `newR` and `newC` according to the corresponding values in the `roomDirs` array.

11. Check if the new cell (newR, newC) has not been visited by looking it up in the `visited` set, and if the robot can move to that cell by calling `robot.Move()`.

12. If the conditions in step 11 are met, call the `Backtrack` method recursively with the new cell coordinates (newR, newC), the new direction `newD`, and the robot.

13. After backtracking from the recursive call, make the robot go back to the previous cell by calling the `GoBack` method.

14. Rotate the robot 90 degrees clockwise by calling `robot.TurnRight()` to prepare for exploring the next direction.

15. Once the loop finishes, the robot will have explored all directions and returned to the original cell.

16. Define the `GoBack` method, which instructs the robot to turn around and move back to the previous cell. This method is used after cleaning a cell and ensures that the robot returns to the previous position correctly.

17. Call `robot.TurnRight()` twice to make a 180-degree turn (facing the opposite direction).

18. Call `robot.Move()` to move the robot back to the previous cell.

19. Call `robot.TurnLeft()` twice to rotate the robot back to its original direction.

*/