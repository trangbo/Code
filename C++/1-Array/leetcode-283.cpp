// https://leetcode-cn.com/problems/move-zeroes/

#include<vector>

void move_zeros(std::vector<int>& nums)
{
    if (nums.empty())
        return;
    int cur = 0;
    for (auto& num : nums) 
        if (num)
            std::swap(nums[cur++], num); 
}