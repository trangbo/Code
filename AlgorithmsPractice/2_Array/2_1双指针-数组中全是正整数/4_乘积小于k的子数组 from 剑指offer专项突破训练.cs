/*
    题目
    输入一个由正整数组成的数组和一个正整数k，请问数组中有多少个数字乘积小于k的连续子数组？
    例如，输入数组[10,5,2,6]，k的值为100，有8个子数组的所有数字的乘积小于100，它们分别是[10], [5], [2], [6], [10,5], [5,2], [2,6], [5,2,6]
*/

/*
    分析
    这个题目是乘积的，和上一题看起来不太一样，但求解的思路大同小异，利用两个指针求解。P1和P2指向数组中的两个数字，两个指针之间的数组组成一个子数组。P1永远不会到P2右边。两个指针初始化都指向0
    如果两个指针之间的子数组数字的乘积小于k，则右指针向右移动，意味着加入新的数字到数组，由于都是正整数，所以子数组的数字乘积就会变大。
    如果子数组乘积大于等于k，则P1向右移动，相当于删除数字，因此乘积变小。
    我们的目标是求出个数，一旦向右移动指针P1到某个位置时，子数组乘积小于k，就不需要向右移动P1。这是因为只要保持P2不动，向右移动P1形成的所有子数组的数字乘积就一定小于k。此时，P1P2之间有多少个数字，就找到了多少个数组。
*/

namespace AlgorithmsPractice
{
    static partial class AlgorithmBo
    {
        // 复杂度还是O(n)，P1P2一直是增加状态，与上一题一样
        static internal int NumSubArrayProductLessThanK(int[] nums, int k)
        {
            long product = 1;   // 乘积初始值，这里考虑到了Int32乘积溢出的情况，所以设置了Int64 long型
            int left = 0, count = 0;    // 左指针P1指向下标0的数字，count为计算数组的个数

            for (int right = 0; right < nums.Length - 1; ++right)   // 外循环，右指针right初始化指向下标0数字，每次循环右移1
            {
                product *= nums[right]; // 当主循环第一次开始时，初始乘积为nums[right]，之后的每一次计算都是以当前prodcut为基底去计算

                while (left <= right && product >= k)    // 内循环，控制左指针left，两个条件，P1超过P2，并且当前乘积需要大于等于k，满足P1向右移动的条件（减少数组中的数字）
                {
                    product /= nums[left++];    // 如果满足条件，乘积就等于当前的乘积值除去当前nums[left]，并且left右移，然后再去while循环判断
                }

                count += right >= left ? right - left + 1 : 0;  // 当每一次在主循环P2右指针位置固定结束之时，（P1都判定并结束相关语句后），进行count赋值
            }                                                   // 判定条件为，只要P1还在P2左侧，或者等于P2的位置（说明P1到了P2前一个位置，并且没有找到，left++后再次判定时没有再成功，说明P1P2共同指向的值也时满足的）那么count的值为right-left+1个
                                                                // 也就是nums[P1, P1+1, P1+n, P2] nums[P1+1, P1+n, P2] ~~ nums[P1+n, P2], nums[P2]个
                                                                // 否则，当left在right右边（left++），说明即使P2指向了P1所在的位置，也没有找到
            return count;
        }
    }
}
