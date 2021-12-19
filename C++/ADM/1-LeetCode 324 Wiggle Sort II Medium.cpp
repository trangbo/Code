#include <vector>
#include <algorithm>

using namespace std;

class Solution {
public:
    void wiggleSort(vector<int>& nums) {
        auto midptr = nums.begin() + nums.size() / 2;
        nth_element(nums.begin(), midptr, nums.end());
        int mid = *midptr;

        // 3-way-partition
        int i = 0;
        int j = 0;
        int k = nums.size() - 1;
        while (j < k) {
            if (nums[j] > mid) {
                swap(nums[j], nums[k]);
                --k;
            }
            else if (nums[j] < mid) {
                swap(nums[j], nums[i]);
                ++i;
                ++j;
            }
            else {
                ++j;
            }
        }

        if (nums.size() % 2)
            ++midptr;
        vector<int> tmp1(nums.begin(), midptr);
        vector<int> tmp2(midptr, nums.end());
        for (int i = 0; i < tmp1.size(); ++i) {
            nums[2 * i] = tmp1[tmp1.size() - 1 - i];
        }
        for (int i = 0; i < tmp2.size(); ++i) {
            nums[2 * i + 1] = tmp2[tmp2.size() - 1 - i];
        }
    }
};
