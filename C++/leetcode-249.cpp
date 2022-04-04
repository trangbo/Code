// https://leetcode-cn.com/problems/valid-anagram/

#include<string>
#include<vector>

bool isAnagram(std::string s, std::string t) 
{
    if (s.size() != t.size())
        return false;
    std::vector<int> vec(26, 0);
    for (char& c : s)
        ++vec[c - 'a'];
    for (char& c : t) 
        if (--vec[c - 'a'] < 0)
            return false;
    return true;
}

#include<string>
#include<unordered_map>

bool isAnagrambc(std::string s, std::string t) 
{
    if (s.size() != t.size())
        return false;
    std::unordered_map<char, int> map;
    for (char& c : s)
        ++map[c];
    for (char& c : t)
        if (--map[c] < 0)
            return false;
    return true;
}

int main()
{
    isAnagrambc("rat", "car");
}

