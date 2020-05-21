namespace MyOAuth
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
            this.rtxb1 = new System.Windows.Forms.RichTextBox();
            this.rtxb2 = new System.Windows.Forms.RichTextBox();
            this.rtxb3 = new System.Windows.Forms.RichTextBox();
            this.btnStep1 = new System.Windows.Forms.Button();
            this.btnStep2 = new System.Windows.Forms.Button();
            this.btnStep3 = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.Label();
            this.pctbUser = new System.Windows.Forms.PictureBox();
            this.lstvProfile = new System.Windows.Forms.ListView();
            this.btnGetProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctbUser)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxb1
            // 
            this.rtxb1.Location = new System.Drawing.Point(11, 48);
            this.rtxb1.Name = "rtxb1";
            this.rtxb1.Size = new System.Drawing.Size(254, 143);
            this.rtxb1.TabIndex = 0;
            this.rtxb1.Text = "";
            // 
            // rtxb2
            // 
            this.rtxb2.Location = new System.Drawing.Point(288, 48);
            this.rtxb2.Name = "rtxb2";
            this.rtxb2.Size = new System.Drawing.Size(237, 143);
            this.rtxb2.TabIndex = 1;
            this.rtxb2.Text = "";
            // 
            // rtxb3
            // 
            this.rtxb3.Location = new System.Drawing.Point(550, 48);
            this.rtxb3.Name = "rtxb3";
            this.rtxb3.Size = new System.Drawing.Size(237, 143);
            this.rtxb3.TabIndex = 2;
            this.rtxb3.Text = "";
            // 
            // btnStep1
            // 
            this.btnStep1.Location = new System.Drawing.Point(11, 7);
            this.btnStep1.Name = "btnStep1";
            this.btnStep1.Size = new System.Drawing.Size(254, 23);
            this.btnStep1.TabIndex = 3;
            this.btnStep1.Text = "Send Request and Get Authorization Grant";
            this.btnStep1.UseVisualStyleBackColor = true;
            this.btnStep1.Click += new System.EventHandler(this.btnStep1_Click);
            // 
            // btnStep2
            // 
            this.btnStep2.Location = new System.Drawing.Point(288, 7);
            this.btnStep2.Name = "btnStep2";
            this.btnStep2.Size = new System.Drawing.Size(237, 23);
            this.btnStep2.TabIndex = 4;
            this.btnStep2.Text = "Send Athorization Grant and Get Access Token";
            this.btnStep2.UseVisualStyleBackColor = true;
            this.btnStep2.Click += new System.EventHandler(this.btnStep2_Click);
            // 
            // btnStep3
            // 
            this.btnStep3.Location = new System.Drawing.Point(550, 7);
            this.btnStep3.Name = "btnStep3";
            this.btnStep3.Size = new System.Drawing.Size(237, 23);
            this.btnStep3.TabIndex = 5;
            this.btnStep3.Text = "Send Access Token and Get Info";
            this.btnStep3.UseVisualStyleBackColor = true;
            this.btnStep3.Click += new System.EventHandler(this.btnStep3_Click);
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(47, 222);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(61, 13);
            this.lb1.TabIndex = 6;
            this.lb1.Text = "Profile User";
            // 
            // pctbUser
            // 
            this.pctbUser.Location = new System.Drawing.Point(107, 249);
            this.pctbUser.Name = "pctbUser";
            this.pctbUser.Size = new System.Drawing.Size(121, 128);
            this.pctbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbUser.TabIndex = 7;
            this.pctbUser.TabStop = false;
            // 
            // lstvProfile
            // 
            this.lstvProfile.HideSelection = false;
            this.lstvProfile.Location = new System.Drawing.Point(247, 299);
            this.lstvProfile.Name = "lstvProfile";
            this.lstvProfile.Size = new System.Drawing.Size(313, 125);
            this.lstvProfile.TabIndex = 8;
            this.lstvProfile.UseCompatibleStateImageBehavior = false;
            this.lstvProfile.View = System.Windows.Forms.View.List;
            // 
            // btnGetProfile
            // 
            this.btnGetProfile.Location = new System.Drawing.Point(267, 217);
            this.btnGetProfile.Name = "btnGetProfile";
            this.btnGetProfile.Size = new System.Drawing.Size(269, 33);
            this.btnGetProfile.TabIndex = 9;
            this.btnGetProfile.Text = "Get Profile";
            this.btnGetProfile.UseVisualStyleBackColor = true;
            this.btnGetProfile.Click += new System.EventHandler(this.btnGetProfile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetProfile);
            this.Controls.Add(this.lstvProfile);
            this.Controls.Add(this.pctbUser);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.btnStep3);
            this.Controls.Add(this.btnStep2);
            this.Controls.Add(this.btnStep1);
            this.Controls.Add(this.rtxb3);
            this.Controls.Add(this.rtxb2);
            this.Controls.Add(this.rtxb1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pctbUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxb1;
        private System.Windows.Forms.RichTextBox rtxb2;
        private System.Windows.Forms.RichTextBox rtxb3;
        private System.Windows.Forms.Button btnStep1;
        private System.Windows.Forms.Button btnStep2;
        private System.Windows.Forms.Button btnStep3;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.PictureBox pctbUser;
        private System.Windows.Forms.ListView lstvProfile;
        private System.Windows.Forms.Button btnGetProfile;
    }
}

