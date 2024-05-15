using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                "tokyo","New Delhi","Bangkok","London",
                "Paris","Berlin","Canberra","Hong Kong"
            };

            var query = names.Where(s => s.Length <= 5).ToList();
            foreach (var item in query) {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------");

            names[0] = "Osaka";
            foreach (var item in query) {
                Console.WriteLine(item);
            }



            /*IEnumerable<string> query = names.Where(s => s.Contains(' ')).
                                                Select(s => s.ToUpper());
            foreach (string s in query)
                Console.WriteLine(s);*/

        }
    }
}
