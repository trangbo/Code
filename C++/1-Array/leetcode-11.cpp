// https://leetcode-cn.com/problems/container-with-most-water/

#include<vector>

int max_area(std::vector<int>& height)
{
    int left = 0;
    int right = height.size() - 1;
    int water = 0;
    int temp_h = 0;
    while (left < right) {
        int temp_h = std::min(height[left], height[right]);
        water = std::max(water, (right - left) * temp_h);
        while (height[left] <= temp_h && left < right)
            ++left;
        while (height[right] <= temp_h && left < right)
            --right;
    } 
    return water;
}