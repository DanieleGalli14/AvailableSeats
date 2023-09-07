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

            try
            { 
               InizializeValues();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"File non trovato: {ex.FileName}\nErrore: {ex.Message}\nProcedo con la chiusura", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }

            InitializeComponent();
            SetFooter();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.D || e.Key == Key.E) 
            {

                TextBlock current = (TextBlock)FindName("btnRed");
                TextBlock output = new TextBlock();
                
                if(e.Key == Key.D && LeftButton > 0) --LeftButton;

                if (e.Key == Key.E && LeftButton < MaxLeft) ++LeftButton;

                output.Text = LeftButton.ToString();

                current.Text = output.Text;

            }

            if(e.Key == Key.J || e.Key == Key.U)
            {
                TextBlock current = (TextBlock)FindName("btnGreen");
                TextBlock output = new TextBlock();

                if (e.Key == Key.J && RightButton > 0) --RightButton;

                if (e.Key == Key.U && RightButton < MaxRight) ++RightButton;

                output.Text = RightButton.ToString();

                current.Text = output.Text;
            }


            if (e.Key == Key.Escape)
            {
                if(CloseConfirm.Confirm()) Close();
            }
            
        }

        private void InizializeValues()
        {
            string[] lines = File.ReadAllLines(@".\list.txt");

            foreach (string line in lines)
            {
                if (line.Split(' ')[0].Equals("Red"))
                {
                    LeftButton = MaxLeft = int.Parse(line.Split(' ')[1]);
                }
                else
                {
                    RightButton = MaxRight = int.Parse(line.Split(' ')[1]);
                }
            }
        }

        private void SetFooter()
        {
            TextBlock footer = (TextBlock)FindName("footerTutorial");
            footer.Text = "Come utilizzare il programma:\n" +
                          "D: diminuisce il rosso \t\t E: incrementa il rosso \n" +
                          "J: diminuisce il verde \t\t U: Incrementa il verde\n" +
                          "Esc: chiude il programma";
        }
    }
}
