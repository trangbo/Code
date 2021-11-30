/*
    题目

    输入两个表示二进制的字符串，请计算他们的和，并以二进制字符串的形式输出。例如，输入的二进制字符串分别是“11”和“10”，则输出“101”
*/

/*
    分析

    错误，正常的反应是将二进制转换成int或long型整数，但是这个题目没有提到字符串的长度，所以很容易造成溢出（超出整数范围）
    因此，加法操作只能针对字符串进行，仿照十进制（总是将数字最右端对齐），然后从个位开始右至左，有进位则进位，逢二进一

*/

using System.Text;

namespace AlgorithmsPractice
{
    static partial class AlgorithmBo
    {
        public static string BinaryAddition(string a, string b)
        {
            var result = new StringBuilder();   
            int i = a.Length - 1, j = b.Length - 1, carry = 0;  // 此时i j分别代表最高位，carry为是否需要进位（0不进位）
            
            while (i >= 0 || j >= 0) // 当前位只要a或b还有一个不为空
            {
                int digitA = i >= 0 ? a[i--] - '0' : 0; // a的当前位，只要i不小于0就取之，方法为a[i]（char）-'0'得到数字，i--为进行计算后到前一位
                int digitB = j >= 0 ? b[j--] - '0' : 0; // 同理取b的当前位
                int sum = digitA + digitB + carry;  // a b当前位之和，carry如果为1，则是把上一次右侧位进位的1加上
                carry = sum >= 2 ? 1 : 0;           // 计算当前次carry是否位1（是否需要进位）
                sum = sum >= 2 ? sum - 2 : sum;     // 通过当前位是否进位（carry），计算sum最终的值，需要进位则减去2
                result.Append(sum);                 // 将当前位最终的和sum加入result最左侧，然后进去下次左侧位计算
            }

            if (carry == 1) // 看最后一次是否需要进位
            {
                result.Append(1);   // 如果需要，则添加最高位1
            }

            // 由于是逆序加入result，需要反转
            var charArray = result.ToString().ToCharArray();
            Array.Reverse(charArray);
   
            return new string(charArray); 
        }
    }
}