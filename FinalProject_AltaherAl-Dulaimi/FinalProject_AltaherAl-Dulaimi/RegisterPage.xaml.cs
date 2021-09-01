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
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
        }

        // Gobal Sql Connection
        const string connectionString = "Server=(local);Database=Spring2021Exam;User=PapaDario;Password=12345";
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;

        // Register Button
        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            User userObj = new User(); // Creates a new object each click
            
            string firstname = txtbFirstName.Text;
            string lastname = txtbLastName.Text;
            string username = txtbUsername.Text;
            string password = pPassword.Password.ToString();
            const int role = 0; // A registration is only for User NOT admin
            Debug.WriteLine(firstname +" " + lastname + " " +username +" "+ password);

            if ((firstname.Trim() == "") || (lastname.Trim() == "") || (username.Trim() == "") || (password.Trim() == ""))
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
            else {
                userObj.setFirstname(firstname.ToUpper());
                userObj.setLastname(lastname.ToUpper());
                userObj.setUsername(username.ToUpper());
                userObj.setPassword(password);

                conn.ConnectionString = connectionString;
                cmd = conn.CreateCommand();
                try
                {
                    string query = "INSERT into [dbo].[user] VALUES('"
                        + userObj.getFirstname() + "','"
                        + userObj.getLastname() + "','"
                        + userObj.getUsername() + "','"
                        + userObj.getPassword() + "','"
                        + role + "')";

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();

                    ContentDialog noWifiDialog = new ContentDialog
                    {
                        Title = "Successfully Registered!",
                        Content = "You are an offical fan of the Club!  ",
                        CloseButtonText = "Ok"
                    };
                    ContentDialogResult result = await noWifiDialog.ShowAsync();

                    // Clear Values
                    txtbFirstName.Text= "";
                    txtbLastName.Text = "";
                    txtbUsername.Text = "";
                    pPassword.Password = "";
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

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
