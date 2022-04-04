// https://leetcode-cn.com/problems/group-anagrams/

#include<vector>
#include<string>
#include<unordered_map>
#include<algorithm>

std::vector<std::vector<std::string>> groupAnagrams(std::vector<std::string>& strs) 
{
    std::unordered_map<std::string, std::vector<std::string>> map;
    for (auto& s : strs) {
        auto t = s;
        std::sort(t.begin(), t.end());
        map[t].emplace_back(s);
    }
    std::vector<std::vector<std::string>> result;
    for (auto& p : map)
        result.emplace_back(p.second);
    return result;
}
