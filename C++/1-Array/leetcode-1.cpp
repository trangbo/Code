// https://leetcode-cn.com/problems/two-sum/

#include<vector>
#include<unordered_map>

std::vector<int> twoSum(std::vector<int>& nums, int target)
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
/*
#include<algorithm>

std::vector<int> twoSum(std::vector<int>& nums, int target) 
{
    std::vector<int> temp_vec(nums);
    std::sort(temp_vec.begin(), temp_vec.end());
    int left = 0;
    int right = temp_vec.size() - 1;
    int temp_sum;
    while (left != right) {
        temp_sum = temp_vec[left] + temp_vec[right];
        if (temp_sum > target)
            --right;
        else if (temp_sum < target)
            ++left;
        else {
            int first = std::find(nums.cbegin(), nums.cend(), temp_vec[left]) - nums.cbegin();
            int second = std::find(nums.crbegin(), nums.crend(), temp_vec[right]) - nums.crend() + 1;
            return {first, second};   
        }
    }   
    return {};
}
*/