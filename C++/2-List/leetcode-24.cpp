// https://leetcode-cn.com/problems/swap-nodes-in-pairs/

struct List_node {
    int val;
    List_node* next;
    List_node() : val(0), next(nullptr) {}
    List_node(int x) : val(x), next(nullptr) {}
    List_node(int x, List_node* n) : val(x), next(n) {}
};

List_node* swap_pairs(List_node* head) 
{
    if (head == nullptr || head->next == nullptr)
        return head;
    List_node* n = head->next;
    head->next = swap_pairs(n->next);
    n->next = head;
    return n;
}

List_node* swap_pairs(List_node* head) 
{
    if (head == nullptr || head->next == nullptr)
        return head;
    List_node* x = head;
    List_node* y = head->next;
    head = head->next;
    x->next = y->next;
    y->next = x;
    List_node* t = x; 
    while (x->next && x->next->next) {
        x = x->next;
        y = x->next;
        t->next = y;
        x->next = y->next;
        y->next = x;
        t = x;
    }
    return head; 
}

