// https://leetcode-cn.com/problems/merge-sorted-array/

#include<vector>

void merge(std::vector<int>& nums1, int m, std::vector<int>& nums2, int n) 
{
    int p1 = m - 1;  
    int p2 = n - 1;
    int i = m + n - 1;
    while (p1 != -1 && p2 != -1) {
        if (nums2[p2] >= nums1[p1]) 
            nums1[i--] = nums2[p2--]; 
        else
            nums1[i--] = nums1[p1--];        
    }
    while (p2 != -1)
        nums1[i--] = nums2[p2--];
}
