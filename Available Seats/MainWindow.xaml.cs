using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Available_Seats
{
    public partial class MainWindow : Window
    {
        private int _leftButton = 10;
        public int LeftButton
        {
            get { return _leftButton; }
            set { _leftButton = value; OnPropertyChanged(); }
        }
        private int _rightButton = 10;
        public int RightButton
        {
            get { return _rightButton; }
            set { _rightButton = value; OnPropertyChanged(); }
        }

        private int MaxLeft;
        private int MaxRight;

        public MainWindow()
        {
            DataContext = this;
            WindowState = WindowState.Maximized;
            string[] lines = File.ReadAllLines(@"files/list.txt");

            foreach (string line in lines)
            {
                if(line.Split(' ')[0].Equals("Red"))
                {
                    LeftButton = MaxLeft = int.Parse(line.Split(' ')[1]);
                }
                else
                {
                    RightButton = MaxRight = int.Parse(line.Split(' ')[1]);
                }
            }
            InitializeComponent();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SayHello(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = new TextBlock();
            Button button1 = (Button)sender;
            bool isLeft = bool.Parse(button1.CommandParameter.ToString());
            int count;

            count = isLeft ? (++LeftButton) : (++RightButton);
            textBlock.Text = count.ToString();
            textBlock.Style = (Style)Resources["TextStyle"];
            button1.Content = textBlock;

            Console.WriteLine("{0} has been pressed {1} times", button1.Name, count);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                if (LeftButton > 0)
                {
                    TextBlock current = (TextBlock)FindName("btnRed");
                    TextBlock output = new TextBlock();
                    output.Text = (--LeftButton).ToString();
                    current.Text = output.Text;

                    Console.WriteLine("Button Red has been pressed {0} times", LeftButton);
                }
                else
                {
                    Console.WriteLine("Button Red reached zero");
                }
            }
            
            if(e.Key == Key.J)
            {
                if(RightButton > 0)
                {
                    TextBlock current = (TextBlock)FindName("btnGreen");
                    TextBlock output = new TextBlock();
                    output.Text = (--RightButton).ToString();
                    current.Text = output.Text;

                    Console.WriteLine("Button Green has been pressed {0} times", RightButton);
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
