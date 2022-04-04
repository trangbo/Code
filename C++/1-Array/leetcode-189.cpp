// https://leetcode-cn.com/problems/rotate-array/

#include<vector>
#include<algorithm>

void rotate(std::vector<int>& nums, int k) 
{
    int size = nums.size();
    int steps = k % size;
    if (size == 1 || steps == 0)
        return;
    /*
    std::reverse(nums.begin(), nums.end());
    std::reverse(nums.begin(), nums.begin() + steps);
    std::reverse(nums.begin() + steps, nums.end());
    */
    
    // similar speed for std::reverse and own reverse
    reverse(nums.begin(), nums.end());
    reverse(nums.begin(), nums.begin() + steps);
    reverse(nums.begin() + steps, nums.end());
}

void reverse(std::vector<int>::iterator begin, std::vector<int>::iterator end)
{
    while (begin < end)
        std::swap(*(begin++), *(--end));
}
