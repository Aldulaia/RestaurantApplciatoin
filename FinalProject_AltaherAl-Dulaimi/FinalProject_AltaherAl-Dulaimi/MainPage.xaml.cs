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
using Windows.UI.Xaml.Media.Animation;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalProject_AltaherAl_Dulaimi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Gobal Sql Connection
        const string connectionString = "Server=(local);Database=Spring2021Exam;User=PapaDario;Password=12345"; 
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;

        public MainPage()
        {
            this.InitializeComponent();
            nav.OpenPaneLength = 230;
        }
        protected string myName = "Altaher"; // test purposes
        //User u = new User();


        // Navigation View
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Page6));
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "Papa Dario Pizza Store";
        }

        // Navigation View default
        private async void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            
            // Firch check the selected item is settings
            if (args.IsSettingsSelected)
            {
                // Launch computer settings when clicked
                 await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:home")); 
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {

                    case "Page1":
                        ContentFrame.Navigate(typeof(Page1), null, new DrillInNavigationTransitionInfo());
                        break;

                    case "Page2":
                        ContentFrame.Navigate(typeof(Page2), null, new DrillInNavigationTransitionInfo());
                        Debug.WriteLine(User.getUserInfo());
                        Debug.WriteLine(User.getFirstLateName());

                        break;

                    case "Page3":
                        ContentFrame.Navigate(typeof(Page3));
                        break;

                    case "Page4":
                        ContentFrame.Navigate(typeof(Page4));
                        break;

                    case "Page5":
                        ContentFrame.Navigate(typeof(Page5));
                        break;

                    case "Page6":
                        ContentFrame.Navigate(typeof(Page6));
                        break;

                    case "Page7":
                        ContentFrame.Navigate(typeof(Page7));
                        break;

                }
            }
        }

        // Connect
        public static void SqlConnection()
        {

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                Debug.WriteLine(sqlConn.State.ToString());
            }


        }

        // insert
        public void tryOut()
        {

             // when the form loads
            conn.ConnectionString = connectionString;

            // command object to excute our query
            cmd = conn.CreateCommand();

            try
            {
                string query = "INSERT into [dbo].[user] VALUES('" 
                        + myName + "')";
                Debug.WriteLine("before cmd Query");
                cmd.CommandText = query;
                Debug.WriteLine("After cmd Query");
                conn.Open(); // if password , or userName are wrong. Throws error here.  

                Debug.WriteLine("before EXECUTE");
                cmd.ExecuteScalar();
                Debug.WriteLine("AFTER EXECUTE");
                Debug.WriteLine("Flight Added Successfully");

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("The throwed error is: " + ex);
            }
            finally
            {
                // always executed
                cmd.Dispose(); // freze up resources (Memory)
                conn.Close(); // close connection            
            }

        }




    }
}