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
using System.Data;
using System.Diagnostics;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject_AltaherAl_Dulaimi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page6 : Page
    {
        public Page6()
        {
            this.InitializeComponent();
        }

        const string connectionString = "Server=(local);Database=Spring2021Exam;User=PapaDario;Password=12345";
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;


        Random randomNumber = new Random(); // Random Pirce Day
        Order orderObj = new Order(); // New order Object
        //Tools tool = new Tools();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            string guestTempName;
            if (Login.getLogIn())
            {
                //guestTempName = User.getUserInfo();
                guestTempName = User.getFirstLateName();
                // txtbGuestName.IsEnabled = false;
            }
            else {

                guestTempName = "Guest";
            }
            // Test
            //Debug.WriteLine(orderObj.topping + " " + orderObj.specialEdition + " " + orderObj.sauce + " " + comboBox1.SelectedItem + " ");


            //int randNum = randomNumber.Next(10, 16); // 0, 1, 2

            string guestName = guestTempName;
            string topping = "Pepperoni and Hawaiian";
            string size = "Two Big Combo" ;
            string pickupTime = "Upon Conformation";
            string specialEdition = "Two Cola Cans ";
            string sauce = "Barbecue Sauce";
            double price = 20;

            const double fanDiscount = 0.10; // Fan Members Discount

            Debug.WriteLine(" The price Before Dis " + price);
            if (Login.getLogIn())
            { // Fan club Discount
                double tempDis = 20 * fanDiscount;
                price = price - tempDis;
            }
            Debug.WriteLine(" The price after Dis " + price);




            if ((guestName.Trim() == "") || (size.Trim() == "") || (pickupTime.Trim() == "") || (topping.Trim() == "") || (specialEdition.Trim() == "") || (sauce.Trim() == ""))
            {
                ContentDialog noWifiDialog = new ContentDialog
                {
                    Title = "Guest Name, Size, and Pick up Time!",
                    Content = "Please Enter Full Data!  ",
                    CloseButtonText = "Ok"
                };
                ContentDialogResult result = await noWifiDialog.ShowAsync();
                return; // pause the app
            }
            else
            {


                conn.ConnectionString = connectionString;
                cmd = conn.CreateCommand();
                try
                {
                    string query = "INSERT into [dbo].[order] VALUES('"
                        + guestName.ToUpper() + "','"
                        + topping.ToUpper() + "','"
                        + size.ToUpper() + "','"
                        + pickupTime.ToUpper() + "','"
                        + specialEdition.ToUpper() + "','"
                        + sauce.ToUpper() + "','"
                        + price + "')";

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();

                    if (Login.getLogIn())
                    {
                        btnOrderNow.IsEnabled = false;
                        ContentDialog noWifiDialog = new ContentDialog
                        {
                            Title = " Congrats, Order Successfully Placed!",
                            Content = "  Receipt Print, Please hold on your receipt PLUS %10 Discount !  ",
                            CloseButtonText = "Accept Discount"
                        };
                        ContentDialogResult result = await noWifiDialog.ShowAsync();
                        
                       

                    }
                    else
                    {
                        btnOrderNow.IsEnabled = false;
                       
                        ContentDialog noWifiDialog = new ContentDialog
                        {
                            Title = " Congrats, Order Successfully Placed!",
                            Content = "  Receipt Print, Please hold on your receipt!  ",
                            CloseButtonText = "Ok"
                        };
                        ContentDialogResult result = await noWifiDialog.ShowAsync();
                    }

                    Debug.WriteLine("Before Print");
                    Tools tool = new Tools();
                   
                    Debug.WriteLine("After Print");


                }
                catch (Exception es)
                {
                    Debug.WriteLine("The exception thrown is: " + es);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();

                }

            }
        }
    }
}
