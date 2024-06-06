using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var prefectureOfficeDict = new Dictionary<string, string>();
            for (int i = 0; i < 5; i++) {
                Console.WriteLine("県庁所在地の登録");
                //都道府県の入力
                Console.Write("都道府県:");
                var Key = Console.ReadLine();
                Console.WriteLine(Key);
                //県庁所在地の入力
                Console.Write("県庁所在地:");
                var Value = Console.ReadLine();
                Console.WriteLine(Value);

                //employeeDictへ登録
                if (prefectureOfficeDict.ContainsKey(Key)) {
                    prefectureOfficeDict.Add(Key, Value);
                } else {
                    //登録済の場合
                    string yes = "はい";
                    string no = "いいえ";
                    Console.WriteLine("上書きしますか？");
                    Console.Write("はい or いいえ:");
                    var choice = Console.ReadLine();
                    Console.WriteLine(choice);
                    if(choice.Equals(yes)) {
                        prefectureOfficeDict.Add(Key, Value);
                    }else if(choice.Equals(no)) {

                    }
                }
            }

            foreach (var item in prefectureOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です");
            }








            /*-------------------------------------------------------------------------*/

            //var employeeDict = new Dictionary<int, Employee> {
            //{ 100, new Employee(100, "清水遼久") },
            //{ 112, new Employee(112, "芹沢洋和") },
            //{ 125, new Employee(125, "岩瀬奈央子") },
            //};
            //
            //employeeDict.Add(126,new Employee(126, "庄野和花"));
            //
            //foreach (var item in employeeDict.Values) {
            //    Console.WriteLine($"{item.Id} {item.Name}");
            //}

            //var name = employeeDict.Where(e => e.Value.Name.Contains("和"));
            //foreach (var item in name) {
            //    Console.WriteLine($"{item.Key} {item.Value.Name}");
            //}

            //foreach (var item in employeeDict) {
            //    Console.WriteLine($"{item.Key} {item.Value.Name}");
            //}

            // 以下、確認のためのコード
            //var emp0 = employeeDict[100];
            //Console.WriteLine($"{emp0.Id} {emp0.Name}");
            //var emp1 = employeeDict[112];
            //Console.WriteLine($"{emp1.Id} {emp1.Name}");
            //var emp2 = employeeDict[125];
            //Console.WriteLine($"{emp2.Id} {emp2.Name}");

            /*-------------------------------------------------------------------------*/

        }
    }
}