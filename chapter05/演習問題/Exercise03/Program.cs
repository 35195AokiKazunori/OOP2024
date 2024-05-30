using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            Console.WriteLine("-----");

            Exercise3_6(text);

        }

        private static void Exercise3_1(string text) {
            Console.Write("空白数:");
            Console.WriteLine(text.Where(c => c == ' ').Count());
        }

        private static void Exercise3_2(string text) {
            Console.Write("変換:");
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            int count = text.Split(' ').Length;
            Console.WriteLine("単語数:",count);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            var array = text.Split(' ').ToArray();
            var sb = new StringBuilder();
            foreach (var word in array) {
                sb.Append(word);
                sb.Append(' ');
            }
            Console.WriteLine(sb);
        }

        private static void Exercise3_6(string text) {
            var array = text.Split(new[] {' ',',','-','_'}).ToArray();
            foreach (var word in array) {
                Console.WriteLine(word);
            }
        }
    }
}
