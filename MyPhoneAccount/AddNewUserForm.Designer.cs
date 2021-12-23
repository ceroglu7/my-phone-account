
namespace MyPhoneAccount
{
    partial class AddNewUserForm
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
            this.radioBtnPerson = new System.Windows.Forms.RadioButton();
            this.radioBtnCompany = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameSurname = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPhoto = new System.Windows.Forms.Button();
            this.lblPhotoAdress = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtGSM = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // radioBtnPerson
            // 
            this.radioBtnPerson.AutoSize = true;
            this.radioBtnPerson.Location = new System.Drawing.Point(172, 12);
            this.radioBtnPerson.Name = "radioBtnPerson";
            this.radioBtnPerson.Size = new System.Drawing.Size(41, 17);
            this.radioBtnPerson.TabIndex = 0;
            this.radioBtnPerson.TabStop = true;
            this.radioBtnPerson.Text = "Kişi";
            this.radioBtnPerson.UseVisualStyleBackColor = true;
            this.radioBtnPerson.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioBtnCompany
            // 
            this.radioBtnCompany.AutoSize = true;
            this.radioBtnCompany.Location = new System.Drawing.Point(219, 12);
            this.radioBtnCompany.Name = "radioBtnCompany";
            this.radioBtnCompany.Size = new System.Drawing.Size(50, 17);
            this.radioBtnCompany.TabIndex = 1;
            this.radioBtnCompany.TabStop = true;
            this.radioBtnCompany.Text = "Firma";
            this.radioBtnCompany.UseVisualStyleBackColor = true;
            this.radioBtnCompany.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adı Soyadı";
            // 
            // txtNameSurname
            // 
            this.txtNameSurname.Location = new System.Drawing.Point(16, 103);
            this.txtNameSurname.Name = "txtNameSurname";
            this.txtNameSurname.Size = new System.Drawing.Size(248, 20);
            this.txtNameSurname.TabIndex = 6;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(16, 152);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(248, 20);
            this.txtCompany.TabIndex = 9;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(16, 301);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(248, 20);
            this.txtMail.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 339);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(248, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "E-Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sabit Telefon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "GSM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Firma Adı";
            // 
            // btnPhoto
            // 
            this.btnPhoto.Location = new System.Drawing.Point(15, 47);
            this.btnPhoto.Name = "btnPhoto";
            this.btnPhoto.Size = new System.Drawing.Size(249, 23);
            this.btnPhoto.TabIndex = 13;
            this.btnPhoto.Text = "Fotoğraf Ekle";
            this.btnPhoto.UseVisualStyleBackColor = true;
            this.btnPhoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // lblPhotoAdress
            // 
            this.lblPhotoAdress.AutoSize = true;
            this.lblPhotoAdress.Location = new System.Drawing.Point(13, 52);
            this.lblPhotoAdress.Name = "lblPhotoAdress";
            this.lblPhotoAdress.Size = new System.Drawing.Size(0, 13);
            this.lblPhotoAdress.TabIndex = 14;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(16, 252);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(248, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // txtGSM
            // 
            this.txtGSM.Location = new System.Drawing.Point(16, 203);
            this.txtGSM.MaxLength = 11;
            this.txtGSM.Name = "txtGSM";
            this.txtGSM.Size = new System.Drawing.Size(248, 20);
            this.txtGSM.TabIndex = 8;
            // 
            // AddNewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 382);
            this.Controls.Add(this.lblPhotoAdress);
            this.Controls.Add(this.btnPhoto);
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
            this.Controls.Add(this.radioBtnCompany);
            this.Controls.Add(this.radioBtnPerson);
            this.Name = "AddNewUserForm";
            this.Text = "Rehbere Ekle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddNewUserForm_FormClosed);
            this.Load += new System.EventHandler(this.AddNewUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioBtnPerson;
        private System.Windows.Forms.RadioButton radioBtnCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameSurname;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPhoto;
        private System.Windows.Forms.Label lblPhotoAdress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtGSM;
    }
}