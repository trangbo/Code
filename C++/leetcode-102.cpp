// https://leetcode-cn.com/problems/binary-tree-level-order-traversal/

struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

#include<vector>
#include<queue>

std::vector<std::vector<int>> level_order(TreeNode* root) 
{
    if (root == nullptr)
        return {};

    std::queue<TreeNode*> queue;
    std::vector<std::vector<int>> result;
    queue.emplace(root);
    int cur_count = 1;

    while (cur_count) {
        std::vector<int> vec;
        int next_count = 0;
        while (cur_count--) {
            auto t = queue.front();
            queue.pop();
            vec.emplace_back(t->val);
            if (t->left) {
                queue.emplace(t->left);
                ++next_count;
            } 
            if(t->right) {
                queue.emplace(t->right);
                ++next_count;
            }
        }
        result.emplace_back(vec);
        cur_count = next_count;
    }
    return result;
}

#include <vector>

std::vector<std::vector<int>> result;

void helper(TreeNode* root, int depth)
{
    if (root == nullptr)
        return;
    if (result.size() == depth)
        result.emplace_back();
    
    result[depth].emplace_back(root->val);
    helper(root->left, depth + 1);
    helper(root->right, depth + 1);
}

std::vector<std::vector<int>> level_order(TreeNode* root)
{
    helper(root, 0);
    return result;
}


