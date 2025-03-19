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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if(head == null || left == right){
            return head;
        }

        ListNode dummy = new ListNode(0, head);
        ListNode leftPrev = dummy;

        // get position for reverse start
        for(int i = 1; i < left; i++){
            leftPrev = leftPrev.next;
        }

        // set next part in a separate variable
        ListNode leftPrevNext = leftPrev.next;
        ListNode prev = null;
        ListNode current = leftPrevNext;

        // perform the reversal from left till right
        for(int i = left; i <= right; i++){
            ListNode next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        // set position before reversal next to reversed list
        leftPrev.next = prev;

        // set the remaining part after the reversed list
        leftPrevNext.next = current;

        return dummy.next;
    }
}

