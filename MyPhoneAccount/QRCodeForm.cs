using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPhoneAccount
{
    public partial class QRCodeForm : Form
    {

        public QRCodeForm()
        {
            InitializeComponent();
        }
        int second = 15;
        public void QRCod_Load(object sender, EventArgs e)
        {

            timer1.Interval = 1000;
            timer1.Start();
        }
        public void SetData(PersonDto.Person person)
        {
            string str = $"BEGIN:VCARD\n" +
                                $"VERSION: 4.0\n" +
                                $"FN: " + person.Fullname+"\n" +
                                $"ORG: " +person.CompanyName + "\n" +
                                $"TEL; TYPE = work,voice; VALUE = " + person.Phone + "\n" +
                                $"TEL; TYPE = home,voice; VALUE = " + person.GSM + "\n" +
                                $"EMAIL: " + person.Email + "\n" +
                                $"END:VCARD";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;
        }

        

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            

            if (second > 0)
            {
                lblTimer.Text = Convert.ToString(second--) + " saniye sonra kapanacak";
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void QRCod_FormClosed(object sender, FormClosedEventArgs e)
        {
            second = 15;
            timer1.Stop();
            lblTimer.Text = Convert.ToString(second--) + " saniye sonra kapanacak";
        }
    }
}
