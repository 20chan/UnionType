using System;
using System.Runtime.InteropServices;

namespace UnionType {
    public class Union<T1, T2> {
        [StructLayout(LayoutKind.Explicit)]
        private struct Data {
            [FieldOffset(0)]
            public T1 t1;
            [FieldOffset(0)]
            public T2 t2;
        }
        
        int index;
        Data data;

        public Union(T1 val) {
            index = 0;
            data = new Data { t1 = val };
        }

        public Union(T2 val) {
            index = 1;
            data = new Data { t2 = val };
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

        public override bool Equals(object obj) {
            if (index == 0) {
                return data.t1.Equals(obj);
            }

            if (index == 1) {
                return data.t2.Equals(obj);
            }

            throw new IndexOutOfRangeException();
        }

        public bool Equals(Union<T1, T2> other) {
            if (other.index != index) {
                return false;
            }

            if (index == 0) {
                return data.t1.Equals(other.data.t1);
            }

            if (index == 1) {
                return data.t2.Equals(other.data.t2);
            }
            
            throw new IndexOutOfRangeException();
        }

        public override int GetHashCode() {
            if (index == 0) {
                return data.t1.GetHashCode();
            }

            if (index == 1) {
                return data.t2.GetHashCode();
            }
            
            throw new IndexOutOfRangeException();
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
            return union.data.t1;
        }

        public static implicit operator T2(Union<T1, T2> union) {
            return union.data.t2;
        }

        public static explicit operator Union<T1, T2>(T1 val) {
            return new Union<T1, T2>(val);
        }

        public static explicit operator Union<T1, T2>(T2 val) {
            return new Union<T1, T2>(val);
        }
    }
}