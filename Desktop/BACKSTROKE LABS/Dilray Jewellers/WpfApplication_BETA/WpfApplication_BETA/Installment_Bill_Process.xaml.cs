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
    /// Interaction logic for Installment_Bill_Process.xaml
    /// </summary>
    public partial class Installment_Bill_Process : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Data\Profile.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Installment_Bill_Process(String a,String b,String c,String d,String button)
        {
            InitializeComponent();
            float amt = float.Parse(c) / float.Parse(b);
            install_amount.Text = amt+"";
            install_ID.Text = a;

            int cnt = int.Parse(button.Split('_')[1]);
            SqlConnection Conn = new SqlConnection(connectionString);
            Conn.Open();
            SqlCommand cmd = new SqlCommand("select * FROM Gold_Investment_Bill where Bill_ID like '" + a+"_B"+cnt + "'", Conn);
           // MessageBox.Show("select * FROM Gold_Investment_Bill where Bill_ID like '" + a + "_B" + cnt + "'");
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                label9.Content = "Paid On";
                install_amount.Visibility = Visibility.Hidden;
                bill_id.Text = reader.GetString(0);
                label4.Content = reader.GetString(3);
                textBox1.Text = reader.GetString(2);
                textBox1.IsReadOnly = true;
                button2.IsEnabled = false;
            }
            bill_id.Text = a + "_B" + cnt;
            install_count.Text = cnt + "";
            Conn.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String date = System.DateTime.Now.Date.ToString().Split(' ')[0]; ;
                SqlConnection Conn = new SqlConnection(connectionString);

                // Open the Database Connection
                Conn.Open();
                string Insert = @"insert into Gold_Investment_Bill
                               (Bill_ID,Installment_ID,Amount_Paid,
                                Paid_on)
                               Values('" + bill_id.Text + "','" + install_ID.Text + "','" +
                                           textBox1.Text + "','" +
                                           date + "')";
                MessageBox.Show(Insert);
                SqlCommand cmd = new SqlCommand(Insert, Conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("One Record Inserted");
        
                string update = @"update Gold_Investment set Installment_Count='" + install_count.Text + "' where Installment_ID='" + install_ID.Text + "' ";
                cmd = new SqlCommand(update, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
