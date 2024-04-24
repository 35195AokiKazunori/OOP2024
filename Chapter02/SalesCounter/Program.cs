﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter {
    internal class Program {
        static void Main(string[] args) {
            //戻り値を受け止める
            List<Sale> sales = ReadSales(@"C:Users\infosys\source\repos\OOP2024\Chapter02\SalesCounter\data\bin\Debug\data");

            //戻り値のコレクションを一件ずつ出力する
            foreach (Sale sale in sales) {
                Console.WriteLine(sale.ShopName + " " + sale.ProductCategory + " " + sale.Amount);

                Console.WriteLine("店名:{0} カテゴリー:{1} 売上:{2}", sale.ShopName, sale.ProductCategory, sale.Amount);

                Console.WriteLine($"店名:{sale.ShopName} カテゴリー:{sale.ProductCategory} 売上:{sale.Amount}");
            }
        }

        //売上データを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines) {
                string[] items = line.Split(',');
                Sale sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                sales.Add(sale);
            }
            return sales;
        }

    }
}
