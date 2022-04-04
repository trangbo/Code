// https://leetcode-cn.com/problems/validate-binary-search-tree/

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

bool helper(TreeNode* root, TreeNode* min_node, TreeNode* max_node)
{
    if (root == nullptr)
        return true;
    if (min_node && root->val <= min_node->val || max_node && root->val >= max_node->val)
        return false;
    return helper(root->left, min_node, root) && helper(root->right, root, max_node);
}

bool is_valid_BST(TreeNode* root) 
{
    return helper(root, nullptr, nullptr);
}

#include<climits>

bool helper(TreeNode* root, long long min, long long max)
{
    if (root == nullptr)
        return true;
    if (root->val <= min || root->val >= max)
        return false;
    
    return helper(root->left, min, root->val) && helper(root->right, root->val, max);
}

bool iis_valid_BST(TreeNode* root) 
{
    return helper(root, LONG_LONG_MIN, LONG_LONG_MAX);
}


#include<climits>
#include<stack>

bool iis_valid_BST(TreeNode* root)
{
    long long pre = LONG_LONG_MIN;
    std::stack<TreeNode*> stk;
    auto x = root;
    while (x || !stk.empty()) {
        while (x) {
            stk.emplace(x);
            x = x->left;
        }
        x = stk.top();
        stk.pop();
        if (x->val <= pre)
            return false;
        pre = x->val;
        x = x->right;
    }
    return true;
}

#include<climits>

long long pre = LONG_LONG_MIN;

bool is_valid_BST(TreeNode* root)
{
    if (root == nullptr)
        return true;
    
    if (!is_valid_BST(root->left))
        return false;

    if (root->val <= pre)
        return false;
    
    pre = root->val;
    return is_valid_BST(root->right);
}

#include<iostream>

int main()
{
    std::cout << sizeof(int) << "\n";
    std::cout << sizeof(long) << "\n";
    long long l = INT64_MAX;
    std::cout << l << "\n";
    std::cout << sizeof(long long) << "\n";
}