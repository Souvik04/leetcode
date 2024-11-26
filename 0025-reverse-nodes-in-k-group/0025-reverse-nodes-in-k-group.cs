/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        if (head == null || k <= 1) return head;

        ListNode dummy = new ListNode(0, head);
        ListNode groupStartPrev = dummy;

        while (true) {
            // Find the kth node from groupStartPrev
            ListNode kthNode = FindKthNode(groupStartPrev, k);
            if (kthNode == null) break;

            ListNode groupEndNext = kthNode.next;

            // Reverse the current group of k nodes
            ReverseGroup(groupStartPrev.next, groupEndNext);

            // Update pointers for the next group
            ListNode groupStart = groupStartPrev.next;
            groupStartPrev.next = kthNode;
            groupStart.next = groupEndNext;
            groupStartPrev = groupStart;
        }

        return dummy.next;
    }

    private ListNode FindKthNode(ListNode start, int k) {
        while (start != null && k > 0) {
            start = start.next;
            k--;
        }
        return start;
    }

    private void ReverseGroup(ListNode start, ListNode end) {
        ListNode prev = end, curr = start;

        while (curr != end) {
            ListNode nextNode = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextNode;
        }
    }
}
