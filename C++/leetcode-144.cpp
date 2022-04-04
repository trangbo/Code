// https://leetcode-cn.com/problems/binary-tree-preorder-traversal/

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
    res.emplace_back(root->val);
    helper(root->left, res);
    helper(root->right, res);
}

std::vector<int> preorder_traversal(TreeNode* root) 
{
    std::vector<int> result;
    helper(root, result);
    return result;
}

#include<vector>
#include<stack>

std::vector<int> preorder_traversal(TreeNode* root)
{
    std::vector<int> result;
    std::stack<TreeNode*> stk;
    auto x = root;
    while (x || !stk.empty()) {
        if (x) {
            result.emplace_back(x->val);
            stk.emplace(x);
            x = x->left;
        }
        else {
            x = stk.top()->right;
            stk.pop();
        }
    }
    return result;
}

#include<vector>

std::vector<int> preorder_traversall(TreeNode* root)
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
                result.emplace_back(x->val);
                predec->right = x;                
                x = x->left;
                continue;
            }
            else {
                predec->right = nullptr;
            }
        }
        else {
            result.emplace_back(x->val);    
        }
        x = x->right;
    }
    return result;
}
