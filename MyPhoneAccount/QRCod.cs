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
    public partial class QRCod : Form
    {

        public QRCod()
        {
            InitializeComponent();
        }

        private void QRCod_Load(object sender, EventArgs e)
        {
           

            
        }
        public void SetData(PersonDto.Person person)
        {
            string str = $"BEGIN:VCARD" +
                                $"VERSION: 4.0" +
                                $"FN: " + person.Fullname +
                                $"ORG: " +person.CompanyName +
                                $"TEL; TYPE = work,voice; VALUE = " + person.Phone +
                                $"TEL; TYPE = home,voice; VALUE = " + person.GSM +
                                $"EMAIL: " + person.Email +
                                $"END:VCARD";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
