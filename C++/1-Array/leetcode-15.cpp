// https://leetcode-cn.com/problems/3sum/

#include<vector>
#include<algorithm>

std::vector<std::vector<int>> three_sum(std::vector<int>& nums)
{
    if (nums.size() < 3)
        return {};
    std::sort(nums.begin(), nums.end());
    std::vector<std::vector<int>> result;
    for (auto it = nums.cbegin(); it != nums.cend() - 2; ++it) {
        if (*it > 0)
            break;
        if (it == nums.cbegin() || *it != *(it - 1)) {
            auto left = it + 1;
            auto right = nums.cend() - 1;
            while (left < right) {
                if (*left + *right < -*it)
                    ++left;
                else if (*left + *right > -*it)
                    --right;
                else {
                    result.push_back({*it, *left, *right});
                    while (left < right && *left == *(left + 1))
                        ++left;
                    while (left < right && *right == *(right - 1))
                        --right;
                    ++left;
                    --right;
                }
            }
        }
    }
    return result;
}


/*   
    for (int i = 0; i < length - 2; ++i) {
        if (nums[i] > 0)
            break;
        if (i == 0 || nums[i] != nums[i - 1]) {
            int left = i + 1;
            int right = length - 1;
            while (left < right) {
                if (nums[left] + nums[right] < -nums[i]) 
                    ++left;
                else if (nums[left] + nums[right] > -nums[i])
                    --right;
                else {
                    result.push_back({nums[i], nums[left], nums[right]});
                    while (left < right && nums[left] == nums[left + 1])
                        ++left;
                    while (left < right && nums[right] == nums[right - 1])
                        --right;
                    ++left;
                    --right;
                }
            }
        }
    }
    return result;
*/
