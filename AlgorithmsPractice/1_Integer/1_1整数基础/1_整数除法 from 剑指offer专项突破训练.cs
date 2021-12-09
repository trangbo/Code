/*
    题目

    输入2个int型整数，它们进行除法运算并返回商，要求不得使用乘号'*'、除号'/'及求余符号'%'。当发生溢出时，返回最大的整数值。
    假设除数不为0。例如，输入15和2，输出15/2的结果，即7。
*/

/*
    分析

    基本，基于减法实现除法，例如15/2，不断地从15减2，知道7个2之后是1，不能再减，所以商是7，循环实现。
    缺点，被除数很大时除数很小时（n/1），时间复杂度O(n)，需要优化解法。
    优化，
        a 当被除数大于除数时，继续判断被除数是否大于除数的2倍
        b 如果a true，继续判断是否大于除数的4倍、8倍
        c 如果被除数最多大于除数的2^k倍，那么被除数减去除数的2^k倍
        d 剩余被除数重复基本步骤
        e 由于每次将除数翻倍，优化后时间复杂度O(logn)
        举例，
            a 15 > 2, 15 > 2^2, 15 > 2^3, 15 < 2^4, 15-2^3=7, 这部分商为2^3/2=4
            b 7 > 2, 7 > 2^2, 7 < 2^3, 7-2^2=3, 这部分商为2^2/2=2
            c 3 > 2, 3 < 2^2, 3-2^1=1, 这部分商为2^1/2=1
            d 1 < 2, 这部分商为0
            e 最终商4+2+1=7
    额外，上述都是讨论假设除数被除数都是正整数，如果其中一个有负数，先转换成正数，计算之后再调整。
        但是将负数转换成整数存在问题，对于int-32来说，最小为-2^31，最大2^31-1，最小转最大会溢出。所以把正数转换成负数。
        商的绝对值<=|被除数|。 因此只有一种情况会溢出，(-2^31-1)/-1
        
*/

namespace AlgorithmsPractice
{
    static partial class AlgorithmBo
    {
        static internal int Divide(int dividend, int divisor)
        {
            if (dividend == Int32.MinValue && divisor == -1)    // 首先判断是否为溢出情况（经过上面分析只有一种情况）
            {
                return Int32.MaxValue;  // 如果是，则结果为Int32最大值
            }

            int negative = 2;   // 负数指示，如果两个都为正或负，则negative为0或2，最终结果也为正；如果一个为正一个为负，则negative为1，最终结果也为负

            if (dividend > 0)   // 判断被除数是否为正，如果是，negative负数指示减1，并且将正数转化为负数（根据上面分析，为避免溢出。需要把所有转化为负数去计算）
            {
                negative--;
                dividend = -dividend;
            }

            if (divisor > 0)    // 同理判断除数
            {
                negative--;
                divisor = -divisor;
            }

            int result = DivideCore(dividend, divisor); // 调用核心方法

            return negative == 1 ? -result : result;    // 根据negative负数指示，决定是否对结果取负数
        }

        private static int DivideCore(int dividend, int divisor)
        {
            int result = 0; // 初始化result为0，当被除数绝对值小于除数绝对值时也适用

            // 外循环复杂度可以看作1，当被除数为n，除数为1
            while (dividend <= divisor) // 全为负数，需要反向思考 15 > 2, -15 < -2，并允许==情况
            {
                int value = divisor, quotient = 1;  // 声明并初始化当前循环value-除数值，quotient-商-至少为1
                
                // 进入当前循环的比较，每一次都是除数的2^k(k=1,2,3)倍数
                // 因为题目不让用“/”，为避免溢出Int32，-2^31的一半是-2^30 == 0xc0000000
                while (value >= 0xc0000000 && dividend <= value + value)   // 内循环时间复杂度为O(logn)，当被除数为n，除数为1
                {
                    quotient += quotient;   // 每进行一次，商也呈2^k(k=1,2,3),倍数增长
                    value += value; // 每进行一次，value也呈2^k(k=1,2,3),倍数增长
                }

                result += quotient; // 比较循环结束后，将当前主循环的result更新
                dividend -= value;  // 被除数变为减去value的大小，进入下一次主循环，直到被除数绝对值小于除数绝对值
            }

            return result;  // 返回最终result
        }
    }
}