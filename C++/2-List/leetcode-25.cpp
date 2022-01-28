// https://leetcode-cn.com/problems/reverse-nodes-in-k-group/

struct List_node {
    int val;
    List_node* next;
    List_node() : val(0), next(nullptr) {}
    List_node(int x) : val(x), next(nullptr) {}
    List_node(int x, List_node* n) : val(x), next(n) {}
};

List_node* reverse_k_group(List_node* head, int k) 
{
    if (head->next == nullptr || k == 1)
        return head;
    int n = 1;
    List_node* cur = head;
    List_node* guard_left = nullptr;
    while (cur->next) {
        ++n;
        cur = cur->next;
        if (n % k == 0) {
            if (n == k) {
                guard_left = reverse_sublist(guard_left, cur->next, head, cur);
                head = cur;
            }
            else
                guard_left = reverse_sublist(guard_left, cur->next, guard_left->next, cur);
            cur = guard_left;
        }
    }
    return head;
}

List_node* reverse_sublist(List_node* guard_left, List_node* guard_right, List_node* head, List_node* tail)
{
    List_node* temp_front = head;
    List_node* temp_back = nullptr;
    List_node* flag = head->next;
    if (guard_left)
        guard_left->next = tail;
    head->next = guard_right;
    while (flag != guard_right) {
        temp_back = flag;
        flag = flag->next;
        temp_back->next = temp_front;
        temp_front = temp_back;
    }
    return head;
}