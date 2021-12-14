#include <iostream>

using namespace std;

int main() {
    char v[6];
    char* p;

    char* p = &v[3];    // p points to v's fourth element

    char x = *p;    // *p is the object that p points to
}


void copy_fct() {
    int v1[10] = {0,1,2,3,4,5,6,7,8,9};
    int v2[10];

    for (auto i=0; i!=10; ++i)
        v2[i]=v1[i];
}

void print() 
{
    int v[] = {0,1,2,3,4,5,6,7};

    for (auto x : v)
        cout<<x<<'\n';
    
    for (auto x : {10,21,22,22,22})
        cout<<x<<'\n';

    for (auto& x : v)
        cout<<x<<'\n';
    
    double* pd = nullptr;
    
    
    void sort(vector<double>& v);
}

double sum(const vector<double>&);   // we don't want modify an argument but still don't want cost of copy

int count_x(const char* p, char x)
{
    if(p==nullptr)
        return 0;
    int count=0;
    for(; *p!=0; ++p)
        if(*p==x)
            ++count;
    
    return count;
}

int count_x(const char* p, char x)
{
    if(p==nullptr)
        return 0;
    int count = 0;
    while(*p){
        if(*p==x)
            ++count;
        ++p;
    }
}

bool accept()
{
    cout<<"Do you want to proceed?\n";
    char answer = 0;
    cin>>answer;

    if(answer =='y')
        return true;
    return false;
}

bool accept2()
{
    cout<<"Do you want to proceed?\n";
    char answer = 0;
    cin>>answer;

    switch(answer){
        case 'y':
            return true;
        case 'n':
            return false;
        default:
            cout<<"ok\n";
            return false;
    }
}

void action()
{
    while (true) {
        cout << "enter action:\n";
        string act;
        cin >> act;
        Point delta {0,0};

        for (char ch : act) {
            switch (ch) {
                case 'u':
                case 'n':
                    ++delta.y;
                    break;
                case 'r':
                case 'e':
                    ++deltas.x;
                    break;
                default:
                    cout << "";
            }
            move(current)
        }
    }
}



struct Vector {
    int sz; // number of elements
    double* elem;   // pointer to elements
};

void vector_init(Vector& v, int s)
{
   v.elem = new double[s];  // allocate an array of s doubles
   v.sz = s;
}

double read_and_sum(int s)
{
    Vector v;
    vector_init(v, s);

    for (int i=0; i!=s; ++i)
        cin >> v.elem[i];
    
    double sum = 0;
    for (int i=0; i!=s; ++i)
        sum += v.elem[i];
    
    return sum;
}

void f(Vector v, Vector& rv, Vector* pv)
{
    int i1 = v.sz;  // access through name
    int i2 = rv.sz; // access through reference
    int i3 = pv->sz;    // access through pointer
}

class Vector2 {
    public:
        Vector2(int s): elem {new double[s]}, sz {s} 
            { }  // construct a Vector2
        double& operator[](int i) {return elem[i];}
        int size() {return sz;}
    private:
        double* elem;
        int sz;
};

Vector2 v(6);

double read_and_sum(int s)
{
    Vector2 v(s);
    for (int i = 0; i != v.size(); ++i)
        cin >> v[i];
    
    double sum = 0;
    for (int i = 0; i != v.size(); ++i)
        sum += v[i];
    
    auto array = new int[5];

    return sum;
}