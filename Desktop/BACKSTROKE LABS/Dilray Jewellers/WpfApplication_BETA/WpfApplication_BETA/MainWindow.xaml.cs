using System;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cust_id;
        string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Data\Profile.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        string imageUrl = "";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Cust_date.Text = System.DateTime.Now.Date.ToString().Split(' ')[0];

            SqlConnection Conn = new SqlConnection(connectionString);
            Conn.Open();
            SqlCommand cmd = new SqlCommand("select Cust_ID FROM Customer_Profile order by Cust_ID desc", Conn);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();  
            cust_id = reader.GetString(0);
            Conn.Close();

            int id = int.Parse(cust_id.Split('#')[1]);
            Cust_id.Text = "#" + ++id;
        }
        
        private void image1_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

            imageUrl = Environment.CurrentDirectory + Cust_name.Text + ".jpg";
            //  Process.Start(@"E:\Backstroke Proj\CODING\Camera code\WindowsFormsApplication2\bin\Debug\WindowsFormsApplication2.exe",imageUrl);

            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            
            string url=  Environment.CurrentDirectory + "\\" + "camera" + "\\" + "WindowsFormsApplication2.exe";
            MessageBox.Show(url);
            p.StartInfo.FileName = url;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = imageUrl;
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            ImageSourceConverter converter = new ImageSourceConverter();
            image1.Source = (ImageSource)converter.ConvertFromString(imageUrl);
        }

        private void richTextBox1_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            string s = Environment.CurrentDirectory;
          
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string gender = null;
            try
            {
                
                  SqlConnection _Conn = new SqlConnection(connectionString);
                   _Conn.Open();

                   string authen=null;
                   for (int i = 0; i < listBox1.Items.Count; i++)
                   {
                       authen += listBox1.Items.GetItemAt(i).ToString()+"|/|";
                   }

                   if (radioButton1.IsChecked == true)
                   {
                       gender = "M";
                   }
                   else if (radioButton2.IsChecked == true)
                   {
                       gender = "F";
                   }
                // Command String
                string _Insert = @"insert into Customer_Profile
                               (Cust_Name,Cust_ID,Cust_address,Cust_landline,Cust_mobile,
                                Cust_email,Cust_auth,Cust_profile_create,gender,cust_refer)
                               Values('" + Cust_name.Text + "','" + Cust_id.Text + "','" +
                                         Cust_address.Text + "','" + Cust_land_1.Text+"-"+Cust_land_2.Text + "','" +
                                         Cust_mobile.Text + "','" + Cust_email.Text + "','" +
                                         authen + "','" + Cust_date.Text + "','" + 
                                         gender + "','" + Cust_Refer.Text + "')";
              
                  SqlCommand _cmd = new SqlCommand(_Insert, _Conn);
                  _cmd.ExecuteNonQuery();

                MessageBox.Show("One Record Inserted");
                MainWindow mw = new MainWindow();
                this.Close();
                mw.Show();

                Cust_IDCard card = new Cust_IDCard();
                card.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void button5_Click(object sender, RoutedEventArgs e)
        {
            
          /*  SqlConnection _Conn = new SqlConnection(connectionString);
            _Conn.Open();
            string _update = @"update Gold_Investment_Bill set Bill_ID='#I201_B1' where Installment_ID='#I201' ";
             string _Insert = @"alter table Gold_Investment add Installment_Count varchar(50)" ;
                 SqlCommand _cmd = new SqlCommand(_update, _Conn);
                  _cmd.ExecuteNonQuery();
                  _Conn.Close();
           * */
                  if (textBox9.Text.Length != 0)
                  {
                      listBox1.Items.Add(textBox9.Text);
                      textBox9.Text = string.Empty;
                  }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Text documents (.txt)|*.txt|PDF (.pdf)|*.pdf|All Files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                textBox7.Text = filename;
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

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Installment_Bill ib = new Installment_Bill();
            this.Close();
            ib.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _Conn = new SqlConnection(connectionString);
            _Conn.Open();
            string _update = @"update Gold_Investment_Bill set Bill_ID='#I201_B1' where Installment_ID='#I201' ";
            string _Insert = @"alter table Gold_Investment add Installment_Count varchar(50)";
            string del = @"delete from Gold_Investment_Bill";
            SqlCommand _cmd = new SqlCommand(del, _Conn);
            _cmd.ExecuteNonQuery();
            del = @"delete from Gold_Investment";
            _cmd = new SqlCommand(del, _Conn);
            _cmd.ExecuteNonQuery();
            _Conn.Close();
        }


    }

}
