using SimpleTCP;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SimpleTcpClient client;

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            txtstatus.Text += "server starting...";
            btn_connect.IsEnabled = false;
            client.Connect(txthost.Text, Convert.ToInt32(txtport.Text));
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;


        }

        private void Client_DataReceived(object sender, Message e)
        {
            txtstatus.Dispatcher.Invoke((Action)delegate ()
            {
                txtstatus.Text += e.MessageString;
               
            });
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            client.WriteLineAndGetReply(txtmessage.Text, TimeSpan.FromSeconds(3));
        }
    }
}
