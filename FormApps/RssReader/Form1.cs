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
using Windows.UI.Xaml.Controls.Primitives;
using System.Diagnostics;
using Windows.UI;

namespace RssReader {
    public partial class Form1 : Form {
        //設定クラスのインスタンス作成
        Settings settings = Settings.getInstance();

        List<Itemdata> xitem;
        readonly CountdownEvent condition = new CountdownEvent(1);
        public Form1() {
            InitializeComponent();
        }

        //コンボボックスに予め要素を入れる
        private void Form1_Load(object sender, EventArgs e) {
            InitializeAsync();
            cbGenre.Items.Add("主要");
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
                string selectedGenre = cbGenre.Text;

                List<string> validGenres = new List<string> {
            "主要", "国内", "国際", "経済", "エンタメ", "スポーツ", "IT", "科学", "地域"
        };

                if (validGenres.Contains(selectedGenre)) {
                    string url = null;

                    if (selectedGenre.Equals("主要")) {
                        url = "https://news.yahoo.co.jp/rss/topics/top-picks.xml";
                    } else if (selectedGenre.Equals("国内")) {
                        url = "https://news.yahoo.co.jp/rss/topics/domestic.xml";
                    } else if (selectedGenre.Equals("国際")) {
                        url = "https://news.yahoo.co.jp/rss/topics/world.xml";
                    } else if (selectedGenre.Equals("経済")) {
                        url = "https://news.yahoo.co.jp/rss/topics/business.xml";
                    } else if (selectedGenre.Equals("エンタメ")) {
                        url = "https://news.yahoo.co.jp/rss/topics/entertainment.xml";
                    } else if (selectedGenre.Equals("スポーツ")) {
                        url = "https://news.yahoo.co.jp/rss/topics/sports.xml";
                    } else if (selectedGenre.Equals("IT")) {
                        url = "https://news.yahoo.co.jp/rss/topics/it.xml";
                    } else if (selectedGenre.Equals("科学")) {
                        url = "https://news.yahoo.co.jp/rss/topics/science.xml";
                    } else if (selectedGenre.Equals("地域")) {
                        url = "https://news.yahoo.co.jp/rss/topics/local.xml";
                    }

                    if (url != null) {
                        try {
                            var topics = wc.OpenRead(url);
                            var xdoc = XDocument.Load(topics);
                            lbRssTitle.Items.Clear();

                            xitem = xdoc.Root.Descendants("item")
                            .Select(item => new Itemdata {
                                Title = item.Element("title").Value,
                                Link = item.Element("link").Value,
                            }).ToList();

                            foreach (var item in xitem) {
                                lbRssTitle.Items.Add(item.Title);
                            }
                        }
                        catch (Exception ex) {
                            MessageBox.Show("エラーが発生しました: " + ex.Message);
                        }
                    }
                } else if (Uri.IsWellFormedUriString(selectedGenre, UriKind.Absolute)) {
                    // 入力された文字列が有効なURLである場合
                    try {
                        var topics = wc.OpenRead(selectedGenre);
                        var xdoc = XDocument.Load(topics);
                        lbRssTitle.Items.Clear();

                        xitem = xdoc.Root.Descendants("item")
                        .Select(item => new Itemdata {
                            Title = item.Element("title").Value,
                            Link = item.Element("link").Value,
                        }).ToList();

                        foreach (var item in xitem) {
                            lbRssTitle.Items.Add(item.Title);
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show("エラーが発生しました: " + ex.Message);
                    }
                } else {
                    MessageBox.Show("無効なジャンルまたはURLが入力されました。正しいジャンルを選択するか、正しいURLを入力してください。");
                }
            }
        }

        //タイトルを選択でURL先に飛ぶ
        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            webView21.CoreWebView2.Navigate(xitem[lbRssTitle.SelectedIndex].Link);
        }

        //タイトルを選択でURL先に飛ぶ
        private void lbRssSave_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssSave.SelectedIndex >= 0) {
                // 選択された記事のリンクを取得
                var selectedItem = (System.Windows.Forms.ListViewItem)lbRssSave.SelectedItem;
                var link = selectedItem.SubItems[1].Text; // リンクは2番目のサブアイテムにある

                webView21.CoreWebView2.Navigate(link);
            }
        }

        //保存ボタン
        private void btSave_Click(object sender, EventArgs e) {
            if (lbRssTitle.SelectedItem == null) {
                MessageBox.Show("記事を選択してください");
                return;
            }

            // 選択されたアイテムのインデックスを取得
            int selectedIndex = lbRssTitle.SelectedIndex;

            // 選択されたアイテムのデータを取得
            var selectedItem = xitem[selectedIndex];

            // lbRssSave にタイトルとリンクを追加
            lbRssSave.Items.Add(new System.Windows.Forms.ListViewItem(new[] { selectedItem.Title, selectedItem.Link }));
        }

        //削除ボタン
        private void btDelete_Click(object sender, EventArgs e) {
            lbRssSave.Items.Clear();
        }

        //ブラウザを開く画面
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

        //色設定
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;  //背景色設定
                settings.MainFormColor = cdColor.Color.ToArgb(); //背景色保存
            }
        }

        //終了
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (MessageBox.Show("本当に終了しますか？", "確認",
                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Application.Exit();
            }
        }

        //アプリ説明
        private void このアプリについてToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("・URL入力又はトピックスの選択\r\n" +
                "関連したニュースのリストを取得することができます。" +
                "\r\n\r\n" +
                "・ニュースリスト\r\n" +
                "取得したリストを選択することでニュースの記事を閲覧できます。" +
                "\r\n\r\n" +
                "・リスト保存\r\n" +
                "ニュースリストから記事を保存することができます。",
                "このアプリの使い方について...");
        }
    }

    //データ格納用クラス
    public class Itemdata {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}