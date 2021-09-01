using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace FinalProject_AltaherAl_Dulaimi
{
    class Order
    {
        public string guestname { get; set; }
        public string topping { get; set; }
        public string size { get; set; }
        public string pickupTime { get; set; }
        public string specialEdition { get; set; }
        public string sauce { get; set; }
        public double price { get; set; }

        public static StringBuilder s = new StringBuilder();

        public void defaultValues() {

            topping = "None";
            specialEdition = "None";
            sauce = "None";
        }

        public void receiptBuilder(string guestname, string topping, string size, string pickupTime, string specialEdition, string sauce, double price) {


            s.AppendLine("Receipt Information");
            s.AppendLine("- - - - - - - - -");
            s.AppendLine("Guest Name: " + guestname);
            s.AppendLine("Topping: " + topping);
            s.AppendLine("size: " + size);
            s.AppendLine("Pickup Time: " + pickupTime);
            s.AppendLine("Special Edition: " + specialEdition);
            s.AppendLine("Sauce: " + sauce);
            s.AppendLine("Price: " +"$"+ price);

            Debug.WriteLine(s.ToString());

        }
    }
}
