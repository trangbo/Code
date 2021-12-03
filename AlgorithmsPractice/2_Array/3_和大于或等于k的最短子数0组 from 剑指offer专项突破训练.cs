/*
    题目
    输入一个正整数组成的数组和一个正整数k，请问数组中和大于或等于k的连续子数组的最短长度是多少。如果不存在所有数字之和大于或等于k的子数组，则返回0
    例如，输入数组[5,1,4,3]，k的值为7，和大于或等于7的最短连续子数组时[4,3]，因此输出它的长度2
*/

/*
    分析
    子数组由数组中一个或连续多个数字组成。一个子数组可以用两个指针表示。P1指向第一个数字，P2指向最后一个数字，子数组就是两个指针之间的数字组成的。
    P1P2初始化时都指向数组的第一个元素。如果两个指针之间的子数组中所有数字之和大于或等于K，那么把P1向右移动，相当于从子数组最左边删除一个数字，子数组的长度也减1.因为数组中都是正的
    所以从子数组删除数组就能减小数组之和。一直向右移动指针P1，直到子数组的和小于k
    如果两个指针之间数字之和小于k，那么把指针P2向右移动，相当于添加新的数字，就能得到更大的数。

    例如，数组[5,1,4,3],首先，P1P2都指向5，此时子数组只有5，5小于7，则向右移动P2，5+1小于7，则继续移动P2，5+1+4大于7，得到了第一个子数组。长度为3
    尝试把P1向右移动，确定是否能找到最短的子数组。移动P1后，子数组为1+4小于7，然后P2向右移动，1+4+3大于7，找到了第二个子数组，长度也是3.
    再把P1向右移动，4+3=7，第三个子数组长度为2
    再一次把P1向右移动，这时子数组只有3，正常应该把P2向右移动，但是P2已经时最后一个了，这样就尝试了所有可能性。

    总结，当P1P2子数组之和小于K，则P2向右增加数，直到子数组之和大于k，向右移动P1，直到子数组之和小于k。
*/

namespace AlgorithmsPractice
{
    static partial class AlgorithmBo
    {
        // 虽然有两个嵌套循环，假设数组长度为n，两个循环中，left和right都只是只增加不减少，right从0到n-1，left最多0到n-1
        // 总的执行次数和时间复杂度还是O(n)
        static public int MinSubArrayLen(int k, int[] nums)
        {
            int left = 0, sum = 0, minLength = Int32.MaxValue;  // 定义左指针，子数组之和，将长度定义为Int32最大值

            // 用外循环控制右指针，内循环控制左指针，就能很好的在逻辑之间跳转，外循环的右指针是一定要进行完毕的
            for (int right = 0; right < nums.Length; right++)   // 定义右指针，并且主循环为向右移动右指针
            {
                sum += nums[right]; // 子数组之和等于之前的加上新移动的数字

                while (left <= right && sum >= k)   // 如果左指针在右指针左面，并且子数组之和已经大于等于k，这时符合题目要求
                {
                    minLength = Math.Min(minLength, right - left + 1);  // 对比当前自主组长度和定义的minLength，这里面的机制时把一个最大值Int32赋值给minLength，所以能确保长度很好的和其进行对比
                    sum -= nums[left++];    // 然后这句话是首先，将子数组之和减去最左边的数，并且左指针向右移动，进行下一次判定
                }
            }

            return minLength == Int32.MaxValue ? 0 : minLength; // 最后再和初始值进行比较返回，如果还是初始值，则没有找到任何符合题目的子数组，那么返回0，否则返回实际的最小长度
        }
    }
}