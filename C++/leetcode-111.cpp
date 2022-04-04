// https://leetcode-cn.com/problems/minimum-depth-of-binary-tree/

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

#include<queue>

int minDepth(TreeNode* root)
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
            if (x->left == nullptr && x->right == nullptr)
                return result;
            if (x->left)
                q.emplace(x->left);
            if (x->right)
                q.emplace(x->right);
        }
    }
    return result;  
}
