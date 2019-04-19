using System;
using System.Linq;
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

            IntOrString[] arr = {
                1, 2, "clap", 4, 5, "clap",
            };

            var intsOnly = arr
                .Where(v => v.Is<int>())
                .Select(v => v.Get<int>()); // or just (int)v
            
            Console.WriteLine(string.Join(", ", intsOnly));

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