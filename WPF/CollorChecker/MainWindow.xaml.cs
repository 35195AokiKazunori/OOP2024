using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MyColor currentColer;
        MyColor[] colorsTable;
        private bool existsComboColor;

        public MainWindow() {
            InitializeComponent();
            //αチャンネルの初期値を設定（起動時すぐにストックボタンが押された時の対応）
            currentColer = new MyColor { Color = Color.FromArgb(255, 0, 0, 0) };
            DataContext = colorsTable = GetColorList(); ;
        }

        //スライドを動かすと呼ばれるイベントハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            currentColer.Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            currentColer.Name = GetColorList().Where(c => Equals(currentColer.Color)).Select(x => x.Name).FirstOrDefault();
            colorArea.Background = new SolidColorBrush(currentColer.Color);

            int i;
            for(i = 0; i < colorsTable.Length; i++) {
                if (colorsTable[i].Color.Equals(currentColer.Color)) {
                    currentColer.Name = colorsTable[i].Name;
                    break;
                }
            }
            colorSelectComboBox.SelectedIndex = i;
            colorArea.Background = new SolidColorBrush(currentColer.Color);
            
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            // colorSelectComboBoxから選択された色をストック
            var selectedComboColor = (MyColor)colorSelectComboBox.SelectedItem;
            if (selectedComboColor != null) {
                bool existsComboColor = stockList.Items.Cast<MyColor>().Any(color => color.Color.Equals(selectedComboColor.Color));
                if (!existsComboColor) {
                    stockList.Items.Insert(0, selectedComboColor);
                }
            }

            // スライダーの色を取得
            var sliderColor = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            var mySliderColor = new MyColor { Color = sliderColor, Name = $"R:{sliderColor.R} G:{sliderColor.G} B:{sliderColor.B}" };

            bool existsSliderColor = stockList.Items.Cast<MyColor>().Any(c => c.Color.Equals(mySliderColor.Color));
            if (!existsSliderColor) {
                stockList.Items.Insert(0, mySliderColor);
            }

            // 重複があった場合
            if (existsComboColor || existsSliderColor) {
                MessageBox.Show("この色はすでにストックされています。");
            }
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            colorArea.Background = new SolidColorBrush(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);
            setSliderValue(((MyColor)stockList.Items[stockList.SelectedIndex]).Color);
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        /// <summary>
        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var mycolor = currentColer = (MyColor)((ComboBox)sender).SelectedItem;
            var color = mycolor.Color;
            var name = mycolor.Name;

            setSliderValue(color);

            stockList.Name = currentColer.Name;
        }
    }
}
