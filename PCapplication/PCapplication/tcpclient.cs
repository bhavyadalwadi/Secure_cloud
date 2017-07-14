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
    public partial class tcpclient : Form
    {
        public tcpclient()
        {
            InitializeComponent();
        }

        private void client_Load(object sender, EventArgs e)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[2048];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("192.168.65.128");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                Socket senderr = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    senderr.Connect(remoteEP);

                    MessageBox.Show("Socket connected to {0}",
                        senderr.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes("SELECT COUNT(*) FROM usermain WHERE userid='boneyp003' AND password='boneyp003'  ");

                    // Send the data through the socket.
                    int bytesSent = senderr.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = senderr.Receive(bytes);
                    MessageBox.Show("Echoed test = {0}\n"+Encoding.ASCII.GetString(bytes, 0, bytesRec)+" ");

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
