// https://leetcode-cn.com/problems/linked-list-cycle-ii/

struct List_node {
    int val;
    List_node* next;
    List_node() : val(0), next(nullptr) {}
    List_node(int x) : val(x), next(nullptr) {}
    List_node(int x, List_node* n) : val(x), next(n) {}
};

List_node* detect_cycle(List_node* head) 
{
    if (head == nullptr || head->next == nullptr)
        return nullptr;
    List_node* slow = head;
    List_node* fast = head;
    do {
        if ((fast = fast->next) && (fast = fast->next))
            slow = slow->next;
        else
            return nullptr;
    } while (slow != fast);
    for (slow = head; slow != fast; slow = slow->next, fast = fast->next);
    return slow;
}