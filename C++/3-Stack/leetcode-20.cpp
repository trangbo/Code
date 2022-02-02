// https://leetcode-cn.com/problems/valid-parentheses/

#include<string>
#include<stack>

bool isValid(std::string s) 
{
    std::stack<char> temp_stack;
    for (char c : s) {
        switch (c)
        {
            case '{':
            case '(':
            case '[': 
                temp_stack.push(c); 
                break;
            case '}':
                if (temp_stack.empty() || temp_stack.top() != '{')
                    return false;
                else
                    temp_stack.pop();
                break;
            case ')':
                if (temp_stack.empty() || temp_stack.top() != '(')
                    return false;
                else
                    temp_stack.pop();
                break;
            case ']':
                if (temp_stack.empty() || temp_stack.top() != '[')
                    return false;
                else
                    temp_stack.pop();
                break;
            }
        
    }
    return temp_stack.empty() ? true : false;
}
