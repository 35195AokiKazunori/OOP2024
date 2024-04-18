using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_p38 {
    internal class Program {
        static void Main(string[] args) {
            Employee employee = new Employee {
                Id = 100,
                Name = "山田太郎",
                Birthday = new DateTime(1992, 4, 5),
                DivisionName = "第一営業部",
            };

            Console.WriteLine("{0}は{1}は、{2}に所属しています。",
                employee.Name,employee.GetAge(),employee.DivisionName);
        }
    }
}
