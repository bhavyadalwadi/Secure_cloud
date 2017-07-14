using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace pubkey
{
    public partial class publistener : Form
    {
        // Incoming data from the client.
        public static string data = null;

        public publistener()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start_listening();            
        }

        public void start_listening()
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
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11001);




            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                //MessageBox.Show("listening");
                label1.Text = "listening";
                // Start listening for connections.
                while (true)
                {
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

                    data = data.Substring(0, data.IndexOf("  "));
                    //data.Substring(
                    // Show the data on the console.
                    //MessageBox.Show("Text received : {0} \n email = " + data + "*");
                    conn.Open();

                    cmd = conn.CreateCommand();
                    cmd = new MySqlCommand("SELECT public_key FROM  users WHERE email='" + data + "' LIMIT 1", conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();
                    string pubk = dr.GetString("public_key");
                    dr.Close();
                    conn.Close();
                    //MessageBox.Show(pubk);

                    handler.Send(Encoding.ASCII.GetBytes(pubk));
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    listener.Disconnect(true);
                }
            }

            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString());
            }
        
        }
    }
}
