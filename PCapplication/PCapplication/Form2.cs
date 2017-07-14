using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace PCapplication
{
    public partial class Form2 : Form
    {

        public static string[] fname = new String[10];
        public static string[] nm = new String[10];
        public static string[] fname_final = new String[10];
        public static string[] nm_final = new String[10];
        public static string user = "";
        public static string pass = "";

        public static string sessionKey = "";
        public static RSAParameters pubKey, privKey;

        public Form2()
        {
            InitializeComponent();
            user = "boneyp003";
            
            RSACryptoServiceProvider csp1 = new RSACryptoServiceProvider(2048);
            pubKey = csp1.ExportParameters(false);
            privKey = csp1.ExportParameters(true);
        }


        public Form2(string user1)
        {
            InitializeComponent();
            user = user1;
            //pass = pass1;

            RSACryptoServiceProvider csp1 = new RSACryptoServiceProvider(2048);
            pubKey = csp1.ExportParameters(false);
            privKey = csp1.ExportParameters(true);
        }


        //------CODE FOR UPLOADING (INCLUDES ENCRYPTION)-------

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Locked files, Don't Add/Remove any files now.");
            updateList();  
            
            filesharingclient obj1 = new filesharingclient();
            //OpenFileDialog theDialog = new OpenFileDialog();
            //theDialog.Filter = "TXT files|*.txt";
            //if (theDialog.ShowDialog() == DialogResult.OK)
            if (fname_final.Length > 0)
            {
                //fname = theDialog.FileName;
                //fname = "C:\\Users\\boney\\Desktop\\sql.txt";
                //MessageBox.Show(fname);
                for (int i = 0; i < fname_final.Length && fname_final[i]!=null; i++)
                {
                    sessionKey = GenerateKey();
                    EncryptFile(fname_final[i], "C:\\Users\\boney\\Desktop\\encOutput\\" + nm_final[i] + "op.txt", sessionKey);
                    Task t1 = Task.Factory.StartNew(() => SendFile("172.37.5.64", 5555, "C:\\Users\\boney\\Desktop\\encOutput\\" + nm_final[i] + "op.txt", nm_final[i] + "op.txt"));
                    /*enc session keywith rsa pubic key.*/
                    MessageBox.Show("File Sent");
                    
                    
                    sessionKey = EncSessionKey(sessionKey);
                    /**/
                    storeSkey("C:\\Users\\boney\\Desktop\\encOutput\\" + nm_final[i] + "opKey.txt", sessionKey);
                    Task t2 = Task.Factory.StartNew(() => SendFile("172.37.5.64", 5555, "C:\\Users\\boney\\Desktop\\encOutput\\" + nm_final[i] + "opKey.txt", nm_final[i] + "opKey.txt"));
                    //t2.Wait();
                    MessageBox.Show("File Sent");
                    // DO NOT change address of the output destination of encrypted file.
                }
            }
        }

        public void updateList()
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("nm", typeof(string));
            dt1.Columns.Add("fname", typeof(string));

            int i = 0;

            foreach (DataGridViewRow dgvR in dataGridView1.Rows)
            {
                dt1.Rows.Add(dgvR.Cells[0].Value, dgvR.Cells[1].Value);
                nm_final[i] = dgvR.Cells[0].Value.ToString();
                fname_final[i] = dgvR.Cells[1].Value.ToString();
                i++;
            }
        }

        static string EncSessionKey(string sk)
        {
            RSACryptoServiceProvider csp2 = new RSACryptoServiceProvider();
            csp2.ImportParameters(pubKey);

            //for encryption, always handle bytes...
            byte[] bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(sk);

            //apply pkcs#1.5 padding and encrypt our data 
            byte[] bytesCipherText = csp2.Encrypt(bytesPlainTextData, false);

            //we might want a string representation of our cypher text... base64 will do
            string cipherText = Convert.ToBase64String(bytesCipherText);

            return cipherText;
        }

        //  Call this function to remove the key from memory after use for security.
        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(ref string Destination, int Length);

        static string GenerateKey()
        {
            // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
            AesCryptoServiceProvider aes = (AesCryptoServiceProvider)AesCryptoServiceProvider.Create();

            // Use the Automatically generated key for Encryption. 
            aes.KeySize = 128;
            aes.GenerateKey();
            return ASCIIEncoding.ASCII.GetString(aes.Key);
        }

        static void storeSkey(string fname, string skey)
        {
            //FileStream skeyin = new FileStream(fname, FileMode.Create, FileAccess.Write);
            File.WriteAllText(fname, skey);     //fname is path.
        }

        static string getSkey(string fname)
        {
            return File.ReadAllText(fname);
        }

        static void EncryptFile(string sInputFilename, string sOutputFilename, string sKey)
        {
            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

            AesCryptoServiceProvider a1 = new AesCryptoServiceProvider();
            //a1.KeySize = 128;
            a1.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            a1.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            ICryptoTransform aesencrypt = a1.CreateEncryptor();
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, aesencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length - 1];
            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
            cryptostream.FlushFinalBlock();

            fsInput.Close();
            fsEncrypted.Close();
            MessageBox.Show("done");

        }

        //------CODE FOR DOWNLOADING (INCLUDES DECRYPTION)-------

        private void button2_Click(object sender, EventArgs e)
        {
            string f = "";
            string ftmp = "";
            
            
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = "C:\\Users\\boney\\Desktop\\encOutput";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                f = theDialog.FileName;
                ftmp = theDialog.SafeFileName;
                int fileExtPos = ftmp.LastIndexOf(".");
                if (fileExtPos >= 0)
                    ftmp = ftmp.Substring(0, fileExtPos);
            }
            string rSkey = getSkey("C:\\Users\\boney\\Desktop\\encOutput\\" + ftmp + "Key.txt");


            /*dec session key with rsa private key.*/

            //first, get our bytes back from the base64 string ...
            byte[] bytesCipherText = Convert.FromBase64String(rSkey);

            //we want to decrypt, therefore we need a csp and load our private key
            RSACryptoServiceProvider csp3 = new RSACryptoServiceProvider();
            csp3.ImportParameters(privKey);

            //decrypt and strip pkcs#1.5 padding
            byte[] bytesPlainTextData = csp3.Decrypt(bytesCipherText, false);

            //get our original plainText back...
            rSkey = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

            /**/

            DecryptFile(f, "C:\\Users\\boney\\Desktop\\decOutput\\dec.txt", rSkey);
        }

        static void DecryptFile(string sInputFilename, string sOutputFilename, string sKey)
        {
            AesCryptoServiceProvider a2 = new AesCryptoServiceProvider();
            //A 128 bit key and IV is required for this provider.
            //Set secret key For AES algorithm.
            //a2.KeySize = 128;
            a2.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            a2.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            //Create a AES decryptor from the AES instance.
            ICryptoTransform aesdecrypt = a2.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //AES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, aesdecrypt, CryptoStreamMode.Read);
            //Print the contents of the decrypted file.
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Filter = "TXT files|*.txt";
            theDialog.Multiselect = true;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                fname = theDialog.FileNames;
                nm = theDialog.SafeFileNames;
                //fname = "C:\\Users\\boney\\Desktop\\sql.txt";
                for (int i = 0; i < fname.Length; i++)
                {
                    //MessageBox.Show(fname[i] + "," + nm[i]);
                    int fileExtPos = nm[i].LastIndexOf(".");
                    if (fileExtPos >= 0)
                        nm[i] = user+"-"+nm[i].Substring(0, fileExtPos);


                    DataRow dr = dataTable1.NewRow();
                    dataTable1.Rows.Add(dr);

                    dr[0] = nm[i];
                    dr[1] = fname[i];
                    
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dataSet1;
                    dataGridView1.DataMember = "Table1";
                }
                /*sessionKey = GenerateKey();
                EncryptFile(fname, "C:\\Users\\boney\\Desktop\\encOutput\\op.txt", sessionKey);
                storeSkey("C:\\Users\\boney\\Desktop\\encOutput\\opKey.txt", sessionKey);
                // DO NOT change address of the output destination of encrypted file.
                */
            }
        }




        //following code is to send file to the server


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
