using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Clinic_Management_System
{
    public class utils
    {
        public static string hashPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] password_bytes = Encoding.ASCII.GetBytes(password);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }

        public static Dictionary<int, string> getSlots()
        {
            Dictionary<int, string> slots = new Dictionary<int, string>();
            slots.Add(1, "Slot 1: From 9:00 AM to 9:30 AM");
            slots.Add(2, "Slot 2: From 10:00 AM to 11:00 AM");
            slots.Add(3, "Slot 3: From 11:00 AM to 12:00 PM");
            slots.Add(4, "Slot 4: From 12:30 PM to 1:00 PM");
            slots.Add(5, "Slot 5: From 1:00 PM to 2:00 PM");
            slots.Add(6, "Slot 6: From 2:00 PM to 3:00 PM");
            slots.Add(7, "Slot 7: From 3:00 PM to 4:00 PM");
            slots.Add(8, "Slot 8: From 4:00 PM to 5:00 PM");
            slots.Add(9, "Slot 9: From 5:00 PM to 6:00 PM");
            slots.Add(10, "Slot 10: From 6:00 PM to 7:00 PM");
            return slots;
        }

        public static void createAdmin(string password)
        {
            SqlConnection con = new SqlConnection(Properties.Resources.connectionString);
            SqlCommand command = con.CreateCommand();

            command.CommandText = "INSERT INTO [user] (user_username, user_password) VALUES (@username, @password)";
            command.Parameters.AddWithValue("@username", "admin");
            command.Parameters.AddWithValue("@password", hashPassword(password));

            con.Open();

            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {

            }

            con.Close();
        }
    }
}
