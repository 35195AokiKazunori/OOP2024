﻿using SampleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);
            Product daihuku = new Product(150, "だいふく", 200);
            Product dorayaki = new Product(98, "どらやき", 210);

            int price = karinto.Price;  //税抜きの金額
            int taxIncluded = karinto.GetPriceIncludingTax();   //税込みの金額

            int daihukuprice = daihuku.Price;  //税抜きの金額
            int daihukutaxIncluded = daihuku.GetPriceIncludingTax();  //税込みの金額

            int dorayakiTax = dorayaki.GetTax();


            Console.WriteLine(karinto.Name + "の税込み金額" 
                                            + taxIncluded + "円【税抜き" +  price + "円】");
            Console.WriteLine(daihuku.Name + "の税込み金額" 
                                            + daihukutaxIncluded + "円【税抜き" + daihukuprice + "円】");
            Console.WriteLine($"{dorayakiTax}円");
        }
    }
}
