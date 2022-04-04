// https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/

#include<vector>

int remove_duplicates(std::vector<int>& nums) 
{
    if (nums.size() < 2)
        return nums.size();
    auto slow = nums.begin();
    auto fast = nums.cbegin() + 1;
    while (fast != nums.cend()) {
        if (*slow == *fast)
            ++fast;
        else
            *(++slow) = *fast;
    }
    return slow - nums.cbegin() + 1;
}
