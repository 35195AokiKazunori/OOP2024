using System;
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

namespace RssReader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUri.Text);
                var xdoc = XDocument.Load(url);

                
                foreach( var xnovelist in xdoc.Root.Elements()) {
                    var xtitle = xdoc.Root.Descendants("title");

                }
                



            }
        }
    }
    //テスト範囲
    //システム設計 9月12日(木)
    //C# プログラム 課題提出
}
