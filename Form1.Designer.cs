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
            this.start_server = new System.Windows.Forms.Button();
            this.recieve_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start_server
            // 
            this.start_server.Location = new System.Drawing.Point(511, 92);
            this.start_server.Name = "start_server";
            this.start_server.Size = new System.Drawing.Size(94, 29);
            this.start_server.TabIndex = 0;
            this.start_server.Text = "start";
            this.start_server.UseVisualStyleBackColor = true;
            this.start_server.Click += new System.EventHandler(this.start_server_click);
            // 
            // recieve_btn
            // 
            this.recieve_btn.Location = new System.Drawing.Point(131, 92);
            this.recieve_btn.Name = "recieve_btn";
            this.recieve_btn.Size = new System.Drawing.Size(94, 29);
            this.recieve_btn.TabIndex = 1;
            this.recieve_btn.Text = "recieve";
            this.recieve_btn.UseVisualStyleBackColor = true;
            this.recieve_btn.Click += new System.EventHandler(this.recieve_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.recieve_btn);
            this.Controls.Add(this.start_server);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button start_server;
        private Button recieve_btn;
    }
}