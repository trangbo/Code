//https://leetcode-cn.com/problems/generate-parentheses/

#include<vector>
#include<string>

void helper(std::vector<std::string>& vec, std::string str, int left, int right)
{
    // if (str.size() == 2 * n)
    if (left == 0 && right == 0) {
        vec.emplace_back(str);
        return;
    }
    /*
    if (left > right)
        return;

    if (left > 0) 
        helper(vec, str + "(", left - 1, right);
    if (right > 0)
        helper(vec, str + ")", left, right - 1);
    */
    
    if (left > 0) 
        helper(vec, str + "(", left - 1, right);
    if (right > left)
        helper(vec, str + ")", left, right - 1);
}

std::vector<std::string> generate_parentheses(int n)
{
    std::vector<std::string> result;
    if (n == 0)
        return result;
    helper(result, "", n, n);
    return result;
}

void helper(std::vector<std::string>& vec, std::string str, int left, int right, int n)
{
    // if (str.size() == 2 * n)
    if (left == n & right == n) {
        vec.emplace_back(str);
        return;
    }
    /*
    if (left < right)
        return;
    
    if (left < n)
        helper(vec, str + "(", left + 1, right, n);
    if (right < n)
        helper(vec, str + ")", left, right + 1, n);
    */

    if (left < n)
        helper(vec, str + "(", left + 1, right, n);
    if (right < left)
        helper(vec, str + ")", left, right + 1, n);
    
}

std::vector<std::string> generate_parentheses(int n)
{
    std::vector<std::string> result;
    if (n == 0)
        return result;
    helper(result, "", 0, 0, n);
    return result;
}




std::vector<std::string> generate_parentheses(int n)
{
    std::vector<std::string> result;
    if (n == 0) 
        return result;

    for (int i = 0; i < n; ++i)
        for (auto& left : generate_parentheses(i))
            for (auto& right : generate_parentheses(n - 1 - i))
                result.emplace_back("(" + left + ")" + right);

    return result;
}