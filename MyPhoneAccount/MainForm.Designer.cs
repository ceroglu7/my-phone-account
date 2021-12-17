
namespace MyPhoneAccount
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstvResult = new System.Windows.Forms.ListView();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDeletePerson = new System.Windows.Forms.Button();
            this.lblNoPerson1 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblGSM = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.cmbSearchCategory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCreateQR = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstvResult
            // 
            this.lstvResult.HideSelection = false;
            this.lstvResult.HoverSelection = true;
            this.lstvResult.Location = new System.Drawing.Point(12, 34);
            this.lstvResult.Name = "lstvResult";
            this.lstvResult.Size = new System.Drawing.Size(197, 265);
            this.lstvResult.TabIndex = 0;
            this.lstvResult.UseCompatibleStateImageBehavior = false;
            this.lstvResult.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(215, 276);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(192, 23);
            this.btnEkle.TabIndex = 1;
            this.btnEkle.Text = "Yeni Kayıt Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnDeletePerson
            // 
            this.btnDeletePerson.Location = new System.Drawing.Point(216, 243);
            this.btnDeletePerson.Name = "btnDeletePerson";
            this.btnDeletePerson.Size = new System.Drawing.Size(191, 23);
            this.btnDeletePerson.TabIndex = 2;
            this.btnDeletePerson.Text = "Kaydı Sil";
            this.btnDeletePerson.UseVisualStyleBackColor = true;
            this.btnDeletePerson.Click += new System.EventHandler(this.btnDeletePerson_Click);
            // 
            // lblNoPerson1
            // 
            this.lblNoPerson1.AutoSize = true;
            this.lblNoPerson1.Location = new System.Drawing.Point(226, 113);
            this.lblNoPerson1.Name = "lblNoPerson1";
            this.lblNoPerson1.Size = new System.Drawing.Size(0, 13);
            this.lblNoPerson1.TabIndex = 3;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(232, 57);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(35, 13);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "label1";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(232, 86);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(35, 13);
            this.lblCompanyName.TabIndex = 5;
            this.lblCompanyName.Text = "label2";
            // 
            // lblGSM
            // 
            this.lblGSM.AutoSize = true;
            this.lblGSM.Location = new System.Drawing.Point(232, 113);
            this.lblGSM.Name = "lblGSM";
            this.lblGSM.Size = new System.Drawing.Size(35, 13);
            this.lblGSM.TabIndex = 6;
            this.lblGSM.Text = "label3";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(232, 141);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(35, 13);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "label4";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(232, 172);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(35, 13);
            this.lblMail.TabIndex = 8;
            this.lblMail.Text = "label5";
            // 
            // cmbSearchCategory
            // 
            this.cmbSearchCategory.FormattingEnabled = true;
            this.cmbSearchCategory.Items.AddRange(new object[] {
            "Ad Soyad",
            "Şirket Adı",
            "GSM Numarası",
            "Sabit Tel.",
            "E-Mail",
            "Sıfırla"});
            this.cmbSearchCategory.Location = new System.Drawing.Point(13, 7);
            this.cmbSearchCategory.Name = "cmbSearchCategory";
            this.cmbSearchCategory.Size = new System.Drawing.Size(107, 21);
            this.cmbSearchCategory.TabIndex = 9;
            this.cmbSearchCategory.Text = "Arama Kategorisi";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(127, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(280, 20);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnCreateQR
            // 
            this.btnCreateQR.Location = new System.Drawing.Point(215, 214);
            this.btnCreateQR.Name = "btnCreateQR";
            this.btnCreateQR.Size = new System.Drawing.Size(95, 23);
            this.btnCreateQR.TabIndex = 11;
            this.btnCreateQR.Text = "QR Kod Oluştur";
            this.btnCreateQR.UseVisualStyleBackColor = true;
            this.btnCreateQR.Click += new System.EventHandler(this.btnCreateQR_Click);
            // 
            // btnMail
            // 
            this.btnMail.Location = new System.Drawing.Point(312, 214);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(95, 23);
            this.btnMail.TabIndex = 12;
            this.btnMail.Text = "Mail Gönder";
            this.btnMail.UseVisualStyleBackColor = true;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 311);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.btnCreateQR);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbSearchCategory);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblGSM);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblNoPerson1);
            this.Controls.Add(this.btnDeletePerson);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lstvResult);
            this.Name = "MainForm";
            this.Text = "Rehberim";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstvResult;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnDeletePerson;
        private System.Windows.Forms.Label lblNoPerson1;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblGSM;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.ComboBox cmbSearchCategory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCreateQR;
        private System.Windows.Forms.Button btnMail;
    }
}

