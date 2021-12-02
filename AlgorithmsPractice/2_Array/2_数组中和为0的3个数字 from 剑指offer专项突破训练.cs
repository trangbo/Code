/*
    题目
    输入一个数组，如何找出数组中所有和为0的3个数字的三元组？需要注意的是，返回值中不得包含重复的三元组。
    例如，在数组[-1,0,1,2,-1,-4]中有两个三元组和为0，他们分别为[-1,0,1] [-1,-1,2]
*/

/*
    分析
    这是上一题的加强版。如果输入的数组是排序的，就可以先固定一个数字i，然后在排序数组中查找和为-i的两个数字。我们有了时间为O(n)排序数组中的找两个数字的方法
    由于需要固定数组中的每一个数字，所以查找三元组的时间复杂度为O(n^2)
    这个题目没有数组没有排序，需要先排序，排序的时间复杂度通常是O(nlogn)，所以总的时间复杂度是O(nlogn)+O(n^2)，所以总的时间复杂度还是O(n^2)
    还有一个问题是如何去除重复的三元组，在找到一个和为0的三元组后，就需要移动这两个指针，再去找其余的三元组，在移动指针的时候跳过所有相同的值，以便过滤掉重复的三元组。
*/

namespace AlgorithmsPractice
{
    static partial class AlgorithmBo
    {
        public static List<List<int>> ThreeSum(int[] nums)
        {
            var result = new List<List<int>>(); // 新建List，里面存储那些三元组

            if (nums.Length >= 3)   // 首先排除边界，小于3个的数组不能做
            {
                Array.Sort(nums);   // 将数组排序，没有自己实现，直接用通用的最快的

                int i = 0;  // 计数器
                while (i < nums.Length - 2) // 将nums[i]作为固定的数，不能超过最后两个数
                {
                    TwoSum(nums, i, result);    // 调用判断另外两个数的和是否为 -nums[i]，并加入result List， result为类，所以TwoSum做的修改全局有效
                    
                    int temp = nums[i]; // 将当前数字赋值给temp
                    while (i < nums.Length && nums[i] == temp)  // 当i不超过数组大小并且nums[i+1] == nums[i], 则继续让计数器右移，越过这个重复的数字，避免重复计算  
                        ++i;
                }
            }

            return result;
        }

        private static void TwoSum(int[] nums, int i, List<List<int>> result)
        {
            int j = i + 1, k = nums.Length - 1; // 定义双指针，只不过j需要在传入的i+1，避免重复计算

            while (j < k)   // 当j小于k时，双指针不相交时，相交意味所有可能情况全部遍历了
            {
                if (nums[i] + nums[j] + nums[k] == 0)   // 判断三个数的和是否为0，题目要求
                {
                    var tempArray = new int[] {i, j, k};    // 假如满足的话，创建包含三个数的数组
                    result.Add(tempArray.ToList<int>());    // 然后将数组转化为List，并加入到result中

                    int temp = nums[j]; // temp保留nums[j]的值，左指针当前的值
                    while (nums[j] == temp && j < k)    // 当nums[j]等于temp并且左指针小于右指针时，让左指针右移，然后继续对比nums[j+1]与nums[j]是否相同（同时j不超过k）
                        ++j;                            // 这是为了避免计算重复加入三元组
                }
                else if (nums[i] + nums[j] + nums[k] < 0)   //  假如三个数之和小于0，那说明其中有的数字比较小，那么左指针右移
                    ++j;
                else    // 假如大于0，则将右指针左移
                    --k;
            }
        }
    }
}