using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject_AltaherAl_Dulaimi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page5 : Page
    {

       //const string connectionString = "Server=(local);Database=Spring2021Exam;User=PapaDario;Password=12345";
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;

        

        public Page5()
        {
            this.InitializeComponent();

            ordersHistory.ItemsSource = retreiveHistory((App.Current as App).connectionString);

        }

        private ObservableCollection<Order> retreiveHistory(string conString) {

            
                var history = new ObservableCollection<Order>();
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                try
                {
                
                 string query = "SELECT id, guest_name, topping, size, pickup_time, special_edition, sauce, price FROM [dbo].[order]";



                    cmd.CommandText = query;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        Order order = new Order();
                        Debug.WriteLine("The current ID is: " + reader.GetInt32(0));
                        Debug.WriteLine(order.guestname = reader.GetString(1));
                        order.topping = reader.GetString(2);
                        order.size = reader.GetString(3);
                        order.pickupTime = reader.GetString(4);
                        order.specialEdition = reader.GetString(5);
                        order.sauce = reader.GetString(6);
                        order.price = Convert.ToDouble(reader.GetDecimal(7));

                        history.Add(order); // stuck in the last row

                    }

                


                
                return history;

                }
                catch (Exception es)
                {
                    Debug.WriteLine(es);
                    return null;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();

                   
                }

            
        }
    }
}
