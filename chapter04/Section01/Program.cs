using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            



            Console.WriteLine("整数を入力");
            string inputNum = Console.ReadLine();

            int num;
            
            if(int.TryParse(inputNum, out num)) {
                //変換に成功したときの処理
                Console.WriteLine("整数に変換した値:" + num);
            } else {
                //変換に失敗したときの処理
                Console.WriteLine("整数の変換に失敗しました")
            }
        }

        private static object GetMessage(string code) {
            return null;
        }

        private static object DefaultMessage() {
            return "DefaultMessage";
        }
    }

    public class Sale {
        //店舗名
        public String ShopName { get; set; }
        //商品カテゴリ
        public String ProductCategory { get; set; }
        //売上高
        public int Amount { get; set; }
    }

}
