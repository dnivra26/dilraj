using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Cust_IDCard.xaml
    /// </summary>
    public partial class Cust_IDCard : Window
    {
        public Cust_IDCard()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Data\Profile.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            Conn.Open();
            SqlCommand cmd = new SqlCommand("select Cust_Name,Cust_ID,Cust_profile_create FROM Customer_Profile order by Cust_ID desc", Conn);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            name.Content = reader.GetString(0);
            id.Content = reader.GetString(1);
            doj.Content = reader.GetString(2);
            Conn.Close();
        }
    }
}
