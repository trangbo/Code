// https://leetcode-cn.com/problems/plus-one/

#include<vector>

std::vector<int> plusOne(std::vector<int>& digits) 
{
    auto i = digits.rbegin();
    auto j = digits.rend();
    bool flag = true;
    while (i != j && flag) {
        if (*i == 9) {
            *i = 0;
            flag = true;
        }
        else {
            ++(*i);
            flag = false;
        }
        ++i;
    }
    if (flag)
        digits.insert(digits.begin(), 1);
    return digits;
}