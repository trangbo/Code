// https://leetcode-cn.com/problems/3sum/

#include<vector>
#include<algorithm>

std::vector<std::vector<int>> three_sum(std::vector<int>& nums)
{
    std::vector<std::vector<int>> result;
    int length = nums.size();
    if (length < 3)
        return result;
    std::sort(nums.begin(), nums.end());
    for (auto it = nums.begin(); it != nums.end() - 2; ++it) {
        if (*it > 0)
            break;
        if (it == nums.begin() || *it != *(it - 1)) {
            auto l = it + 1;
            auto r = nums.end() - 1;
            while (l < r) {
                if (*l + *r < -*it)
                    ++l;
                else if (*l + *r > -*it)
                    --r;
                else {
                    result.push_back({*it, *l, *r});
                    while (l < r && *l == *(l + 1))
                        ++l;
                    while (l < r && *r == *(r - 1))
                        --r;
                    ++l;
                    --r;
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
