namespace GameServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recieve_btn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.connected_players = new System.Windows.Forms.Label();
            this.send_massege = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // recieve_btn
            // 
            this.recieve_btn.Location = new System.Drawing.Point(531, 189);
            this.recieve_btn.Name = "recieve_btn";
            this.recieve_btn.Size = new System.Drawing.Size(176, 59);
            this.recieve_btn.TabIndex = 1;
            this.recieve_btn.Text = "recieve";
            this.recieve_btn.UseVisualStyleBackColor = true;
            this.recieve_btn.Click += new System.EventHandler(this.recieve_btn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(23, 82);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(182, 184);
            this.listBox1.TabIndex = 2;
            // 
            // connected_players
            // 
            this.connected_players.AutoSize = true;
            this.connected_players.Location = new System.Drawing.Point(41, 42);
            this.connected_players.Name = "connected_players";
            this.connected_players.Size = new System.Drawing.Size(128, 20);
            this.connected_players.TabIndex = 3;
            this.connected_players.Text = "connected Players";
            // 
            // send_massege
            // 
            this.send_massege.Location = new System.Drawing.Point(531, 99);
            this.send_massege.Name = "send_massege";
            this.send_massege.Size = new System.Drawing.Size(176, 56);
            this.send_massege.TabIndex = 4;
            this.send_massege.Text = "send";
            this.send_massege.UseVisualStyleBackColor = true;
            this.send_massege.Click += new System.EventHandler(this.send_massege_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(337, 99);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 140);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.send_massege);
            this.Controls.Add(this.connected_players);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.recieve_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button start_server;
        private Button recieve_btn;
       public  ListBox listBox1 ;
        public Label connected_players;
        private Button send_massege;
        public TextBox textBox1;
    }
}