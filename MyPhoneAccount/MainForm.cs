using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using FluentValidation;
using System.Linq;
using System.Drawing;


namespace MyPhoneAccount
{
    public partial class MainForm : Form
    {
        List<PersonDto.Person> _persons = new List<PersonDto.Person>();
        AddNewUserForm _addNewUserForm = new AddNewUserForm();
        OpenFileDialog file = new OpenFileDialog();
        UpdateForm update = new UpdateForm();
        QRCodeForm qrcode = new QRCodeForm();
        MailForm mail = new MailForm();
        string GoalFolder = "ProfilePictures";
        string path = "persons.json";
        public MainForm()
        {
            InitializeComponent();
        }
        private void CleanScreen()
        {
            lblNoPerson1.Text = "Sol taraftan bir kişi seçiniz!";
            lblNoPerson1.ForeColor = Color.Green;
            lblFullName.Text = null;
            lblCompanyName.Text = null;
            lblGSM.Text = null;
            lblPhone.Text = null;
            lblMail.Text = null;
            btnCreateQR.Enabled = false;
            btnDeletePerson.Enabled = false;
            btnMail.Enabled = false;
            btnUpdate.Enabled = false;
            pcbProfilePic.Image = null;

        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            _addNewUserForm.Clear();
            var result = _addNewUserForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                _persons.Add(_addNewUserForm.ReturnPerson);
            }
            else
            {
                CleanScreen();
            }
            Serialize();
            RefreshListView();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var item = lstvResult.SelectedItems[0].Index;
            var selectedPerson = _persons[item];
            update.gsm = selectedPerson.GSM;
            update.fullName = selectedPerson.Fullname;
            update.companyName = selectedPerson.CompanyName;
            update.email = selectedPerson.Email;
            update.phone = selectedPerson.Phone;
            
            update.BeforePhotoWay = selectedPerson.Photo;

            var result = update.ShowDialog();
            if (result == DialogResult.OK)
            {
                _persons[item].Fullname = update.ReturnPerson.Fullname;
                _persons[item].GSM = update.ReturnPerson.GSM;
                _persons[item].CompanyName = update.ReturnPerson.CompanyName;
                _persons[item].Phone = update.ReturnPerson.Phone;
                _persons[item].Email = update.ReturnPerson.Email;
                _persons[item].Photo = update.ReturnPerson.Photo;
            }
            Serialize();
            RefreshListView();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvResult.SelectedItems.Count == 0)
            {
                CleanScreen();
            }
            else
            {
                var item = lstvResult.SelectedItems[0].Index;
                Deserialize();
                lblFullName.Text = "Ad Soyad : " + _persons[item].Fullname;
                lblCompanyName.Text = "Firma Adı : " + _persons[item].CompanyName;
                lblGSM.Text = "GSM No : " + _persons[item].GSM;
                lblPhone.Text = "Sabit Telefon : " + _persons[item].Phone;
                lblMail.Text = "E-Mail Adresi : " + _persons[item].Email;
                pcbProfilePic.ImageLocation = _persons[item].Photo;
                lblNoPerson1.Text = null;
                btnCreateQR.Enabled = true;
                btnDeletePerson.Enabled = true;
                btnMail.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            CleanScreen();
            lstvResult.Clear();
            lstvResult.GridLines = true;
            lstvResult.FullRowSelect = true;
            lstvResult.Columns.Add("Kişiler");
            string path = @"persons.json";
            if (!File.Exists(path))
            {
                lstvResult.Items.Add("Kişi yada Firma Eklenmemiş");
            }
            Deserialize();
            if (_persons == null)
            {
                _persons = new List<PersonDto.Person>();
                lstvResult.Items.Add("Kişi yada Firma Eklenmemiş");
            }
            else
            {
                foreach (var item in _persons)
                {
                    lstvResult.Items.Add(item.Fullname);
                }
            }
        }
        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
                var item = lstvResult.SelectedItems[0].Index;
                File.Delete(GoalFolder + "\\" + _persons[item].Id + _persons[item].PhotoName);
                _persons.RemoveAt(item);
                
                RefreshListView();
                Serialize();
                CleanScreen();
        }
        private void RefreshListView()
        {
            lstvResult.Items.Clear();
            foreach (var item in _persons)
            {
                string[] row = { item.Fullname};
                var listViewItem = new ListViewItem(row);
                lstvResult.Items.Add(listViewItem);
            }
        }
        public void Deserialize()
        {
            string PersonText = File.ReadAllText(path);
            _persons = JsonConvert.DeserializeObject<List<PersonDto.Person>>(PersonText);
        }
        public void Serialize()
        {
            string personJson = JsonConvert.SerializeObject(_persons);
            File.WriteAllText(path, personJson);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Deserialize();
            string searchingText = txtSearch.Text.ToUpper();
            if (cmbSearchCategory.SelectedItem == "Ad Soyad")
            {
                var searchResult = from item in _persons
                                   where item.Fullname.ToUpper().Contains(searchingText)
                                   select item;
                lstvResult.Items.Clear();
                foreach (var result in searchResult.ToList())
                {
                    lstvResult.Items.Add(Convert.ToString(result.Fullname));
                }
            }
            else if (cmbSearchCategory.SelectedItem == "Şirket Adı")
            {
                var searchResult = from item in _persons
                                   where item.CompanyName.Contains(searchingText)
                                   select item;
                lstvResult.Items.Clear();
                foreach (var result in searchResult.ToList())
                {
                    lstvResult.Items.Add(Convert.ToString(result.CompanyName));
                }
            }
            else if (cmbSearchCategory.SelectedItem == "GSM Numarası")
            {
                var searchResult = from item in _persons
                                   where item.GSM.ToUpper().Contains(searchingText)
                                   select new { item.GSM };
                lstvResult.Items.Clear();
                foreach (var result in searchResult)
                {
                    lstvResult.Items.Add(Convert.ToString(result));
                }
            }
            else if (cmbSearchCategory.SelectedItem == "Sabit Tel.")
            {
                var searchResult = from item in _persons
                                   where item.Phone.ToUpper().Contains(searchingText)
                                   select new { item.Phone };
                lstvResult.Items.Clear();
                foreach (var result in searchResult)
                {
                    lstvResult.Items.Add(Convert.ToString(result));
                }
            }
            else if (cmbSearchCategory.SelectedItem == "E-Mail")
            {
                var searchResult = from item in _persons
                                   where item.Email.ToUpper().Contains(searchingText)
                                   select new { item.Email };
                lstvResult.Items.Clear();
                foreach (var result in searchResult)
                {
                    lstvResult.Items.Add(Convert.ToString(result));
                }
            }
            else
                RefreshListView();
        }
        public void btnCreateQR_Click(object sender, EventArgs e)
        {
                var item = lstvResult.SelectedItems[0].Index;
                var selectedPerson = _persons[item];
                qrcode.SetData(selectedPerson);
                qrcode.ShowDialog();
        }
        public void btnMail_Click(object sender, EventArgs e)
        {
                var item = lstvResult.SelectedItems[0].Index;
                var selectedPerson = _persons[item];
                mail.gsm = selectedPerson.GSM;
                mail.fullName = selectedPerson.Fullname;
                mail.companyName = selectedPerson.CompanyName;
                mail.email = selectedPerson.Email;
                mail.ShowDialog();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();

        }
    }
}