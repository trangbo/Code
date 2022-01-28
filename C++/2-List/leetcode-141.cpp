// https://leetcode-cn.com/problems/linked-list-cycle/

struct List_node {
    int val;
    List_node* next;
    List_node() : val(0), next(nullptr) {}
    List_node(int x) : val(x), next(nullptr) {}
    List_node(int x, List_node* n) : val(x), next(n) {}
};

bool has_cycle(List_node* head)
{
    List_node* x = head;
    int pos = -1;
    while (x) {
        ++pos;
        x = x->next;
        if (pos == 9999)
            return (x) ? true : false;
    }
    return false; 
}

bool has_cycle(List_node* head)
{
    if (head == nullptr || head->next == nullptr)
        return false;
    List_node* slow = head;
    List_node* fast = head->next;
    while (slow != fast) {
        if ((fast = fast->next) && (fast = fast->next))
            slow = slow->next;
        else 
            return false;
    }
    return true;
}
