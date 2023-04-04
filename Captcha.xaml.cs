using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        private int flag;
        public Captcha(int count)
        {
            InitializeComponent();
            flag = count;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,G,K.L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";

            char[] a = { ',' }; //разделитель
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = " ";
            Random r = new Random();
            for (int i = 0; i < 6; i++) {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            CaptchaTextBox.Text = pwd;
        }

        private void Exam_Click(object sender, RoutedEventArgs e)
        {

            if (AnswerTextBox.Text == CaptchaTextBox.Text )
            {
                if (flag < 2)
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                }
                else {
                    this.Close();
                }
            }
            else {
                MessageBox.Show("Неправильно введенная каптча!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                AnswerTextBox.Text = "";
                //Thread.Sleep(10000);
            }
        }
    }
}
