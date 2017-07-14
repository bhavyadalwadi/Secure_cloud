using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace PCapplication
{
    public partial class Form1 : Form
    {
        public static string user = "";
        public static string pass = "";
        public static bool flag;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = textBox1.Text;
            pass = textBox2.Text;
            chk();
            if (flag)
            {
                MessageBox.Show("you have successfully logged in \nwelcome!!!");
                //valid -> enter app.
                Form2 o1 = new Form2(user);
                o1.Visible = true;
                this.Visible = false;
            }
            else 
            {
                MessageBox.Show("invalid username/password!!!");
            }
        }




        public void chk()
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[2048];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = /*Dns.Resolve("localhost").AddressList[0];*/ IPAddress.Parse("172.37.5.64");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                Socket senderr = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    senderr.Connect(remoteEP);

                    //MessageBox.Show("Socket connected to {0}",senderr.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes(""+textBox1.Text+":"+textBox2.Text+"  ");

                    // Send the data through the socket.
                    int bytesSent = senderr.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = senderr.Receive(bytes);
                    //MessageBox.Show("Echoed test = {0}\n" + Encoding.ASCII.GetString(bytes, 0, bytesRec) + " ");
                    if (Encoding.ASCII.GetString(bytes, 0, bytesRec).Equals("yes"))
                        flag = true;
                    else if (Encoding.ASCII.GetString(bytes, 0, bytesRec).Equals("no"))
                        { MessageBox.Show("wrong!!!!"); flag = false; }
                    // Release the socket.
                    senderr.Shutdown(SocketShutdown.Both);
                    senderr.Close();

                }
                catch (ArgumentNullException ane)
                {
                    MessageBox.Show("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    MessageBox.Show("SocketException : {0}", se.ToString());
                }
                catch (Exception sse)
                {
                    MessageBox.Show("Unexpected exception : {0}", sse.ToString());
                }

            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.ToString());
            }
            
        }
    }
}
