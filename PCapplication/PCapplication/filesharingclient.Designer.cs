namespace PCapplication
{
    partial class filesharingclient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnbrowse = new System.Windows.Forms.Button();
            this.btnsend = new System.Windows.Forms.Button();
            this.txtfile = new System.Windows.Forms.TextBox();
            this.ipaddress = new System.Windows.Forms.TextBox();
            this.txthost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnbrowse
            // 
            this.btnbrowse.Location = new System.Drawing.Point(118, 253);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(75, 23);
            this.btnbrowse.TabIndex = 0;
            this.btnbrowse.Text = "browse";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(260, 253);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(75, 23);
            this.btnsend.TabIndex = 1;
            this.btnsend.Text = "send";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // txtfile
            // 
            this.txtfile.Location = new System.Drawing.Point(118, 60);
            this.txtfile.Name = "txtfile";
            this.txtfile.Size = new System.Drawing.Size(188, 20);
            this.txtfile.TabIndex = 2;
            // 
            // ipaddress
            // 
            this.ipaddress.Location = new System.Drawing.Point(118, 102);
            this.ipaddress.Name = "ipaddress";
            this.ipaddress.Size = new System.Drawing.Size(188, 20);
            this.ipaddress.TabIndex = 3;
            this.ipaddress.Visible = false;
            // 
            // txthost
            // 
            this.txthost.Location = new System.Drawing.Point(118, 150);
            this.txthost.Name = "txthost";
            this.txthost.Size = new System.Drawing.Size(188, 20);
            this.txthost.TabIndex = 4;
            this.txthost.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ipaddress";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "host";
            this.label3.Visible = false;
            // 
            // filesharingclient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 342);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txthost);
            this.Controls.Add(this.ipaddress);
            this.Controls.Add(this.txtfile);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.btnbrowse);
            this.Name = "filesharingclient";
            this.Text = "fileSharingClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.TextBox txtfile;
        private System.Windows.Forms.TextBox ipaddress;
        private System.Windows.Forms.TextBox txthost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}