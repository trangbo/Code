// https://leetcode-cn.com/problems/two-sum/

#include<vector>
#include<unordered_map>

std::vector<int> two_sum(std::vector<int>& nums, int target)
{
    std::unordered_map<int, int> hash_map;
    for (int i = 0; i != nums.size(); ++i) {
        int sum = target - nums[i];
        if (hash_map.find(sum) != hash_map.end())
            return {hash_map[sum], i};
        hash_map.insert({nums[i], i});
    }
    return {};
}
