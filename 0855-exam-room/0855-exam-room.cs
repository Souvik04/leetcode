public class ExamRoom {
    SortedSet<int> occupiedSeats = null;
    int lastSeat;
    public ExamRoom(int n) {
        occupiedSeats = new SortedSet<int>();
        lastSeat = n - 1;
    }
    
    public int Seat() {
        int assignedSeat = 0;
        int prevSeat = -1;
        int maxDistance = 0;

        foreach(int current in occupiedSeats){
            if(prevSeat == -1){
                assignedSeat = 0;
                maxDistance = current;
            }
            else{
                int distance = (current - prevSeat) / 2;

                if(distance > maxDistance){
                    maxDistance = distance;
                    assignedSeat = prevSeat + distance;
                }
            }

            prevSeat = current;            
        }

        // Check distance from the last occupied seat to the end of the row
        if(prevSeat != -1 && lastSeat - prevSeat > maxDistance){
            assignedSeat = lastSeat;
        }

        occupiedSeats.Add(assignedSeat);
        return assignedSeat;
    }
    
    public void Leave(int p) {
        occupiedSeats.Remove(p);
    }
}

/**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(n);
 * int param_1 = obj.Seat();
 * obj.Leave(p);
 */