// https://leetcode-cn.com/problems/container-with-most-water/

#include<vector>

int max_area(std::vector<int>& height)
{
    int left = 0, right = height.size() - 1, water = 0;
    while (left < right) {
        int h = std::min(height[left], height[right]);
        water = std::max(water, (right - left) * h);
        while (height[left] <= h && left < right)
            ++left;
        while (height[right] <= h && left < right)
            --right;
    } 
    return water;
}

