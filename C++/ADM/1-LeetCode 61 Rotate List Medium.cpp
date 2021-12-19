//using namespace std;

struct ListNode {
    int val;
    ListNode* next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode* n) : val(x), next(n) {}
};

struct Solution {
    ListNode* rotateRight(ListNode* head, int k) {
        if (k == 0 || head == nullptr || head->next == nullptr) 
            return head;

        int length = 1;
        auto tail = head;
        while (tail->next != nullptr) {
            tail = tail->next;
            ++length;
        }

        int cutTimes = length - k % length;
        if (cutTimes == length) 
            return head;

        tail->next = head;
        while (cutTimes--) 
            tail = tail->next;
           
        head = tail->next;
        tail->next = nullptr;
        return head;
    }
};
