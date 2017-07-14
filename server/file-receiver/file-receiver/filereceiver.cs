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
using System.Net.NetworkInformation;
using System.IO;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace file_receiver
{
    public partial class filereceiver : Form
    {
        
        public delegate void FileRecievedEventHandler(object source, string fileName);

        public event FileRecievedEventHandler NewFileRecieved;
        public static string email = "";
        public static string fileName = "";
        public static string folderPath = "";
        
        
        public static string myconnstring = "Server=localhost;Database=project_database;Uid=root;Pwd=;";
        MySqlConnection conn = new MySqlConnection(myconnstring);
        MySqlCommand cmd;



        public filereceiver()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.NewFileRecieved += new FileRecievedEventHandler(Form1_NewFileRecieved);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
                int port = 5558; //int.Parse(hostport.Text);
                Task.Factory.StartNew(() => HandleIncomingFile(port));
                
                MessageBox.Show("Listening on port" + port);
            
        }


        public void updatedata()
        {
            try
            {
                
                conn.Open();
            }
            catch (Exception exxa)
            { MessageBox.Show(exxa.ToString()); }
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO userfile(email,filename,filepath)Values(@email,@flname,@paath)";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@flname", fileName);
                cmd.Parameters.AddWithValue("@paath", folderPath);
                cmd.ExecuteNonQuery();
                MessageBox.Show("database updated");
            }
            catch (Exception)
            { throw; }
            finally
            {
                if (conn.State == ConnectionState.Open)
                { conn.Close(); }
            }

        }


        private void Form1_NewFileRecieved(object sender, string fileName)
        {
            this.BeginInvoke(new Action(
            delegate()
            {
                MessageBox.Show("New File Recieved\n" + fileName);
                //System.Diagnostics.Process.Start("explorer", @"C:\wamp\www\finalhash\files");
            }));
        }


        public void HandleIncomingFile(int port)
        {

                try
                {
                    
                    
                    TcpListener tcpListener = new TcpListener(port);
                    //MessageBox.Show("one");
                    label1.Text = "listening";
                    tcpListener.Start();
                    
                    while (true)
                    {
                        Socket handlerSocket = tcpListener.AcceptSocket();
                        if (handlerSocket.Connected)
                        {
                            
                            fileName = string.Empty;
                            NetworkStream networkStream = new NetworkStream(handlerSocket,FileAccess.ReadWrite,true);
                            int thisRead = 0;
                            int blockSize = 1024;
                            Byte[] dataByte = new Byte[blockSize];
                            lock (this)
                            {
                                folderPath = @"C:\wamp\www\finalhash\files\";
                                handlerSocket.Receive(dataByte);
                                int fileNameLen = BitConverter.ToInt32(dataByte, 0);
                                fileName = Encoding.ASCII.GetString(dataByte, 4, fileNameLen);
                                email = fileName.Substring(0, fileName.IndexOf('-'));
                                Stream fileStream = File.OpenWrite(folderPath + fileName);
                                fileStream.Write(dataByte, 4 + fileNameLen, (1024 - (4 + fileNameLen)));
                                while (true)
                                {
                                    thisRead = networkStream.Read(dataByte, 0, blockSize);
                                    fileStream.Write(dataByte, 0, thisRead);
                                    if (thisRead == 0)
                                        break;
                                }
                                fileStream.Close();
                                MessageBox.Show(email);/*shows userid to check if the user data is also appended with */
                                updatedata();


                            }
                            if (NewFileRecieved != null)
                            {
                                NewFileRecieved(this, fileName);
                            }
                            handlerSocket = null;
                        }
                    }

                }
                catch
                {

                }
            
        }
        

    }
}
