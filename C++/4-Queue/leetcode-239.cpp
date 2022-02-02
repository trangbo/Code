// https://leetcode-cn.com/problems/sliding-window-maximum/

#include<vector>
#include<deque>

std::vector<int> maxSlidingWindow(std::vector<int>& nums, int k)
{
    if (nums.empty() || k <= 0)
        return {};
    std::deque<int> dq;
    std::vector<int> result;
    for (int i = 0; i < nums.size(); ++i) {
        while (!dq.empty() && nums[i] > dq.back())
            dq.pop_back();
        dq.push_back(nums[i]);
        if (i >= k - 1) {
            result.push_back(dq.front());
            if (dq.front() == nums[i - (k - 1)])
                dq.pop_front();
        }
    }
    return result;
}