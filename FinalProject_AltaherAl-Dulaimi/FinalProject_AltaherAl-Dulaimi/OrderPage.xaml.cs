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
using System.Diagnostics;

using System.Data.SqlClient;
using System.Data;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject_AltaherAl_Dulaimi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public Page1()
        {
            this.InitializeComponent();

            // After Loading
            

            //Build a list
            var dataSource = new List<Size>();
            dataSource.Add(new Size("14") { size = "14" });
            dataSource.Add(new Size("12") { size = "12" });
            dataSource.Add(new Size("8") { size = "8" });


            if (Login.getLogIn()) {
                lblHi.Text += "'" +User.getUserInfo() + "'";
                txtbGuestName.Text = User.getFirstLateName();
                txtbGuestName.IsEnabled = false;
                //comboBox1.SelectedValue = "8";
            }

        }

        const string connectionString = "Server=(local);Database=Spring2021Exam;User=PapaDario;Password=12345";
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;


        Random randomNumber = new Random(); // Random Pirce Day
        Order orderObj = new Order(); // New order Object
        //Tools tool = new Tools();




        // First Three Check Boxes
        private void chkExtraChesse(object sender, RoutedEventArgs e)
        {
            chkboxPepperoni.IsEnabled = false;
            chkboxGreenPeppers.IsEnabled = false;
            orderObj.topping = "Extra Chesse";

        }
        private void chkExtraChesse_Unchecked(object sender, RoutedEventArgs e)
        {
            chkboxPepperoni.IsEnabled = true;
            chkboxGreenPeppers.IsEnabled = true;
            orderObj.topping = "None";
        }

        private void chkPepperoni(object sender, RoutedEventArgs e)
        {
            chkboxGreenPeppers.IsEnabled = false;
            chkboxExtraChesse.IsEnabled = false;
            orderObj.topping = "Pepperoni";

        }
        private void chkPepperoni_Unchecked(object sender, RoutedEventArgs e)
        {
            chkboxGreenPeppers.IsEnabled = true;
            chkboxExtraChesse.IsEnabled = true;
            orderObj.topping = "None";
        }

        private void chkGreenPeppers(object sender, RoutedEventArgs e)
        {
            chkboxExtraChesse.IsEnabled = false;
            chkboxPepperoni.IsEnabled = false;
            orderObj.topping = "Green Peppers";

        }
        private void chkGreenPeppers_Unchecked(object sender, RoutedEventArgs e)
        {
            chkboxExtraChesse.IsEnabled = true;
            chkboxPepperoni.IsEnabled = true;
            orderObj.topping = "None";
        }

        // Gulab Checked
        private void chkGulabJamuns(object sender, RoutedEventArgs e)
        {
            orderObj.specialEdition = "Gulab Jamuns";
        }
        private void chkGulabJamuns_unchecked(object sender, RoutedEventArgs e)
        {
            orderObj.specialEdition = "None";
        }

        // last two check boxes
        private void chkSpicyRedSauce(object sender, RoutedEventArgs e)
        {
            SweetPizzaSauce.IsEnabled = false;
            orderObj.sauce = "Spicy Red Sauce";
        }

        private void chkSweetPizzaSauce(object sender, RoutedEventArgs e)
        {
            SpicyRedSauce.IsEnabled = false;
            orderObj.sauce = "Sweet Pizza Sauce";
        }

        private void chkSpicyRedSauce_unchecked(object sender, RoutedEventArgs e)
        {
            SweetPizzaSauce.IsEnabled = true;
            orderObj.sauce = "None";
        }

        private void chkSweetPizzaSauce_unchecked(object sender, RoutedEventArgs e)
        {
            SpicyRedSauce.IsEnabled = true;
            orderObj.sauce = "None";
        }




        // Place order button
        private async void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            // Test
            Debug.WriteLine(orderObj.topping + " " + orderObj.specialEdition + " " + orderObj.sauce +" "+ comboBox1.SelectedItem + " " );
            // initiate variable
            string guestName = "";
            string topping = "";
            string size = "";
            string pickupTime = "";
            string specialEdition = "";
            string sauce = "";
            double price = 0;

            int randNum = randomNumber.Next(10, 16); // 0, 1, 2

             guestName = txtbGuestName.Text;
             topping = orderObj.topping;
             size = comboBox1.SelectedItem.ToString();
             pickupTime = txtbPickTime.Text;
             specialEdition = orderObj.specialEdition;
             sauce = orderObj.sauce;
             price = randNum;

            const double fanDiscount = 0.10; // Fan Members Discount

            Debug.WriteLine(" The price Before Dis " + price);
            if (Login.getLogIn()) { // Fan club Discount
                double tempDis = randNum * fanDiscount;
                price = price - tempDis;
            }
            Debug.WriteLine(" The price after Dis " + price);

            // Fill up the variables to Order object
            orderObj.guestname = guestName;
            orderObj.topping = topping;
            orderObj.size = size;
            orderObj.pickupTime = pickupTime;
            orderObj.specialEdition = specialEdition;
            orderObj.sauce = sauce;
            orderObj.price = price;
            orderObj.receiptBuilder(guestName, topping, size, pickupTime, specialEdition, sauce, price);
            

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
                    cmd.ExecuteScalar(); // Activate later

                    if (Login.getLogIn())
                    {
                        lblPrice.Text = "After Discount: " + Convert.ToString(price);
                        ContentDialog noWifiDialog = new ContentDialog
                        {
                            Title = " Congrats, Order Successfully Placed!",
                            Content = "  Receipt Print, Please hold on your receipt PLUS %10 Discount !  ",
                            CloseButtonText = "Accept Discount"
                        };
                        ContentDialogResult result = await noWifiDialog.ShowAsync();

                    }
                    else {
                        lblPrice.Text = "Without! Discount: " + Convert.ToString(price);
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
                    this.Frame.Navigate(typeof(Page4));

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
