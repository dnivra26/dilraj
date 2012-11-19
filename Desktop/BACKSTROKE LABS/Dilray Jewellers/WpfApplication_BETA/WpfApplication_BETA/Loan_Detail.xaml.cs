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
using System.Configuration;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Loan_Detail.xaml
    /// </summary>
    public partial class Loan_Detail : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Data\Profile.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Loan_Detail()
        {
            InitializeComponent();
           
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (Cust_id.Text.Length != 0)
            {
                Cust_name.Text = string.Empty;
                Cust_address.Text = string.Empty;
                Cust_name.IsReadOnly = false;
                Cust_address.IsReadOnly = false;
                Cust_gender.Content = string.Empty;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.Items.RemoveAt(i);
                }
                SqlConnection Conn = new SqlConnection(connectionString);

                // Open the Database Connection
                Conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Cust_Name,Cust_address,Cust_auth,gender FROM Customer_Profile where Cust_ID like '" + Cust_id.Text + "'", Conn);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                if (reader.HasRows)
                {
                    Cust_name.Text = reader.GetString(0);
                    String auth = reader.GetString(2);
                    listBox1.Items.Add(auth);
                    Cust_address.Text = reader.GetString(1);
                    if (reader.GetString(3).Equals("M"))
                    {
                        Cust_gender.Content = "Male";
                    }
                    else if (reader.GetString(3).Equals("F"))
                    {
                        Cust_gender.Content = "Female";
                    }
                    Cust_name.IsReadOnly = true;
                    Cust_address.IsReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Customer with this ID does not exist");
                }

                Conn.Close();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Cust_Profile_View cpv = new Cust_Profile_View();
            this.Close();
            cpv.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cust_date.Text = System.DateTime.Now.Date.ToString().Split(' ')[0];
        }
    }
}
