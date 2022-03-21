using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Messenger
{

    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            DispatcherTimer timer;
            InitializeComponent();
            timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 5) }; // 1 секунда
            timer.Tick += Timer_TickAsync;
            timer.Start();
        }
        static string path = @"\\192.168.0.131\студент_доступ\!!!!!!!!ИСиП\ИСиП 21-11-3\♦♣♥♠\Messenger.txt";
        string paneltext = "";
        string fileName = "Messenger.txt";
        private async System.Threading.Tasks.Task Timer_TickAsync(object sender, object e)
        {
            panel.Clear();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    panel.Text += "\n" + line;
                    panel.ScrollToEnd();
                }
                reader.Close();
            }
        }
        public async void Reader()
        {
            panel.Clear();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                        panel.Text += "\n" + line;
                        panel.ScrollToEnd();
                }
                reader.Close();
            }
        }

        
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Reader();
          
            

        }

        
        private async void send_Click(object sender, RoutedEventArgs e)
        {
            
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteLineAsync($"{ Nickname.Text}: {Pole.Text}");
                writer.Close();
            }
            Pole.Text = "";
            Reader();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reader();
        }

        private void Nickname_TextChanged(object sender, TextChangedEventArgs e)
        {
            Pole.IsEnabled = !(String.IsNullOrEmpty(Nickname.Text) || String.IsNullOrWhiteSpace(Nickname.Text));
            
        }

        private void panel_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void scrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Messenger_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
          //  Reader();
        }

        private void Pole_TextChanged(object sender, TextChangedEventArgs e)
        {
            SendBtn.IsEnabled = !((String.IsNullOrEmpty(Pole.Text) || String.IsNullOrWhiteSpace(Pole.Text)&&!Pole.IsEnabled));
        }
    }
}
