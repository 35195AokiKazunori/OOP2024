using CustomerApp.Objects;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        private string _selectedImagePath;
        public MainWindow() {
            InitializeComponent();
        }

        //保存ボタン
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(NameTextBox.Text)) {
                MessageBox.Show("名前を入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImagePath = _selectedImagePath != null ? File.ReadAllBytes(_selectedImagePath) : null  // 画像をbyte[]として保存
            };

            try {
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Insert(customer);
                }
                ReadDatabase();  // ListView表示を更新
            }
            catch (Exception ex) {
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }
        }

        //削除ボタン
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            _selectedImagePath = null;
            SelectedImage.Source = null;

            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                selectedCustomer.ImagePath = null;
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.Update(selectedCustomer);
                }
            }
        }

        //更新ボタン
        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            // 名前が未入力の場合にエラーメッセージを表示
            if (string.IsNullOrEmpty(NameTextBox.Text)) {
                MessageBox.Show("名前を入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択してください");
                return;
            }

            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            if (!string.IsNullOrEmpty(_selectedImagePath)) {
                selectedCustomer.ImagePath = File.ReadAllBytes(_selectedImagePath);
            } else {
                selectedCustomer.ImagePath = null;
            }

            try {
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Update(selectedCustomer);
                }

                ReadDatabase();
            }
            catch (Exception ex) {
                MessageBox.Show($"更新中にエラーが発生しました: {ex.Message}");
            }
        }

        //画像開くボタン
        private void ImageSelectButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "画像ファイル|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == true) {
                _selectedImagePath = openFileDialog.FileName;

                byte[] imageBytes = File.ReadAllBytes(_selectedImagePath);
                SelectedImage.Source = ByteArrayToImage(imageBytes);  // 画像を表示
            }
        }

        //画像削除ボタン
        private void ImageDeleteButton_Click(object sender, RoutedEventArgs e) {
            _selectedImagePath = null;
            SelectedImage.Source = null;

            // 画像パスを削除したことをデータベースにも反映
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                selectedCustomer.ImagePath = null;
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.Update(selectedCustomer);
                }
            }
        }



        //ListView選択
        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer != null) {
                // 選択された顧客情報を表示
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;

                // 画像があれば表示
                if (selectedCustomer.ImagePath != null && selectedCustomer.ImagePath.Length > 0) {
                    SelectedImage.Source = ByteArrayToImage(selectedCustomer.ImagePath);
                } else {
                    SelectedImage.Source = null;
                }
            } else {
                // 選択されていない場合、テキストボックスをクリア
                NameTextBox.Clear();
                PhoneTextBox.Clear();
                AddressTextBox.Clear();
                SelectedImage.Source = null;
            }
        }

        //ListView読込
        private void ReadDatabase() {
            try {
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    var customers = connection.Table<Customer>().ToList();

                    _customers = customers;
                    CustomerListView.ItemsSource = _customers;
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"データベースの読み込み中にエラーが発生しました: {ex.Message}");
            }
        }

        //ListView検索
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            if (_customers == null) {
                MessageBox.Show("顧客データがロードされていません。");
                return;
            }

            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        //プログラム開始時に読込
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ReadDatabase();
        }

        //byte[]から画像に変換
        private BitmapImage ByteArrayToImage(byte[] byteArray) {
            if (byteArray == null || byteArray.Length == 0) {
                throw new InvalidOperationException("無効な画像データ");
            }

            try {
                using (var memoryStream = new MemoryStream(byteArray)) {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = memoryStream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    return image;
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"画像の読み込みに失敗しました: {ex.Message}");
                return null;
            }
        }
    }
}
