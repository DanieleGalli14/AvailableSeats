using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Available_Seats
{
    public partial class MainWindow : Window
    {
        private static int leftButton = 10;
        private static int rightButton = 10;
        
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();

        }

        public void SayHello(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = new TextBlock();
            Button button1 = (Button)sender;
            bool isLeft = bool.Parse(button1.CommandParameter.ToString());
            int count;

            count = isLeft ? (++leftButton) : (++rightButton);
            textBlock.Text = count.ToString();
            textBlock.Style = (Style)Resources["TextStyle"];
            button1.Content = textBlock;

            Console.WriteLine("{0} has been pressed {1} times", button1.Name, count);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                if (leftButton > 0)
                {
                    TextBlock current = (TextBlock)FindName("btnRed");
                    TextBlock output = new TextBlock();
                    output.Text = (--leftButton).ToString();
                    current.Text = output.Text;

                    Console.WriteLine("Button Red has been pressed {0} times", leftButton);
                }
                else
                {
                    Console.WriteLine("Button Red reached zero");
                }
            }
            
            if(e.Key == Key.J)
            {
                if(rightButton > 0)
                {
                    TextBlock current = (TextBlock)FindName("btnGreen");
                    TextBlock output = new TextBlock();
                    output.Text = (--rightButton).ToString();
                    current.Text = output.Text;

                    Console.WriteLine("Button Green has been pressed {0} times", leftButton);
                }
                else
                {
                    Console.WriteLine("Button Green reached zero");
                }
            }

            if (e.Key == Key.Escape)
            {
                Close();
            }
            
        }
    }
}
