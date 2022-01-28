// https://leetcode-cn.com/problems/climbing-stairs/

int climb_stairs(int n) 
{
    int steps_last = 1;
    int steps_n = 1;
    while(--n) {
        steps_n = steps_n + steps_last;
        steps_last = steps_n - steps_last;
    }
    return steps_n;
}