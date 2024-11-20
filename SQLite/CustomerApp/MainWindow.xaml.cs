using CustomerApp.Objects;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImagePath = _selectedImagePath
            };

            try {
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    connection.Insert(customer);
                }
                ReadDatabase(); // ListView表示
            }
            catch (Exception ex) {
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            // ListViewで選択された顧客を取得
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択してください");
                return;
            }

            // TextBoxに入力された新しい情報を選択された顧客に適用
            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;
            selectedCustomer.ImagePath = _selectedImagePath;

            try {
                // SQLiteデータベースで更新処理
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();  // 顧客テーブルが存在しない場合に作成
                    connection.Update(selectedCustomer);  // 顧客情報の更新
                }

                // ListViewを再読み込みして更新後のデータを表示
                ReadDatabase();
            }
            catch (Exception ex) {
                MessageBox.Show($"更新中にエラーが発生しました: {ex.Message}");
            }
        }
        //ListView表示

        private void ReadDatabase() {
            try {
                using (var connection = new SQLiteConnection(App.databasePass)) {
                    connection.CreateTable<Customer>();
                    var customers = connection.Table<Customer>().ToList();

                    CustomerListView.ItemsSource = customers;
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"データベースの読み込み中にエラーが発生しました: {ex.Message}");
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);

                CustomerListView.ItemsSource = _customers;
            }
            ReadDatabase(); //ListView表示
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;
            } else {
                NameTextBox.Clear();
                PhoneTextBox.Clear();
                AddressTextBox.Clear();
            }
        }

        private void ImageDeleteButton_Click(object sender, RoutedEventArgs e) {

        }

        private void ImageSelectButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "画像ファイル|*.jpg;*.jpeg;*.png;*.bmp;*.gif";  // 画像形式を指定

            if (openFileDialog.ShowDialog() == true) {
                _selectedImagePath = openFileDialog.FileName;  // 選択した画像のパスを保存
            }
        }
    }
}
