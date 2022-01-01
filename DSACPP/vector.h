/*
    Bobo
    2022
    Exercise for DSACPP
    Head file for user defined type Vector
*/

#ifndef __VECTOR__
#define __VECTOR__

#include <iostream>
#include <algorithm>

constexpr int default_capacity = 8;

template <typename T> class Vector;

template <typename T>
class Vector {
public:
    Vector(int c = default_capacity, int length = 0, T default_value = 0); 
    Vector(const T* array, int length);
    Vector(const T* array, int low, int high);
    Vector(const Vector<T>& ve);
    Vector(const Vector<T>& ve, int low, int high);
    ~Vector() { delete[] elem_; }
    Vector<T>& operator=(const Vector<T>& ve);
    const T& operator[](int index) const;
    bool insert(int index, const T& new_elem);
    int remove(int low, int high);
    T remove(int index);
    int find(const T& ele, int low, int high) const;
    int deduplicate();
private:
    int size_;  // size of current Vector
    int capacity_;  // total capacity
    T* elem_;   // data
    void copy_from_(const T* array, int low, int high); // copy elements from another array
    void expand_();  // expand in case needed
    void shrink_();  // shrink in case needed
};

template <typename T>
inline Vector<T>::Vector(int c = default_capacity, int length = 0, T default_value = 0)
{
    capacity_ = c;
    elem_ = new T[capacity_];
    for (size_ = 0; size_ < length; ++size_) {
        elem_[size_] = default_value;
    }
}

template <typename T>
inline Vector<T>::Vector(const T* array, int length)
{
    if (array) {
        copy_from(array, 0, length);
    }
    else {
        std::cout << "Bad value of array, so Vector not initialized.\n" << std::endl;
        return;
    }
}

template <typename T>
inline Vector<T>::Vector(const T* array, int low, int high)
{
    if (array) {
        copy_from(array, low, high);
    }
    else {
        std::cout << "Bad value of array, so Vector not initialized.\n" << std::endl;
    }
}

template <typename T>
inline Vector<T>::Vector(const Vector<T>& ve)
{
    if (ve.elem_) {
        copy_from(ve.elem_, 0, ve.size_);
    }
    else {
        std::cout << "Bad value of Vector, so Vector not initialized.\n" << std::endl;
    }
}

template <typename T>
inline Vector<T>::Vector(const Vector<T>& ve, int low, int high)
{
    if (ve.elem_) {
        copy_from(ve.elem_, low, high);
    }
    else {
        std::cout << "Bad value of Vector, so Vector not initialized.\n" << std::endl;
    }
}

template <typename T>
inline Vector<T>& Vector<T>::operator=(const Vector<T>& ve)
{
    if (this = &ve) {
        return *this;
    }
    
    if (ve.elem_) {
        delete[] elem_;
        copy_from(ve.elem_, 0, ve.size_);
        return *this;
    }
    else {
        std::cout << "Bad value of Vector, so Vector not initialized.\n" << std::endl;
    }
}

template <typename T>
inline void Vector<T>::copy_from_(const T* array, int low, int high)
/*
    high is watch guard which not used. [low, high)
    new allocated array from [0, size_), size_ is the value of (high - low)
    Time Complexity O(high-low) = O(n)
*/
{
    if (low < high && 0 <= low) {
        capacity_ = std::max(default_capacity, 2 * (high - low));   // calculate new value of capacity_
        elem_ = new T[capacity_];
        size_ = 0;
        while (low < high) //copy from array[low, high) to elem_[0, size_)
            elem_[size_++] = array[low++];
    }
    else {
        std::cout << "Bad value of low or high, so Vector not initialized.\n" << std::endl;
    }
}

template <typename T>
inline const T& Vector<T>::operator[](int index) const
{
    if (0 <= index && index < size_) {
        return elem_[index];
    }
    else {
        std::cout << "Bad value for index, so can not get it.\n" << std::endl;
        return;
    }
}

template <typename T>
inline bool Vector<T>::insert(int index, const T& new_elem)
{
    if (index < 0 || index >= size_)
        return false;

    expand_();
    for (int i = size_; i > index; --i) {
        elem_[i] = elem_[i - 1];
    }
    elem_[index] = new_elem;
    ++size_;
    return true;
}

template <typename T>
inline int Vector<T>::remove(int low, int high)
{
    if (low <= high && low >= 0) {
        if (low == high)
            return 0;
    
        while (high < size_)
            elem_[low++] = elem_[high++];  // [hi, size_), O(size_-hi)
        size_ = low;
        shrink_();
        return high - low;
    }
    else {
        std::cout << "Bad value of low or high, action can not be done.\n" <<std::endl;
        return -1;
    }
}

template <typename T>
inline T Vector<T>::remove(int index)   // O(size_ - index)
{
    if (index >= 0 && index < size_) {
        T ele = elem_[index];
        remove(index, index + 1);
        return ele;
    }
    else {
        std::cout << "Bad value of low or high, action can not be done.\n" <<std::endl;
        return;
    }
}

template <typename T>
inline int Vector<T>::find(const T& ele, int low, int high) const
/**
 * @brief input-sensitive, best is O(1), worst is O(n)
 * 
 */
{
    if (low < high && low >= 0) {
        while ((low < high--) && (ele != elem_[high]));
        return high;
    }
}

template <typename T>
inline int Vector<T>::deduplicate()
{
    int old_size = size_;
    int i = 1;
    while (i < size_) {
        if (find(elem_[i], 0, i) < 0)
            ++i;
        else
            remove(i);
    }
    return old_size - size_;
}

template <typename T>
/*
    double capacity once reach the border
*/
inline void Vector<T>::expand_()
{
    if (size_ < capacity_)
        return;
    
    T* old_elem = elem_;
    capacity_ <<= 1;
    elem_ = new T[capacity_];
    for (int i = 0; i < size_; ++i) {
        elem_[i] = old_elem[i];
    }
    delete[] old_elem;
}

template <typename T>
inline void Vector<T>::shrink_()
{
    if (capacity_ < (default_capacity << 1))  // no shrink than deafult capacity
        return;
    if ((size_ << 2) > capacity_)  // 25%
        return;

    T* old_elem = elem_;
    elem_ = new T[capacity_ >>= 1]  // half the capacity
    for (int i = 0; i < size_; ++i)
        elem_[i] = old_elem[i];
    delete[] old_elem;
}

#endif  // __VECTOR__