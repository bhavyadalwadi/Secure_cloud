using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;

namespace PCapplication
{
    public partial class filesharingclient : Form
    {
        private static string shortFileName = "";
        private static string fileName = "";

        public filesharingclient()
        {            
            InitializeComponent();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            string ipAddress = "192.168.65.128"; //ipaddress.Text;
            int port = 5555; // int.Parse(txthost.Text);
            string fileName = txtfile.Text;
            Task.Factory.StartNew(() => SendFile(ipAddress, port, fileName, shortFileName));
            MessageBox.Show("File Sent");
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "File sharing Client";
            dlg.ShowDialog();
            txtfile.Text = dlg.FileName;
            fileName = dlg.FileName;
            shortFileName = dlg.SafeFileName;
        }

         
        public void SendFile(string remoteHostIP, int remoteHostPort, 
            string longFileName, string shortFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(remoteHostIP))
                {
                    byte[] fileNameByte = Encoding.ASCII.GetBytes(shortFileName);
                    byte[] fileData = File.ReadAllBytes(longFileName);
                    byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                    byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                    fileNameLen.CopyTo(clientData, 0);
                    fileNameByte.CopyTo(clientData, 4);
                    fileData.CopyTo(clientData, 4 + fileNameByte.Length);
                    TcpClient clientSocket = new TcpClient(remoteHostIP, remoteHostPort);
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Write(clientData, 0, clientData.GetLength(0));
                    networkStream.Close();
                }
            }
            catch
            {

            }
        }
    }
}
