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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode output = new ListNode();
        ListNode pointer = output;

        while(list1 != null && list2 != null){
            int value = 0;
            if(list1.val > list2.val){
                value = list2.val;
                list2 = list2.next;
            }
            else{
                value = list1.val;
                list1 = list1.next;
            }
            
            pointer.next = new ListNode(value);
            pointer = pointer.next;
        }

        if(list1 != null){
            pointer.next = list1;
        }

        if(list2 != null){
            pointer.next = list2;
        }        

        return output.next;
    }
}