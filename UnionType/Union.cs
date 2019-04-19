using System;
using System.Runtime.InteropServices;

namespace UnionType {
    public class Union<T1, T2> {
        int index;
        object data;

        public Union(T1 val) {
            index = 0;
            data = val;
        }

        public Union(T2 val) {
            index = 1;
            data = val;
        }

        public bool Is<T>() {
            return Is(typeof(T));
        }

        public bool Is(Type t) {
            if (index == 0) {
                return typeof(T1) == t;
            }

            if (index == 1) {
                return typeof(T2) == t;
            }
            
            throw new IndexOutOfRangeException();
        }

        public T Get<T>() {
            var t = typeof(T);
            if (typeof(T1) == t) {
                return (T)data;
            }

            if (typeof(T2) == t) {
                return (T)data;
            }
            
            throw new IndexOutOfRangeException();
        }

        public override string ToString() {
            return data.ToString();
        }

        public override bool Equals(object obj) {
            return data.Equals(obj);

            throw new IndexOutOfRangeException();
        }

        public bool Equals(Union<T1, T2> other) {
            if (other.index != index) {
                return false;
            }

            return data.Equals(other.data);
        }

        public override int GetHashCode() {
            return data.GetHashCode();
        }

        public static bool operator ==(Union<T1, T2> a, Union<T1, T2> b) {
            if (a == null) {
                return b == null;
            }
            
            return a.Equals(b);
        }

        public static bool operator !=(Union<T1, T2> a, Union<T1, T2> b) {
            return !(a == b);
        }

        public static implicit operator T1(Union<T1, T2> union) {
            return (T1)union.data;
        }

        public static implicit operator T2(Union<T1, T2> union) {
            return (T2)union.data;
        }

        public static implicit operator Union<T1, T2>(T1 val) {
            return new Union<T1, T2>(val);
        }

        public static implicit operator Union<T1, T2>(T2 val) {
            return new Union<T1, T2>(val);
        }
    }
}