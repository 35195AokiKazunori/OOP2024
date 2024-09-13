using System;
using Microsoft.Web.WebView2.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;

namespace RssReader {
    public partial class Form1 : Form {
        List<Itemdata> xitem;
        readonly CountdownEvent condition = new CountdownEvent(1);
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitializeAsync();
            cbGenre.Items.Add("主要", url = "https://news.yahoo.co.jp/rss/topics/top-picks.xml");
            cbGenre.Items.Add("国内");
            cbGenre.Items.Add("国際");
            cbGenre.Items.Add("経済");
            cbGenre.Items.Add("エンタメ");
            cbGenre.Items.Add("スポーツ");
            cbGenre.Items.Add("IT");
            cbGenre.Items.Add("科学");
            cbGenre.Items.Add("地域");

            cbGenre.SelectedIndex = -1;
        }

        async void InitializeAsync() {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.NavigationCompleted += webView21_NavigationCompleted;
        }

        //タイトルとリンクを取ってくる

        private void btGenre_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(cbGenre.Text);
                var xdoc = XDocument.Load(url);

                xitem = xdoc.Root.Descendants("item")
                    .Select(item => new Itemdata {
                        Title = item.Element("title").Value,
                        Link = item.Element("link").Value,
                    }).ToList();

                foreach (var item in xitem) {
                    lbRssTitle.Items.Add(item.Title);
                }
            }
        }

        //タイトルを選択でURL先に飛ぶ
        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
                webView21.CoreWebView2.Navigate(xitem[lbRssTitle.SelectedIndex].Link);
        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e) {
            //読み込み結果を判定
            if (e.IsSuccess)
                Console.WriteLine("complete");
            else
                Console.WriteLine(e.WebErrorStatus);

            //シグナル初期化
            condition.Signal();
            System.Threading.Thread.Sleep(1);
            condition.Reset();
        }
    }

    //データ格納用クラス
    public class Itemdata {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}