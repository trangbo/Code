// https://leetcode-cn.com/problems/merge-two-sorted-lists/

struct List_node {
    int val;
    List_node* next;
    List_node() : val(0), next(nullptr) {}
    List_node(int x) : val(x), next(nullptr) {}
    List_node(int x, List_node* n) : val(x), next(n) {}
};

List_node* merge_two_lists(List_node* list1, List_node* list2) 
{
    List_node dummy;
    List_node* temp = &dummy;
    while (list1 && list2) {
        if (list1->val <= list2->val) {
            temp->next = list1;
            list1 = list1->next;
        }
        else {
            temp->next = list2;
            list2 = list2->next;
        }
        temp = temp->next;
    }
    temp->next = list1 ? list1 : list2;
    return dummy.next;
}