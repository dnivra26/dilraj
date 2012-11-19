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
    /// Interaction logic for Investment_Main.xaml
    /// </summary>
    public partial class Investment_Main : Window
    {
        string connectionString_profile = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Data\Profile.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        float gold_amt;
        float gold_rate;
        float install_amt;
        float install_period;
        float install_amt_month;
        public Investment_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            gold_amt = float.Parse(gold_amount.Text);
            gold_rate = 2953;
            install_amt = gold_amt * gold_rate;
            install_period = int.Parse(invest_period.Text);
            install_amt_month = install_amt / install_period;

            invest_money.Text = "Rs. "+install_amt.ToString();
            invest_per_month.Text = "Rs. " +install_amt_month.ToString();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (Cust_id.Text.Length != 0)
            {
                Cust_name.Text = string.Empty;
                Cust_name.IsReadOnly = false;
                Cust_gender.Content = string.Empty;

                SqlConnection Conn = new SqlConnection(connectionString_profile);

                // Open the Database Connection
                Conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Cust_Name,gender FROM Customer_Profile where Cust_ID like '" + Cust_id.Text + "'", Conn);
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                if (reader.HasRows)
                {
                    Cust_name.Text = reader.GetString(0);
                    if (reader.GetString(1).Equals("M"))
                    {
                        Cust_gender.Content = "Male";
                    }
                    else if (reader.GetString(1).Equals("F"))
                    {
                        Cust_gender.Content = "Female";
                    }
                    Cust_name.IsReadOnly = true;
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

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Loan_Detail ld = new Loan_Detail();
            this.Close();
            ld.Show();
            /*  Cust_IDCard card = new Cust_IDCard();
            card.Show();*/
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Investment_Main im = new Investment_Main();
            this.Close();
            im.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cust_date.Text = System.DateTime.Now.Date.ToString().Split(' ')[0];
            textBox1.Text = Cust_date.Text;

            SqlConnection Conn = new SqlConnection(connectionString_profile);
            Conn.Open();
            SqlCommand cmd = new SqlCommand("select Installment_ID FROM Gold_Investment order by Installment_ID desc", Conn);
            SqlDataReader reader = cmd.ExecuteReader();
            String inst_id="#I200";
            if (reader.Read())
            {
                 inst_id= reader.GetString(0);
            }
            Conn.Close();

            int id = int.Parse(inst_id.Split('I')[1]);
            install_ID.Text = "#I" + ++id;
            Cust_id.Focus();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection Conn = new SqlConnection(connectionString_profile);

                // Open the Database Connection
                Conn.Open();
                  string _Insert = @"insert into Gold_Investment
                               (Customer_ID,Booking_Date,Gold_Amount,Installment_Period,Gold_Rate,
                                Installment_Amount,Installment_ID,Interest,Installment_Count)
                               Values('" + Cust_id.Text + "','" + textBox1.Text + "','" +
                                             gold_amount.Text + "','" + invest_period.Text + "','" + 
                                             gold_rate.ToString() + "','" +
                                             install_amt.ToString() + "','" + install_ID.Text + "','"
                                             + interest.Text + "','0')";
                //  MessageBox.Show(_Insert);
                  SqlCommand _cmd = new SqlCommand(_Insert, Conn);
                  _cmd.ExecuteNonQuery();

                  MessageBox.Show("One Record Inserted");
                  Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
