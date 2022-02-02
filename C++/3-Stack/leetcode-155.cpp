// https://leetcode-cn.com/problems/min-stack/

#include<stack>

class MinStack {
public:
    MinStack() 
    {
        
    }
    
    void push(int val) 
    {
        if (s.empty())
            s.push({val, val});
        else
            s.push({val, std::min(val, s.top().second)});
    }

    void pop() 
    {
        if (!s.empty())
            s.pop();
    }
    
    int top() 
    {
        if (!s.empty())
            return s.top().first;
        else
            return 0;
    }
    
    int getMin() 
    {
        if (!s.empty())
            return s.top().second;
        else
            return 0;
    }
private:
    std::stack<std::pair<int, int>> s;
};

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack* obj = new MinStack();
 * obj->push(val);
 * obj->pop();
 * int param_3 = obj->top();
 * int param_4 = obj->getMin();
 */