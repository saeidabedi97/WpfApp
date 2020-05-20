using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=S4INT\SQLEXPRESS; initial catalog=wpfDB; integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();


                String query = "SELECT COUNT(1) FROM usertbl WHERE username=@username AND password=@password";


                    SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@username", txtusername.Text);
                sqlcmd.Parameters.AddWithValue("@password", txtpassword.Password);

                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());

                if (count == 1)
                {

                    MainWindow dashboard = new MainWindow(txtusername.Text);
                    dashboard.Show();
                    this.Close();

                }
                else {
                    MessageBox.Show("Username or password is incorrect");
                
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
    
}
