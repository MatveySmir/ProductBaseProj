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
using System.Windows.Shapes;
using WpfApp2.Base;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Trade1Entities1 DataBase;
        private int count;
        public Authorization()
        {
            InitializeComponent();
            try
            {
                DataBase = new Base.Trade1Entities1();
            }
            catch {
                MessageBox.Show("Не удалось подключиться к базе данных.","Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }

        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            Base.User User = DataBase.User.SingleOrDefault(U=>U.UserLogin==LoginTextBox.Text && U.UserPassword == PasswordTextBox.Text);
            if (User != null)
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else {
                MessageBox.Show("Введите правильный логин/пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                count++;
                if(count > 1)
                {
                    Captcha window = new Captcha(count);
                    window.ShowDialog();
                    count = 1;
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотете завершить программу?", "Выход", MessageBoxButton.OKCancel, MessageBoxImage.Information)==MessageBoxResult.OK)
            {
                this.Close();
            }
        }
    }
}
