using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);

        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                                  .Select(x => new {
                                      Name = x.Element("name").Value,
                                      Teammembers = x.Element("teammembers").Value
                                  });
            foreach (var sport in sports) {
                Console.WriteLine("{0}{1}",sport.Name,sport.Teammembers);
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var sports = xdoc.Root.Elements()
                                  .Select(x => new {
                                      Name = x.Element("name").Attribute("kanji").Value,
                                      Firstplayed = x.Element("firstplayed").Value,
                                  }).OrderBy(x => x.Firstplayed);
            foreach(var sport in sports) {
                Console.WriteLine("{0}({1})",sport.Name, sport.Firstplayed);
            }
        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var sport = xdoc.Root.Elements().OrderByDescending(x => x.Element("teammembers").Value).First();
            Console.WriteLine($"{sport.Element("name").Value}");
        }

        private static void Exercise1_4(string file, string newfile) {
            var soccer = new XElement("novelist",
                new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                new XElement("teammembers", "11"),
                new XElement("firstplayed", "1863")
              );
            var xdoc = XDocument.Load(file);
            xdoc.Root.Add(soccer);

            //保存
            xdoc.Save(newfile);

            List<XElement> xElements = new List<XElement>();

            string name, kanji, teammembers, firstplayed;
            int nextFlag;
            while(true) {
                //入力処理
                Console.Write("名称:");
                name = Console.ReadLine();
                Console.Write("漢字:");
                kanji = Console.ReadLine();
                Console.Write("人数:");
                teammembers = Console.ReadLine();
                Console.Write("起源:");
                firstplayed = Console.ReadLine();
                //1件分の要素作成
                var element = new XElement("ballsport",
                new XElement("name", name, new XAttribute("kanji", kanji)),
                new XElement("teammembers", teammembers),
                new XElement("firstplayed", firstplayed)
              );
                xElements.Add(element);//リストへ要素を追加

                Console.WriteLine();//改行
                Console.Write("追加【1】保存【2】");
                Console.Write(">");
                nextFlag = int.Parse(Console.ReadLine());
                if(nextFlag == 2 ) break;//無限ループを抜ける
                Console.WriteLine();
            }
            xdoc.Root.Add(xElements);
            xdoc.Save(newfile);//保存
        }
    }
}
