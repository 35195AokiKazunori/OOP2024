using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //あなたは平成〇〇年〇月〇日〇曜日に生まれました

            Console.WriteLine("生年月日を入力");
            Console.Write("年:");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月:");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日:");
            var day = int.Parse(Console.ReadLine());

            var birtday = new DateTime(year, month, day);
            var culture = new CultureInfo("jp-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birtday.ToString("ggyy年M月d日",culture);

            Console.WriteLine();
            Console.WriteLine(birtday.ToString("あなたは" + str + "に生まれました"));
            Console.WriteLine();

            //あなたは生まれてから今日で〇〇〇〇日目です

            Console.WriteLine("今日の日付を入力");
            Console.Write("年:");
            var toyear = int.Parse(Console.ReadLine());
            Console.Write("月:");
            var tomonth = int.Parse(Console.ReadLine());
            Console.Write("日:");
            var today = int.Parse(Console.ReadLine());

            var Today = new DateTime(toyear, tomonth, today);

            TimeSpan diff =  Today - birtday;
            Console.WriteLine("あなたが生まれてから今日で" + "{0}日目",diff.Days);




            //var dt1 = new DateTime(2024, 6, 19);
            //var dt2 = new DateTime(2016, 11, 26, 8, 18, 7);
            //Console.WriteLine(dt1);
            //Console.WriteLine(dt2);
            //
            //var today = DateTime.Today;
            //var now = DateTime.Now;
            //Console.WriteLine("Today : {0}",today);
            //Console.WriteLine("Now : {1}",now);
            //
            //var isLeapYear = DateTime.IsLeapYear(2024);
            //if (isLeapYear) {
            //    Console.WriteLine("閏年です");
            //} else {
            //    Console.WriteLine("閏年ではありません");
            //}
        }
    }
}
