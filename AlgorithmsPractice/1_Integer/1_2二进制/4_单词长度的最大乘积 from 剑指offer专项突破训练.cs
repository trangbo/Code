/*
    题目
    输入一个字符串数组words，请计算不包含相同字符的两个字符串words[i]和words[j]的长度乘积的最大值。如果所有字符串都包含至少一个相同字符，那么返回0。假设字符串中只包含英文小写字母。
    例如，输入的字符串数组words为["abcw", "foo", "bar", "fxyz", "abcdef"]，数组中的字符串“bar”与“foo”没有相同的字符，他们长度的乘积为9。“abcw”与“fxyz”也没有相同的字符串，他们的长度乘积为16.
    这是该数组不包含相同字符的一对字符串的长度乘积的最大值。

*/

/*
    分析
    关键是判断两个字符串str1与str2没有相同的字符串。直观来说，基于字符串str1中每个字符ch，扫描str2判断ch是否出现在str2，如果两个字符串长度分别为p和q，这种蛮力法复杂度为O(pq)

    用哈希表记录字符串中出现的字符
    用哈希表来优化时间。对每一个字符串，用一个哈希表记录出现在该字符串的所有字符。在判断str1与str2时，只需要从‘a’到‘z’判断某个字符是否在两个字符串对应的哈希表都出现过了。
    在哈希表中查找时间复杂度为O(1)，假设所有字符都是小写，只有26个可能性。最多只需要在每个哈希表查询26次就可以。26是常数，可以认为应用哈希表后判断是否包含相同字符的时间复杂度为O(1)，下面while循环内if语句
    由于只考虑26个小写字母，可以用一个长度为26的布尔型数组模拟哈希表。数组下标为0表示‘a’，以此类推。

    用整数的二进制数位记录字符串中出现的字符
    布尔值只有true或false，这与二进制相似，所以可以将长度26的布尔数组用二进制数位代替，0对应false，1对应true
    Int32整数有32位，只需要26位就能表示字符串中出现的字符，所以用Int32型。如果有‘a’，整数最右边位1，如果‘b’，整数倒数第2位为1，以此类推。
    这样做的好处能更快的判断两个字符串是否包含相同字符，如果某个字符相同，对应的整数某个数位为1，则位与运算不会等于0，反之则为0

*/

namespace AlgorithmsPractice
{
    static partial class AlgorithmBo
    {
        // 总体时间复杂度为O(nk+n^2) 如果words长度为n，空间复杂度为O(n)
        static internal int MaxProductA(string[] words)
        {
            var length = words.Length;
            var flags = new bool[length, 26]; // 创建一个布尔二维数组模拟哈希表，一维长度为输入字符串数组长度，二维长度为26个小写字母

            for (int i = 0; i < length; i++)    // 一层循环，对每个字符串遍历，初始化哈希表，如果words长度位n，平均每个字符串长度位k，初始化时间复杂度位O(nk)
            {
                foreach (char c in words[i].ToCharArray())  // 对当前字符串进行每一个字符遍历
                {
                    flags[i, c - 'a'] = true;   //  对当前一维字符串的二维字符处进行true赋值，c-‘a’计算出字符对应的数组下标处
                }                               // 循环结束后，对于每一个字符串，其字符对应的为true，没有的则为false
            }

            int result = 0; // 初始化result为0

            // 总共O(n^2)对字符串（两层循环），判断每对字符串是否包含相同字符位O(1)，while循环。因此这一步时间复杂度位O(n^2)
            for (int i = 0; i < length; i++)    // 一层循环，遍历所有字符串
            {
                for (int j = i + 1; j < length; j++)    // 二层循环，遍历当前字符串后面所有字符串与当前字符串比较
                {
                    int k = 0;  // 小写字母控制位，要跳出循环使用，所以没在for里面
                    
                    while (k < 26)  // 从a到z遍历
                    {
                        if (flags[i, k] && flags[j, k]) // 假如两个字符串当前小写字母符号位都为true
                            break;                      // 则意味着符合题目“至少都包含一个相同字符”，没有继续比较的必要，所以退出循环，结束比较
                        
                        k++;    // k+1 进入下一字符位
                    }

                    if (k == 26)    // 如果k来到了26，意味着所有0~25 小写字母全部都遍历（没有退出过while循环），也就是说这两个字符串没有一个相同的字符
                    {
                        int prod = words[i].Length * words[j].Length;   // 计算当前循环两个字符串的长度乘积
                        result = Math.Max(result, prod);    // 比较当前长度乘积与历史最大乘积即result，将大的值赋值给result，使result一直保持最大长度乘积
                    }
                }
            }

            return result;  // 整个循环结束后，返回最大的乘积数
        }

        // 总体时间复杂度为O(nk+n^2) 如果words长度为n，空间复杂度为O(n)，只不过判断两个字符串是否相等时，这个值只比较1次，而上面需要比较26次
        // 如果变成52个大小写，那么这个还是比较1次，可以用Int64
        public static int MaxProduct(string[] words)
        {
            var length = words.Length;
            var flags = new int[length];    // 用一维数组代替二维数组，因为一个单独的Int32整数足够（32 > 26）

            // 初始化时间复杂度O(nk)
            for (int i = 0; i < length; i++)    // 循环遍历每一个字符串
            {
                foreach (char c in words[i].ToArray())    // 对于当前字符串中的每一个字符
                {
                    flags[i] |= 1 << (c - 'a'); // 首先进行1左移c-‘a’位，这样，相应的位为1，比如c为‘d’，那么左移3位，那么整数从右数第4位为1
                }                               // 然后flags[i]再与左移后的数进行或运算这样把所有的1都拿到了，赋值给flag[i]
            }

            int result = 0;

            // 前两层循环和思路1一样，将i的往前所有字符串比一遍，所以j初始值为i+1,时间复杂度O(n^2)
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if ((flags[i] & flags[j]) == 0) // 如果两个整数有任何位相同为1，则结果一定不为0，反过来，为0则一定没有相同字符
                    {
                        int prod = words[i].Length * words[j].Length;   // 与上面相似
                        result = Math.Max(result, prod);
                    }
                }
            }

            return result;
        }
    }
}