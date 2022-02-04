// https://leetcode-cn.com/problems/design-circular-deque

#include<vector>

class MyCircularDeque {
private:
    std::vector<int> buffer;
    int size;
    int capacity;
    int front;
    int rear;
public:
    MyCircularDeque(int k) : buffer(k, 0), size(0), capacity(k), front(k - 1), rear(0) {}

    bool insertFront(int value) {
        if (size == capacity)
            return false;
        buffer[front] = value;
        front = (front - 1 + capacity) % capacity;
        ++size;
        return value;
    }

    bool insertLast(int value) {
        if (size ==  capacity)
            return false;
        buffer[rear] = value;
        rear = (rear + 1) % capacity;
        ++size;
        return true;
    }

    bool deleteFront() {
        if (size == 0)
            return false;
        front = (front + 1) % capacity;
        --size;
        return true;
    }

    bool deleteLast() {
        if (size == 0)
            return false;
        rear = (rear - 1 + capacity) % capacity;
        --size;
        return true;
    }

    int getFront() {
        if (size == 0)
            return false;
        return buffer[(front + 1) % capacity];
    }

    int getRear() {
        if (size == 0)
            return -1;
        return buffer[(rear - 1 + capacity) % capacity];
    }

    bool isEmpty() {
        return size == 0;
    }

    bool isFull() {
        return size == capacity;
    }
};

class MyCircularDeque {
public:
    MyCircularDeque(int k) {
        front_ = new Node(-1, nullptr, back_);
        back_ =  new Node(-1, front_, nullptr);
        capacity_ = k;
        size_ = 0;
    }
    
    bool insertFront(int value) {
        if (size_ < capacity_) {
            if (front_->val == -1)
                front_->val = value;
            else {
                dummy_ = new Node(value, nullptr, front_);
                front_->prev = dummy_;
                front_ = dummy_;
            }
            ++size_;
            return true;
        }
        else 
            return false;      
    }
    
    bool insertLast(int value) {
        if (size_ < capacity_) {
            if (back_->val == -1)
                back_->val = value;
            else {
                dummy_ =  new Node(value, back_, nullptr);
                back_->next = dummy_;
                back_ = dummy_;
            }
            ++size_;
            return true;
        }
        else 
            return false;
    }
    
    bool deleteFront() {
        if (size_) {
            if (front_->next == back_) {
                if (front_->val == -1)
                    back_->val = -1;
                else
                    front_->val = -1;
            }
            else {
                dummy_ = front_->next;
                delete front_;
                front_ = dummy_;    
            }
            --size_;
            return true;
        }
        else
            return false;
    }
    
    bool deleteLast() {
        if (size_) {
            if (back_->prev == front_) {
                if (back_->val == -1)
                    front_->val = -1;
                else
                    back_->val = -1;
            }
            else {
                dummy_ = back_->prev;
                delete back_;
                back_ = dummy_;
            }
            --size_;
            return true;
        }
        else 
            return false;
    }
    
    int getFront() {
        if (front_->val == -1)
            return back_->val;
        else
            return front_->val;
    }
    
    int getRear() {
        if (back_->val == -1)
            return front_->val;
        else
            return back_->val;
    }
    
    bool isEmpty() {
        return size_ ? true : false; 
    }
    
    bool isFull() {
        return (size_ == capacity_) ? true : false;
    }
private:
    struct Node {
        int val;
        Node* prev;
        Node* next;
        Node() : val(0), prev(nullptr), next(nullptr) {}
        Node(int v, Node* p, Node* n)
            : val(v), prev(p), next(n) {}
    };
    Node* front_;
    Node* back_;
    Node* dummy_;
    int capacity_;
    int size_;
};