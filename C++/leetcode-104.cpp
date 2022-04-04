// https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

int result = 0;

void helper(TreeNode* root, int depth)
{
    if (root) {
        if (result < depth)
            result = depth;
        helper(root->left, depth + 1);
        helper(root->right, depth + 1);
    }
}

int max_depth(TreeNode* root)
{
    helper(root, 1);
    return result;
}

#include<queue>

int max_depth(TreeNode* root)
{
    if (root == nullptr)
        return 0;
    std::queue<TreeNode*> q;
    q.emplace(root);
    int result = 0;
    while (!q.empty()) {
        ++result;
        int size = q.size();
        while (size--) {
            auto x = q.front();
            q.pop();
            if (x->left)
                q.emplace(x->left);
            if (x->right) 
                q.emplace(x->right);
        }
    }
    return result;
}

#include<algorithm>

int max_depth(TreeNode* root)
{
    if (root == nullptr)
        return 0;
    return std::max(max_depth(root->left), max_depth(root->right)) + 1;
}