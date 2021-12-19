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

enum Type {ptr, num}; // a Type can hold values ptr and num

struct Entry {
    string name; // string is a standard-library type
    Type t;
    Node* p; // use p if t==ptr
    int i; // use i if t==num
};

void f(Entry* pe)
{
    if (pe->t == num)
        cout << pe->i;
}

union Value {
    Node* p;
    int i;
};

struct Entry {
    string name;
    Type t;
    Value v; // use v.p if t==ptr; usi v.i if t==num
};

void f(Entry* pe) {
    if (pe->t == num)
        cout << pe->v.i;
}

struct Entry {
    string name;
    variant<Node*, int> v;
};

void f(Entry* pe)
{
    if (holds_alternative<int>(pe->v))
        cout << get<int>(pe->v);
}

enum class Color { red, blue, green };
enum class Traffic_light { green, yellow, red };

Color col = Color::red;
Traffic_light light = Traffic_light::red;

Color x = red;  // error: which red?
Color y = Traffic_light::red; // error: that red is not a Color
Color z = Color::red;   // OK

int i = Color::red; // error: Color::red is not an int
Color c = 2; // initalization error: 2 is no a Color

Color x = Color {5}; // OK, but verbose
Color y {6}; // also OK

Traffic_light& operator++(Traffic_light& t) // prefix increment: ++
{
    switch (t) {
        case Traffic_light::green:  return t=Traffic_light::yellow;
        case Traffic_light::yellow: return t=Traffic_light::red;
        case Traffic_light::red: return t=Traffic_light::green;
    }
}

Traffic_light next = ++light; // next becomes Traffic_light::green

enum Color { red, green, blue};
int col = green;

double sqrt(double); // the square root function takes a double and return sa doble

class Vector {
public:
    Vector(int s);
    double& operator[](int i);
    int size();
private:
    double* elem; // elem points to an array of sz doubles
    int sz;
};

double sqrt(double d)
{
    // algorithm...
}

Vector::Vector(int s)   // definition of the constructor
    :elem{new double[s]}, sz{s} // initialize members
{
}

double& Vector::operator[](int i)   // definition if subscripting
{
    return elem[i];
}

int Vector::size()  // definition of size()
{
    return sz;
}

// Vector.h

#include "Vector.h" // get Vector's interface
#include <cmath>    // get the standard-library math function inteface 

double sqrt_sum(Vector& v)
{
    double sum = 0;
    for (int i = 0; i != v.size(); ++i)
        sum += std::sqrt(v[i]);
    return sum; 
}