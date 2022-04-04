// https://leetcode-cn.com/problems/binary-tree-postorder-traversal/

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

#include<vector>

void helper(TreeNode* root, std::vector<int>& res)
{
    if (root == nullptr)
        return;
    helper(root->left, res);
    helper(root->right, res);
    res.emplace_back(root->val);
}

std::vector<int> postorder_traversal(TreeNode* root) 
{
    std::vector<int> result;
    helper(root, result);
    return result;
}

#include<vector>
#include<stack>

std::vector<int> postorder_traversal(TreeNode* root) 
{
    std::vector<int> result;
    std::stack<TreeNode*> stk;
    auto x = root;
    TreeNode* prev = nullptr;

    while (x || !stk.empty()) {
        while (x) {
            stk.emplace(x);
            x = x->left;
        }
        x = stk.top();
        stk.pop();
        if (x->right == nullptr || x->right == prev) {
            result.emplace_back(x->val);
            prev = x;
            x = nullptr;
        }
        else {
            stk.emplace(x);
            x = x->right;
        }
    }
    return result;
}

#include<vector>
#include<algorithm>

void add_path(std::vector<int>& vec, TreeNode* node)
{
    int count = 0;
    while (node) {
        ++count;
        vec.emplace_back(node->val);
        node = node->right;
    }
    std::reverse(vec.end() - count, vec.end());
}

std::vector<int> postorder_traversal(TreeNode* root)
{
    std::vector<int> result;
    TreeNode* x = root;
    TreeNode* predec = nullptr;

    while (x) {
        if (x->left) {
            predec = x->left;
            while (predec->right && predec->right != x)
                predec = predec->right;
            if (predec->right == nullptr) {
                predec->right = x;
                x = x->left;
                continue;
            }
            else {
                predec->right = nullptr;
                add_path(result, x->left);
            }
        }
        x = x->right;
    }
    
    add_path(result, root);
    return result;
}