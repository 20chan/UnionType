using System;

using IntOrString = UnionType.Union<int, string>;

namespace UnionType.Example {
    class Program {
        static void Main(string[] args) {
            IntOrString a = 42, b = "answer";

            Print(a);
            Print(b);

            try {
                a.Get<string>();
            }
            catch (Exception ex) {
                Console.WriteLine("a is not string");
            }

            void Print(IntOrString val) {
                if (val.Is<int>()) {
                    Console.WriteLine("int: {0}", (int)val);
                }
                else if (val.Is<string>()) {
                    Console.WriteLine("string: {0}", (string)val);
                }
            }
        }
    }
}