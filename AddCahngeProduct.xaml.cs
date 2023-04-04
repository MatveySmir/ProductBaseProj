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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for AddCahngeProduct.xaml
    /// </summary>
    public partial class AddCahngeProduct : Window
    {
        private int prodId;
        public AddCahngeProduct(int id)
        {
            InitializeComponent();
            prodId = id;
            Category.ItemsSource = SourceCore.MyBase.ProductCategorys.ToList();
            Manufact.ItemsSource = SourceCore.MyBase.ProductManufacturers.ToList();
        }

        private void AddGoodButton_Click(object sender, RoutedEventArgs e)
        {
            
                var NewProduct = new Base.Product();
                NewProduct.ProductArticleNumber = Artic.Text;
                NewProduct.ProductName = Name.Text;
                NewProduct.ProductCategory = Category.SelectedIndex;
                NewProduct.ProductQuantityInStock = (int)Convert.ToInt32(Count.Text);
                NewProduct.ProductManufacturer = Manufact.SelectedIndex;
                NewProduct.ProductCost = (decimal)Convert.ToDecimal(Cost.Text);
                NewProduct.ProductDescription = Desctription.Text;
                NewProduct.ProductStatus = Status.Text;
                SourceCore.MyBase.Product.Add(NewProduct);
                SourceCore.MyBase.SaveChanges();

            Goods window = new Goods();
            window.Show();
            this.Close();
        }

       

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
    }
}
