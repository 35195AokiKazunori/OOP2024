using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new[] { 4, 5, 6, 1, 4, 1, 4, 5, 7, 2, 6, 8, 2, 9 };

            //int count = numbers.Count(n => n % 2 == 0);
            double num = numbers.Where(n => n > 5).Average();
            int total = numbers.Where(n => n > 5).Sum();
            Console.WriteLine(num);
            Console.WriteLine(total);
        }
    }
}
