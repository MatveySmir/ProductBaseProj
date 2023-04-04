using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Goods.xaml
    /// </summary>
    public partial class Goods : Window
    {
        public Base.Product Products;
        public Base.ProductManufacturers Manufacturer;
        

        public Goods()
        {
            InitializeComponent();
            DataContext = this;
            ProductListBox.ItemsSource = SourceCore.MyBase.Product.ToList();
            UpdateGrid(null);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddCahngeProduct window = new AddCahngeProduct(id);
            window.ShowDialog();
            this.Close();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                SourceCore.MyBase.Product.Remove((Base.Product)ProductListBox.SelectedItem);
                SourceCore.MyBase.SaveChanges();
                UpdateGrid(null);
            }
        }

        public void UpdateGrid(Base.Product Product)
        {
            if ((Product == null) && (ProductListBox.ItemsSource != null))
            {
                Product = (Base.Product)ProductListBox.SelectedItem;
            }
            ObservableCollection<Base.Product> product = new ObservableCollection<Base.Product>(SourceCore.MyBase.Product);
            ProductListBox.ItemsSource = product;
            ProductListBox.SelectedItem = Product;
        }
        public int id;
        private void ProductListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id = ProductListBox.SelectedIndex;
            AddCahngeProduct window = new AddCahngeProduct(id);
            window.ShowDialog();
            this.Close();
        }
    }
}
