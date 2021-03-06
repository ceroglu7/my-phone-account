using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace MyPhoneAccount
{
    public partial class MailForm : Form
    {
        
        public MailForm()
        {
            InitializeComponent();
        }
        public string fullName;
        public string companyName;
        public string gsm;
        public string email;
        private void Mail_Load(object sender, EventArgs e)
        {
            lblSelected.Text = "Paylaşılan Kişi: " + fullName;

        }
        //checkemailadress metodu

        private void btnSend_Click(object sender, EventArgs e)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("ceroglu7@gmail.com");
            string SendingAdress = txtSendingAdress.Text;
            //
            if (txtSendingAdress.Text != string.Empty|| txtSendingAdress.Text !=null)
            {
                //
                ePosta.To.Add(txtSendingAdress.Text);
                //

                //
                ePosta.Subject = fullName + " Kişisinin Bilgileri Seninle Paylaşıldı!";
                //

                ePosta.Body = "Deneme Metni= Adı Soyadı:" + fullName;
                //
                SmtpClient smtp = new SmtpClient();
                //
                smtp.Credentials = new System.Net.NetworkCredential("eposta@gmail.com", "sifre");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                object userState = ePosta;
                bool kontrol = true;
                
                try
                {
                    smtp.Send(ePosta);
                    this.Hide();
                    
                }
                catch (SmtpException ex)
                {
                    kontrol = false;
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                }
                
            }
            else
            {
                MessageBox.Show("E-Mail Adresi Hatalı");
            }
            
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress("ceroglu7@gmail.com");
                string SendingAdress = txtSendingAdress.Text;
                //
                if (txtSendingAdress.Text != string.Empty || txtSendingAdress.Text != null)
                {
                    //
                    ePosta.To.Add(txtSendingAdress.Text);
                    //

                    //
                    ePosta.Subject = fullName + " Kişisinin Bilgileri Seninle Paylaşıldı!";
                    //

                    ePosta.Body = "Deneme Metni= Adı Soyadı:" + fullName;
                    //
                    SmtpClient smtp = new SmtpClient();
                    //
                    smtp.Credentials = new System.Net.NetworkCredential("eposta@gmail.com", "sifre");
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    object userState = ePosta;
                    bool kontrol = true;

                    try
                    {
                        smtp.Send(ePosta);
                        this.Hide();
                    }
                    catch (SmtpException ex)
                    {
                        kontrol = false;
                        System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                    }

                }
                else
                {
                    MessageBox.Show("E-Mail Adresi Hatalı");
                }


            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Mail_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
