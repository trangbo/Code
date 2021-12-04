/*
    题目
    输入一个整数数组和一个整数k，请问数组中有多少个数字之和等于k的连续子数组？
    例如，输入数组[1,1,1]，k的值为2，有2个连续子数组之和为2
*/

/*
    分析，双指针不适用因为没有说是正整数。先分析蛮力法，一个长度为n的数组中有O(n^2)个子数组，如果求每个子数组的和需要O(n)时间，那么总的时间为O(n^3)
    如果稍微做一些优化， 那么用O(1)的时间就能求出子数组所有数之和。在求一个长度为i的子数组数字之和时，应该把该子数组看成在长度i-1的子数组的基础上添加一个新数组。只需要一个加法，那么时间复杂度为O(1)
        优化后的时间复杂度为O(n^2)
    换一种思路，在从头到尾逐个扫描数组中的数字时求出前i个数字之和，并且将和保存下来，前i个数字之和为x，如果存在一个j(j<i)，数组的前j个数字之和为x-k，那么数组中从第j+1个数字开始到第i个数字结束的子数组之和为k
    这题目需要计算和为k的子数组的个数，当扫描到数组的第i个数字并求得前i个数字之和是x时，需要知道在i之前存在多少个j并且前j个数字之和等于x-k。
        所以，对每个i，不但要保存前i个数字之和，还要保存每个he出现的次数。分析道这里会知道我们需要一个哈希表，哈希表的键(key)时i个数字之和，值(value)为每个和出现的次数。
*/

using System.Collections.Generic;

namespace AlgorithmsPractice
{
    static partial class AlgorithmBo
    {
        // 只需要遍历一遍数组，时间复杂度为O(n)，使用一个哈希表存储数字之间的和，需要O(n)的辅助空间
        // 整个算法都运用了第二次利用第一次的值，第三次利用第二次的值，第四次利用第三次的值达到最小时间复杂度的目的
        static public int SubArraySum(int[] nums, int k)
        {
            var sumToCount = new Dictionary<int, int>();    // 创建一个哈希表Dictionary，相当于Java HashMap
            sumToCount.Add(0, 1);   // 初始值（判定）增加，Key为0，Value为1，当key(sum-k)为0时，说明当前num的连续子数组满足题目条件
            int sum = 0, count = 0; // 定义sum和，count计数

            foreach (int num in nums)   // 遍历循环数组中每一个数
            {
                sum += num; // 到当前遍历的数字之和为之前所有的和加上这一次新的数字 O(1)
                count += sumToCount.GetValueOrDefault(sum - k, 0);  // 计数加上（判定）sum-k为key的value，如果不存在此key，则加上默认值value 0，每次sum-k时如果得到的和是之前出现过的子数组之和，就说明到k之间是有符合条件的子数组的
                sumToCount.Add(sum, sumToCount.GetValueOrDefault(sum, 0) + 1);  // 然后把当前和sum作为key，然后对于value，首先获取之前是否存在当前sum作为key的value,然后再加1
            }                                                                   // 因为0和负数，所以当sum一样时，举例可以由0或者-1，1两种情况，那么当sum-k等于这个和时，相应的就有两种不同的子数组
            
            return count;
        }
    }
}