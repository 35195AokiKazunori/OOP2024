﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();
            if (String.Compare(str1,str2,ignoreCase:true) == 0) {
                Console.WriteLine("一致しています");
            } else {
                Console.WriteLine("不一致です");
            }
        }
    }
}
