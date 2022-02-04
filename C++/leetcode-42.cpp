// https://leetcode-cn.com/problems/trapping-rain-water

#include<vector>

//Dynamic Programming
int trap(std::vector<int>& height) 
{
    if (height.empty())
        return 0;
    int ans = 0;
    int size = height.size();
    std::vector<int> left_max(size), right_max(size);
    left_max[0] = height[0];
    for (int i = 1; i < size; ++i)
        left_max[i] = std::max(height[i], left_max[i - 1]);

    right_max[size - 1] = height[size - 1];
    for (int i = size - 2; i >= 0; --i)
        right_max[i] = std::max(height[i], right_max[i + 1]);

    for (int i = 1; i < size - 1; ++i)
        ans += std::min(left_max[i], right_max[i]) - height[i];
}

#include<stack>

int trap(std::vector<int>& height)
{
    int ans = 0, cur = 0;
    std::stack<int> st;
    while (cur < height.size()) {
        while (!st.empty() && height[cur] > height[st.top()]) {
            int top = st.top();
            st.pop();
            if (st.empty())
                break;
            int distance = cur - st.top() - 1;
            int bounded_height = std::min(height[cur], height[st.top()]) - height[top];
            ans += distance * bounded_height;
        }
        st.push(cur++);
    }
}

int trap(std::vector<int>& height)
{
    int ans = 0, left_max = 0, right_max = 0, left = 0, right = height.size() - 1;
    while (left < right) {
        if (height[left] < height[right]) {
            if (height[left] >= left_max)
                left_max = height[left];
            else
                ans += left_max - height[left];
            
            ++left;
        }
        else {
            if (height[right] >= right_max)
                right_max = height[right];
            else
                ans += right_max - height[right];
            
            ++right;
        }
    }
    return ans;
}