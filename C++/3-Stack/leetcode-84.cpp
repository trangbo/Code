// https://leetcode-cn.com/problems/largest-rectangle-in-histogram/

#include<vector>
#include<stack>

int largestRectangleArea(std::vector<int>& heights) 
{
    std::stack<int> st;
    int result = 0;
    heights.push_back(0);
    for (int i = 0; i < heights.size(); ++i) {
        while (!st.empty() && heights[i] < heights[st.top()]) {
            int top = heights[st.top()];
            st.pop();
            int left_range = st.empty() ? -1 : st.top();
            result = std::max(result, top * (i - left_range - 1));
        }
        st.push(i);
    }
    return result;
}