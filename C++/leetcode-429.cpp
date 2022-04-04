// https://leetcode-cn.com/problems/n-ary-tree-level-order-traversal/

#include<vector>

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

#include<vector>

std::vector<std::vector<int>> result;

void helper(Node* root, int depth)
{
    if (root == nullptr)
        return;
    if (result.size() == depth)
        result.emplace_back();
    
    result[depth].emplace_back(root->val);
    for (auto x : root->children)
        helper(x, depth + 1);
}

std::vector<std::vector<int>> levelOrder(Node* root) 
{
    helper(root, 0);
    return result;
}

#include<queue>

std::vector<std::vector<int>> levelOrder(Node* root)
{
    std::vector<std::vector<int>> result;
    if (root == nullptr)
        return result;    
    std::queue<Node*> queue;
    queue.emplace(root);
    int cur_count = 1;

    while (cur_count) {
        std::vector<int> temp;
        int next_count = 0;
        while (cur_count--) {
            auto x = queue.front();
            queue.pop();
            temp.emplace_back(x->val);
            next_count += x->children.size();
            for (auto y : x->children)
                queue.emplace(y);
        }
        result.emplace_back(temp);
        cur_count = next_count;
    }
    return result;
}