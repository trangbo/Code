// https://leetcode-cn.com/problems/reverse-linked-list/

struct List_node {
    int val;
    List_node* next;
    List_node() : val(0), next(nullptr) {}
    List_node(int x) : val(x), next(nullptr) {}
    List_node(int x, List_node* n) : val(x), next(n) {}
};

List_node* reverseList(List_node* head) 
{
    if (head == nullptr || head->next == nullptr)
        return head;
    List_node* new_head = reverseList(head->next);
    head->next->next = head;
    head->next = nullptr;
    return new_head;
}

List_node* reverseList(List_node* head) 
{
    if (head == nullptr || head->next == nullptr)
        return head;
    List_node* curr = nullptr;
    List_node* flag = head->next;
    head->next = nullptr;
    while (flag) {
        curr = flag;
        flag = flag->next;
        curr->next = head;
        head = curr;
    }
    return head;
}
