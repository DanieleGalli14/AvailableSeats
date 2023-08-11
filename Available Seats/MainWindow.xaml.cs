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

namespace Available_Seats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int leftButton = 0;
        private static int rightButton = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SayHello(object sender, RoutedEventArgs e)
        {
            Button button1 = (Button)sender;
            bool isLeft = bool.Parse(button1.CommandParameter.ToString());
            int? count = isLeft ? ++leftButton : ++rightButton;
            button1.Content = count;
            
            Console.WriteLine("{0}. Hello", count);
        }
    }
}
