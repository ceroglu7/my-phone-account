using Newtonsoft.Json;
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
    public partial class AddNewUserForm : Form
    {

        public AddNewUserForm()
        {
            InitializeComponent();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
                txtNameSurname.Enabled = true;
                txtMail.Enabled = true;
                txtGSM.Enabled = true;
                txtCompany.Enabled = false;
                txtPhone.Enabled = false;
            
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
                txtCompany.Enabled = true;
                txtPhone.Enabled = true;
                txtMail.Enabled = true;
                txtNameSurname.Enabled = false;
                txtGSM.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RehberParametre rehber = new RehberParametre();
            if (radioButton1.Checked==true)
            {
                rehber.NameSurname = Convert.ToString(txtNameSurname.Text);
                rehber.GSM = Convert.ToString(txtGSM.Text);
                rehber.email = Convert.ToString(txtMail.Text);
                rehber.CompanyName = null;
                rehber.Phone = null;
            }
            else if (radioButton2.Checked==true)
            {
                rehber.NameSurname = null;
                rehber.GSM = null;
                rehber.email = Convert.ToString(txtMail.Text);
                rehber.CompanyName = Convert.ToString(txtCompany.Text);
                rehber.Phone = Convert.ToString(txtPhone.Text);
            }
            string json = JsonConvert.SerializeObject(rehber);
            string path = @"C:\Users\HP\Desktop\Records.json";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, json);
            }
            else
            {
                File.AppendAllText(path, json);
            }
            this.Hide();
        }
    }
}
