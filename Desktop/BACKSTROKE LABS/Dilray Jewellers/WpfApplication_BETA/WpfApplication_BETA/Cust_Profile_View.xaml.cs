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
    /// Interaction logic for Cust_Profile_View.xaml
    /// </summary>
    public partial class Cust_Profile_View : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Data\Profile.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        public Cust_Profile_View()
        {
            InitializeComponent();
            List<string> nameList = new List<string>();
            SqlConnection Conn = new SqlConnection(connectionString);

            // Open the Database Connection
            Conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Cust_Name FROM Customer_Profile", Conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                nameList.Add(reader.GetString(0));
            }

            Conn.Close();

           // List<string> nameList1 = new List<string> 
          //  { 
         //       "Anand","Arvind","Anandh","Sanjeev","Muthu","Ram"
         //   };
            Cust_Name.ItemsSource = nameList;
        }

       
        public void BindGrid()
        {

            SqlConnection Conn = new SqlConnection(connectionString);
            Conn.Open();
            SqlDataAdapter Adapter = new SqlDataAdapter("select * from Customer_Profile order by Cust_ID desc", Conn);

            DataTable dt = new DataTable("Customer_Profile");
            Adapter.Fill(dt);

            dataGrid1.ItemsSource = dt.DefaultView;
            Conn.Close();

        }

        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow cust = new MainWindow();
            this.Close();
            cust.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            barcode.Code = textBox1.Text;

            ImageSource img= barcode.GetBarcodeImageSource();
            image1.Source = img;
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog dlg = new System.Windows.Controls.PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Print document
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
    }
}
