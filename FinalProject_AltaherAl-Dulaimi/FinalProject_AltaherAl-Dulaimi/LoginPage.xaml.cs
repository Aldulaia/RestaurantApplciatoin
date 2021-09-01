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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject_AltaherAl_Dulaimi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page3 : Page
    {
        public Page3()
        {
            this.InitializeComponent();
            btnLogout.IsEnabled = false; // Enabled only after loging in
            if (Login.getLogIn())
            {
                loggedOut();
            }
        }
        const string connectionString = "Server=(local);Database=Spring2021Exam;User=PapaDario;Password=12345";
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;

        

        // Log-in Button
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Falgs of Log in 
            bool userFlag = false;
            bool passFlag = false;


            string username = txtbUsername.Text;
            string password = pPassword.Password.ToString();

            //username upper
            username = username.ToUpper();



            Debug.WriteLine(username + " " + password);

            if ((username.Trim() == "") || (password.Trim() == ""))
            {
                ContentDialog noWifiDialog = new ContentDialog
                {
                    Title = "Empty Fields!",
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
                    //string query = "SELECT username, password FROM [dbo].[user] WHERE username=" +"'"+ username +"'"+ " AND password=" + "'"+password+ "'" ;
                    string query = "SELECT * FROM [dbo].[user]";



                    cmd.CommandText = query;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    // Call Read before accessing data.
                    while (reader.Read())
                    {

                        if (reader.GetString(3).Equals(username))
                            userFlag = true;





                        if (reader.GetString(4).Equals(password))
                            passFlag = true;




                        if (passFlag && userFlag)
                        {
                            User.setFirstLastName(reader.GetString(1) + " " + reader.GetString(2));
                            break;
                        }




                        }


                    if (userFlag && passFlag) // Logs in
                    {
                        User.setUserInfo(username); // Holds the username
                        Login.setIsLogin(true);
                        
                        ContentDialog noWifiDialog = new ContentDialog
                        {
                            Title = "Successfully retrieved!",
                            Content = "You are officially loged in  ",
                            CloseButtonText = "Ok"
                        };
                        ContentDialogResult result = await noWifiDialog.ShowAsync();

                        //disable
                        btnLogin.IsEnabled = false;
                        txtbUsername.IsEnabled = false;
                        pPassword.IsEnabled = false;
                        btnLogout.IsEnabled = true; // Enable log out

                    }
                    else
                    {
                        ContentDialog noWifiDialog = new ContentDialog
                        {
                            Title = "Wrong Credentials!",
                            Content = "Username or Password Entered are wrong",
                            CloseButtonText = "Ok"
                        };
                        ContentDialogResult result = await noWifiDialog.ShowAsync();

                    }


                }
                catch (Exception es)
                {
                    Debug.WriteLine(es);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();

                    // refreshData(); // refresh the table without the need to click refresh button.
                }

            }
        }

        // Log-out button
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login.setIsLogin(false);
            User.setFirstLastName("");
            User.setUserInfo("");

            btnLogin.IsEnabled = true;
            txtbUsername.IsEnabled = true;
            pPassword.IsEnabled = true;
            btnLogout.IsEnabled = false; // Enable log out

            txtbUsername.Text = "";
            pPassword.Password = "";
        }

        // Method to be called when On navigate Page
        private void loggedOut() {

            btnLogin.IsEnabled = false;
            txtbUsername.IsEnabled = false;
            pPassword.IsEnabled = false;
            btnLogout.IsEnabled = true; // Enable log out

            txtbUsername.Text = "";
            pPassword.Password = "";

        }

        

    }
}
