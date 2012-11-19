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
    /// Interaction logic for Installment_Bill.xaml
    /// </summary>
    public partial class Installment_Bill : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Data\Profile.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        String inst_count="";
        public Installment_Bill()
        {
            InitializeComponent();
        }
        private void button_press0(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(string.Format("You clicked on the {0}", (sender as Button).Name));
            String button = (sender as Button).Name;

            new Installment_Bill_Process(install_ID.Text,invest_period.Text,invest_money.Text,inst_count,button).Show();

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

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ListBox listBox1 = new ListBox();
            listBox1.Name = "listBox1";
            listBox1.Background = null;
            listBox1.BorderBrush = new SolidColorBrush(Colors.Yellow);
            listBox1.BorderThickness = new Thickness(1);
           
            if (Cust_id.Text.Length != 0)
            {
                Cust_name.Text = string.Empty;
                Cust_name.IsReadOnly = false;

                SqlConnection Conn = new SqlConnection(connectionString);

                // Open the Database Connection
                Conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Gold_Investment where Customer_ID like '" + Cust_id.Text + "'", Conn);
                SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
                if (reader.HasRows)
                {
                    Cust_name.Text = reader.GetString(0);
                    textBox1.Text = reader.GetString(1);
                    invest_period.Text = reader.GetString(3);
                    invest_money.Text = reader.GetString(5);
                    install_ID.Text = reader.GetString(6);
                    inst_count = reader.GetString(9);

                    Cust_name.IsReadOnly = true;
                    textBox1.IsReadOnly = true;
                    invest_period.IsReadOnly = true;
                    invest_money.IsReadOnly = true;
                    install_ID.IsReadOnly = true;

                    if (gd1.Children.Count > 0)
                    {
                        gd1.Children.RemoveAt(0);
                    }
                    gd1.Children.Add(listBox1);
                    
                     //Dynamic button creation
                    int drk=int.Parse(inst_count);
                      Button[] btn = new Button[int.Parse(invest_period.Text)+1];
                      for (int i = 1; i < int.Parse(invest_period.Text) + 1; i++)
                      {
                          btn[i] = new Button();
                          btn[i].Name = "bill_" + i;
                          btn[i].Height = 30;

                          btn[i].Content = "Installment " + i;
                          if (drk-- > 0)
                          {
                              btn[i].Background = new SolidColorBrush(Colors.Brown);
                              btn[i].Foreground = new SolidColorBrush(Colors.White);
                          }
                          else
                          {
                              btn[i].IsEnabled = false;
                          }
                          if (i == (int.Parse(inst_count)+1))
                          {
                              btn[i].Background = new SolidColorBrush(Colors.Orange);
                              btn[i].Foreground = new SolidColorBrush(Colors.Black);
                              btn[i].IsEnabled = true;
                          }
                          listBox1.Items.Add(btn[i]);
                          listBox1.Items.Add("     ");
                         
                          // Children.Add(btn[i]);
                          String tmp = "button_press" + i;
                          btn[i].Click += new RoutedEventHandler(button_press0);
                      }

                }
                else
                {
                    Cust_name.IsReadOnly = false;
                    textBox1.IsReadOnly = false;
                    invest_period.IsReadOnly = false;
                    invest_money.IsReadOnly = false;
                    install_ID.IsReadOnly = false;
                   
                    Cust_name.Text = String.Empty;
                    textBox1.Text = String.Empty;
                    invest_period.Text = String.Empty;
                    invest_money.Text = String.Empty;
                    install_ID.Text = String.Empty;

                    if (gd1.Children.Count > 0)
                    {
                        gd1.Children.RemoveAt(0);
                    }
                    MessageBox.Show("Customer with this ID does not exist");
                }
                
               
                
                Conn.Close();
            }
        }

        private void RootWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Cust_date.Text = System.DateTime.Now.Date.ToString().Split(' ')[0];
            Cust_id.Focus();
        }
    }
}
