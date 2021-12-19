#include <vector>
#include <algorithm>

using namespace std;

class Solution {
public:
    void wiggleSort(vector<int>& nums) {
        int len = nums.size();

        // Fina a median
        auto midptr = nums.begin() + len / 2;
        nth_element(nums.begin(), midptr, nums.end());
        int mid = *midptr;

        // Index-rewriting
        #define A(i) nums[(1+2*(i)) % (len|1)]

        // 3-way-partition-to-wiggly in O(n) time with O(1) space
        int i = 0;
        int j = 0;
        int k = len - 1;
        while (j <= k) {
            if (A(j) > mid) 
                swap(A(i++), A(j++));
            else if (A(j) < mid)
                swap(A(j), A(k--));
            else 
                ++j;
        }    
    }
};


