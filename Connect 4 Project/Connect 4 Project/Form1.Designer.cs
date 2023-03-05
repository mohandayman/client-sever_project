namespace Connect_4_Project
{
    partial class Form1
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
            this.send_button = new System.Windows.Forms.Button();
            this.New_tab = new System.Windows.Forms.Button();
            this.massegeBox = new System.Windows.Forms.TextBox();
            this.join_room_4 = new System.Windows.Forms.Button();
            this.join_room_3 = new System.Windows.Forms.Button();
            this.join_room_2 = new System.Windows.Forms.Button();
            this.join_room_1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(528, 349);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(153, 63);
            this.send_button.TabIndex = 1;
            this.send_button.Text = "send";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // New_tab
            // 
            this.New_tab.Location = new System.Drawing.Point(89, 358);
            this.New_tab.Name = "New_tab";
            this.New_tab.Size = new System.Drawing.Size(153, 54);
            this.New_tab.TabIndex = 2;
            this.New_tab.Text = "new Tab";
            this.New_tab.UseVisualStyleBackColor = true;
            this.New_tab.Click += new System.EventHandler(this.New_tab_Click);
            // 
            // massegeBox
            // 
            this.massegeBox.Location = new System.Drawing.Point(289, 180);
            this.massegeBox.Multiline = true;
            this.massegeBox.Name = "massegeBox";
            this.massegeBox.Size = new System.Drawing.Size(188, 144);
            this.massegeBox.TabIndex = 3;
            // 
            // join_room_4
            // 
            this.join_room_4.Location = new System.Drawing.Point(600, 12);
            this.join_room_4.Name = "join_room_4";
            this.join_room_4.Size = new System.Drawing.Size(153, 63);
            this.join_room_4.TabIndex = 4;
            this.join_room_4.Text = "join_room_4";
            this.join_room_4.UseVisualStyleBackColor = true;
            this.join_room_4.Click += new System.EventHandler(this.join_room_4_Click_1);
            // 
            // join_room_3
            // 
            this.join_room_3.Location = new System.Drawing.Point(413, 12);
            this.join_room_3.Name = "join_room_3";
            this.join_room_3.Size = new System.Drawing.Size(153, 63);
            this.join_room_3.TabIndex = 5;
            this.join_room_3.Text = "join_room_3";
            this.join_room_3.UseVisualStyleBackColor = true;
            this.join_room_3.Click += new System.EventHandler(this.join_room_3_Click_1);
            // 
            // join_room_2
            // 
            this.join_room_2.Location = new System.Drawing.Point(225, 12);
            this.join_room_2.Name = "join_room_2";
            this.join_room_2.Size = new System.Drawing.Size(153, 63);
            this.join_room_2.TabIndex = 6;
            this.join_room_2.Text = "join_room_2";
            this.join_room_2.UseVisualStyleBackColor = true;
            this.join_room_2.Click += new System.EventHandler(this.join_room_2_Click_1);
            // 
            // join_room_1
            // 
            this.join_room_1.Location = new System.Drawing.Point(34, 12);
            this.join_room_1.Name = "join_room_1";
            this.join_room_1.Size = new System.Drawing.Size(153, 63);
            this.join_room_1.TabIndex = 7;
            this.join_room_1.Text = "join_room_1";
            this.join_room_1.UseVisualStyleBackColor = true;
            this.join_room_1.Click += new System.EventHandler(this.join_room_1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 450);
            this.Controls.Add(this.join_room_1);
            this.Controls.Add(this.join_room_2);
            this.Controls.Add(this.join_room_3);
            this.Controls.Add(this.join_room_4);
            this.Controls.Add(this.massegeBox);
            this.Controls.Add(this.New_tab);
            this.Controls.Add(this.send_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.Button New_tab;
        public System.Windows.Forms.TextBox massegeBox;
        private System.Windows.Forms.Button join_room_4;
        private System.Windows.Forms.Button join_room_3;
        private System.Windows.Forms.Button join_room_2;
        private System.Windows.Forms.Button join_room_1;
    }
}

