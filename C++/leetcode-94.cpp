// https://leetcode-cn.com/problems/binary-tree-inorder-traversal/

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
};

#include<vector>

void inorder(TreeNode* root, std::vector<int>& res)
{
    if (root == nullptr)
        return;
    inorder(root->left, res);
    res.emplace_back(root->val);
    inorder(root->right, res);
}

std::vector<int> inorderTraversal(TreeNode* root) 
{
    std::vector<int> result;
    inorder(root, result);
    return result;
}

#include<vector>
#include<stack>

std::vector<int> inorderTraversal(TreeNode* root)
{
    std::vector<int> result;
    std::stack<TreeNode*> stk;
    auto x = root;
    while (x || !stk.empty()) {
        while (x) {
            stk.emplace(x);
            x = x->left;
        }
        x = stk.top();
        stk.pop();
        result.emplace_back(x->val);
        x = x->right;
    }
    return result;
}

#include<vector>

std::vector<int> inorderTraversal(TreeNode* root)
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
                result.emplace_back(x->val);
            }
        }
        else {
            result.emplace_back(x->val);
        }
        x = x->right;
    }
    return result;
}
