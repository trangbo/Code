#ifndef __MORE__
#define __MORE__

class Account {
public:
    static void set_rate(const double& x) { m_rate = x; }
private:
    static double m_rate;
};

double Account::m_rate = 8.0;

int main() {
    Account::m_rate = 9.0;
    Account::set_rate(9.0);

    Account a;
    
    a.set_rate = 9.0;
    a.set_rate(9.0);
    a.set_rate = 9.0;
}

template <class T, class Sequence = deque>
class queue {
protected:
    Sequence c;
public:
    
};

#endif //__MORE__