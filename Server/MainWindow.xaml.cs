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
using System.Windows.Shapes;
using System.Net;
namespace Server

{
    /// <summary>
    /// Interaction logic for server.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SimpleTcpServer server1;

        private void Server_Load(object sender, EventArgs e)
        {
            server1 = new SimpleTcpServer();
            server1.Delimiter = 0x13;
            server1.DataReceived += Server_DataReceived;


        }
        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtstatus.Dispatcher.Invoke((Action)delegate ()
            {
                txtstatus.Text += e.MessageString;
                e.ReplyLine(string.Format("you said: {0}", e.MessageString));
            });






        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtstatus.Text = "Server starting...\n";
            IPAddress ip = IPAddress.Parse(txthost.Text);
            server1.Start(ip, Convert.ToInt32(txtport.Text));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (server1.IsStarted)
                server1.Stop();
        }

        
    }
    }
    


