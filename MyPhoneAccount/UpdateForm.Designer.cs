
namespace MyPhoneAccount
{
    partial class UpdateForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtGSM = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtNameSurname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectPhoto = new System.Windows.Forms.Button();
            this.pcbProfilePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 435);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(248, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Güncelle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(12, 397);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(248, 20);
            this.txtMail.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "E-Mail";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(12, 248);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(248, 20);
            this.txtCompany.TabIndex = 20;
            // 
            // txtGSM
            // 
            this.txtGSM.Location = new System.Drawing.Point(12, 299);
            this.txtGSM.MaxLength = 11;
            this.txtGSM.Name = "txtGSM";
            this.txtGSM.Size = new System.Drawing.Size(248, 20);
            this.txtGSM.TabIndex = 19;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(12, 348);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(248, 20);
            this.txtPhone.TabIndex = 18;
            // 
            // txtNameSurname
            // 
            this.txtNameSurname.Location = new System.Drawing.Point(12, 199);
            this.txtNameSurname.Name = "txtNameSurname";
            this.txtNameSurname.Size = new System.Drawing.Size(248, 20);
            this.txtNameSurname.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Sabit Telefon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "GSM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Firma Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Adı Soyadı";
            // 
            // btnSelectPhoto
            // 
            this.btnSelectPhoto.Location = new System.Drawing.Point(10, 150);
            this.btnSelectPhoto.Name = "btnSelectPhoto";
            this.btnSelectPhoto.Size = new System.Drawing.Size(248, 23);
            this.btnSelectPhoto.TabIndex = 24;
            this.btnSelectPhoto.Text = "Fotoğraf Seç";
            this.btnSelectPhoto.UseVisualStyleBackColor = true;
            this.btnSelectPhoto.Click += new System.EventHandler(this.button1_Click);
            // 
            // pcbProfilePic
            // 
            this.pcbProfilePic.Location = new System.Drawing.Point(34, 12);
            this.pcbProfilePic.Name = "pcbProfilePic";
            this.pcbProfilePic.Size = new System.Drawing.Size(197, 132);
            this.pcbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbProfilePic.TabIndex = 25;
            this.pcbProfilePic.TabStop = false;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 474);
            this.Controls.Add(this.pcbProfilePic);
            this.Controls.Add(this.btnSelectPhoto);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.txtGSM);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtNameSurname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpdateForm";
            this.Text = "Kişi Bilgilerini Düzenle";
            this.Load += new System.EventHandler(this.Update_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtGSM;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtNameSurname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectPhoto;
        private System.Windows.Forms.PictureBox pcbProfilePic;
    }
}