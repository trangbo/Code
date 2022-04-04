// https://leetcode-cn.com/problems/invert-binary-tree/description/

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

#include<algorithm>

TreeNode* invert_tree(TreeNode* root) 
{
    if (root) {
        std::swap(root->left, root->right);
        invert_tree(root->left);
        invert_tree(root->right);
        // std::swap(root->left, root->right);
    }
    return root;
}

#include<stack>

TreeNode* invert_tree(TreeNode* root) 
{
    std::stack<TreeNode*> stk;
    stk.emplace(root);

    while (!stk.empty()) {
        auto t = stk.top();
        stk.pop();
        if (t) {
            std::swap(t->left, t->right);
            stk.emplace(t->left);
            stk.emplace(t->right);
        }
    }
    return root;
}