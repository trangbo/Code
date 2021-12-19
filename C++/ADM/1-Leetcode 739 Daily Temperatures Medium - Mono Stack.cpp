#include <vector>
#include <stack>

using namespace std;

class Solution {
public:
    vector<int> dailyTemperatures(vector<int>& temperatures) {
        int n = temperatures.size();
        vector<int> answer(n);
        stack<int> monoStack;
        for (int currDay = 0; currDay < n; ++currDay) {
            int currentTemp = temperatures[currDay];
            while (!monoStack.empty() && temperatures[monoStack.top()] < currentTemp) {
                int prevDay = monoStack.top();
                answer[prevDay] = currDay - prevDay;
                monoStack.pop();
            }
            monoStack.push(currDay);
        }

        return answer;
    }
};
