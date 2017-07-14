using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace tcpserver
{
    public partial class logserver : Form
    {
        // Incoming data from the client.
        public static string data = null;
        public logserver()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[2048];

            
            //following four lines include connection to mysql server...
            string myconnstring = "Server=localhost;Database=project_database;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(myconnstring);
            MySqlCommand cmd;
            //msql server

            // Establish the local endpoint for the socket.
            // Dns.GetHostName returns the name of the 
            // host running the application.
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);


                // Start listening for connections.
                while (true)
                {
                    MessageBox.Show("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.
                    while (true)
                    {
                        bytes = new byte[1024];
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("  ") > -1)
                        {
                            break;
                        }
                    }

                    //MessageBox.Show("data received");
                    string email = data.Substring(0, data.IndexOf(':'));
                    string pass = data.Substring(data.IndexOf(':')+1,data.IndexOf("  ")-data.IndexOf(':')-1);


                    

                    // Show the data on the console.
                    //MessageBox.Show("Text received : {0} \n email = "+email+"\n password = "+pass+"*");

                    conn.Open();
                    //mysql server related code....
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM users WHERE email='" + email + "' LIMIT 1"; 
                    //MySqlDataReader reader = cmd.ExecuteReader();//here data reader fetches the data from the database.
                    int totalCount = Convert.ToInt32(cmd.ExecuteScalar());//returns the number of count recieved from the query.
                    //cmd.ExecuteNonQuery();
                    //reader.Read();
                    //String x = reader.GetString("userid");
                    //MessageBox.Show(totalCount.ToString());
                    //mysql server
                    cmd.Dispose();
                    if (totalCount == 1)
                    {
                        cmd = new MySqlCommand("SELECT * FROM  users WHERE email='" + email + "' LIMIT 1", conn);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();
                        string corrhash = dr.GetString("encrypted_password");
                        string salt = dr.GetString("salt");
                        dr.Close();

                        byte[] xxx = Encoding.UTF8.GetBytes(pass);
                        byte[] yyy = Encoding.UTF8.GetBytes(salt);


                        byte[] hashedpass = GenerateSaltedHash(xxx, yyy);
                        string xyz = Convert.ToBase64String(hashedpass);
                        xyz = xyz.Substring(0, xyz.Length - 1);

                        //MessageBox.Show("one...." + corrhash + "\ntwo...." + xyz);
                        if (CompareByteArrays(corrhash, xyz))
                        { byte[] msg = Encoding.ASCII.GetBytes("yes"); handler.Send(msg); }
                    }
                    else
                    { byte[] msg = Encoding.ASCII.GetBytes("no"); handler.Send(msg); }

                    // Echo the data back to the client.
                    //byte[] msg = Encoding.ASCII.GetBytes("yes");

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    conn.Close();
                }

            }
            catch (Exception ese)
            {
                MessageBox.Show(ese.ToString());
            }

            MessageBox.Show("\nPress ENTER to continue...");
            //Console.Read();
        }







        
        
        
        //following is the hash encryption part





        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;







        // <summary>
        // Creates a salted PBKDF2 hash of the password.
        // </summary>
        // <param name="password">The password to hash.</param>
        // <returns>The hash of the password.</returns>
        public static string CreateHash(string password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, /*PBKDF2_ITERATIONS,*/ HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }







        // <summary>
        // Validates a password given a hash of the correct one.
        // </summary>
        // <param name="password">The password to check.</param>
        // <param name="correctHash">A hash of the correct password.</param>
        // <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePassword(string password, string correctHash,string strsalt)
        {
            // Extract the parameters from the hash
            //char[] delimiter = { ':' };
            //string[] split = correctHash.Split(delimiter);
            //int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(strsalt);
            byte[] hash = Convert.FromBase64String(correctHash);

            byte[] testHash = PBKDF2(password, salt, /*iterations*/ hash.Length);
            return SlowEquals(hash, testHash);
        }







        // <summary>
        // Compares two byte arrays in length-constant time. This comparison
        // method is used so that password hashes cannot be extracted from
        // on-line systems using a timing attack and then attacked off-line.
        // </summary>
        // <param name="a">The first byte array.</param>
        // <param name="b">The second byte array.</param>
        // <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        



        // <summary>
        // Computes the PBKDF2-SHA1 hash of a password.
        // </summary>
        // <param name="password">The password to hash.</param>
        // <param name="salt">The salt.</param>
        // <param name="iterations">The PBKDF2 iteration count.</param>
        // <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        // <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(string password, byte[] salt, /*int iterations,*/ int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            //pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }


        static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA1Managed();


            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length ];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            byte[] ans = algorithm.ComputeHash(plainTextWithSaltBytes);
            
            return ans;
        }


        public static bool CompareByteArrays(string array1, string array2)
        {
            //if (array1.Length != array2.Length)
            //{
            //   return false;
            //}

            for (int i = 0; i < array2.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
