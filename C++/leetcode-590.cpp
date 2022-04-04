// https://leetcode-cn.com/problems/n-ary-tree-postorder-traversal/
#include <vector>

class Node {
public:
    int val;
    std::vector<Node*> children;

    Node() {}

    Node(int _val) {
        val = _val;
    }

    Node(int _val, std::vector<Node*> _children) {
        val = _val;
        children = _children;
    }
};

void helper(Node* root, std::vector<int>& vec)
{
    if (root == nullptr)
        return;
    for (auto x : root->children)
        helper(x, vec);
    vec.emplace_back(root->val);
}

std::vector<int> preorder(Node* root) 
{
    std::vector<int> result;
    helper(root, result);
    return result;
}

#include<stack>
#include<algorithm>

std::vector<int> preorder(Node* root)
{
    if (root == nullptr)
        return {};
    std::vector<int> result;
    std::stack<Node*> stk;
    stk.emplace(root);
    while (!stk.empty()) {
        auto x = stk.top();
        stk.pop();
        result.emplace_back(x->val);
        for (int i = 0; i < x->children.size(); ++i)
            stk.emplace(x->children[i]);
    }
    std::reverse(result.begin(), result.end());
    return result;
}