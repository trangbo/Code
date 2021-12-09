/*
     题目
     输入一个只包含0和1的数组，请问如何求0和1的个数相同的最长连续子数组的长度？
     例如，在数组[0,1,0]中有两个子数组包含相同个数的0和1，分别是[0,1]和[1,0],他们的长度都是2,因此输出2
*/

/*
    分析
    只要把这个题目稍微变换一下就是上一题的思路.首先把输入数组中的0都换成-1,那么题目就变成求包含相同数目的-1和1的最长子数组的长度,在一个只包含1和-1的数组中
    如果子数组中-1和1数目相同,那么子数组数字之和就为0,因此这个题目就变成求数字之和为0的最长子数组的长度
    扫描数组时累加已经扫描过的数字之和.如果数组中前i个数字之和为m,前j个数字(j>1)之和也为m,那么从第i+1个数字到第j个数字的子数组数字之和为0,这个和为0的子数组长度为j-i
    如果扫描到第j个数字并累加得到前j个数字之和m,那么就需要知道是否存在一个i(i<j)使数组中前i个数字之和也为m.
    可以把数组从第一个数字开始到当前扫描的数字累加之和保存到一个哈希表.由于我们的目标是求出数字之和为0的最长字数组的长度,因此哈希表的键(key)是从第1个数字开始累加到当前扫描到的数字之和,而值(value)是当前扫描数字的下标
*/

namespace AlgorithmsPractice
{
    static partial class AlgorithmBo
    {
        // 只有一个循环,时间复杂度O(n),因为需要一个额外哈希表,空间复杂度O(n)
        static internal int FindMaxLength(int[] nums)
        {
            var sumToIndex = new Dictionary<int, int>();    // 定义字典,相当于Java HashMap
            sumToIndex.Add(0, -1);  // 添加默认键值,此时下标为-1,是为了后续的计算长度使用,(0,-1)键对一直不变,为了当sum为0时计算长度使用
            int sum = 0, maxLength = 0; // 初始化,和为0,最大长度为0

            for (int i = 0; i < nums.Length; ++i)   // 循环遍历每一个数组中每一个数字
            {
                sum += nums[i] == 0 ? -1 : 1;   // sum+= 后面的表达式是判断当前扫描数字是否是0,如果是,则返回-1给sum+=,否则返回1(因为数组中只有0,1)

                if (sumToIndex.ContainsKey(sum))    // 字典是否有当前sum的键
                    maxLength = Math.Max(maxLength, i - sumToIndex[sum]);   // 如果有,则比较当前长度(用i - sumToIndex[sum]计算,初始值-1为了这个)与maxLength,将大的赋值给maxLength
                else 
                    sumToIndex.Add(sum, i); // 如果没有,则将键sum与下标i加进字典
            }

            return maxLength;   // 返回最终的长度
        }
    }
}