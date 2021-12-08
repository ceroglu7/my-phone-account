using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using FluentValidation;
using Microsoft.Azure.Amqp.Framing;
using System.Text.RegularExpressions;
using System.Linq;
using MyPhoneAccount;

namespace MyPhoneAccount
{
    public partial class MainForm : Form
    {
        List<PersonDto.Person> _persons = new List<PersonDto.Person>();
        AddNewUserForm _addNewUserForm = new AddNewUserForm();
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            _addNewUserForm.Clear();
            var result = _addNewUserForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                _persons.Add(_addNewUserForm.ReturnPerson);
            }
            string personJson = JsonConvert.SerializeObject(_persons);
            string path = "persons.json";
            File.WriteAllText(path, personJson);
            RefreshListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvResult.SelectedItems.Count == 0)
            {
                lblNoPerson.Text = "Kayıt Seçilmeli";
                lblFullName.Text = null;
                lblCompanyName.Text = null;
                lblGSM.Text = null;
                lblPhone.Text = null;
                lblMail.Text = null;
            }
            else
            {
                var item = lstvResult.SelectedItems[0].Index;
                string path = @"persons.json";
                string PersonText = File.ReadAllText(path);
                _persons = JsonConvert.DeserializeObject<List<PersonDto.Person>>(PersonText);
                lblFullName.Text = "Ad Soyad : " + _persons[item].Fullname;
                lblCompanyName.Text = "Firma Adı : " + _persons[item].CompanyName;
                lblGSM.Text = "GSM No : " + _persons[item].GSM;
                lblPhone.Text = "Sabit Telefon : " + _persons[item].Phone;
                lblMail.Text = "E-Mail Adresi : " + _persons[item].Email;
                lblNoPerson.Text = null;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lstvResult.Clear();
            lstvResult.View = View.Details;
            lstvResult.GridLines = true;
            lstvResult.FullRowSelect = true;
            lstvResult.Columns.Add("Ad Soyad");
            lstvResult.Columns.Add("GSM");

            lblNoPerson.Text = "Kayıt Seçilmeli";
            lblFullName.Text = null;
            lblCompanyName.Text = null;
            lblGSM.Text = null;
            lblPhone.Text = null;
            lblMail.Text = null;


            string path = @"persons.json";
            if (!File.Exists(path))
            {
                lstvResult.Items.Add("Kişi yada Firma Eklenmemiş");
            }
            string PersonText = File.ReadAllText(path);
            _persons = JsonConvert.DeserializeObject<List<PersonDto.Person>>(PersonText);




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
            if (lstvResult.SelectedItems.Count > 0)
            {
                var item = lstvResult.SelectedItems[0].Index;
                //rest of your logic
                _persons.RemoveAt(item);
                //_persons.Remove(_persons[item]);
                RefreshListView();
                string personJson = JsonConvert.SerializeObject(_persons);
                string path = "persons.json";
                File.WriteAllText(path, personJson);
                lblNoPerson.Text = "Kayıt Seçilmeli";
                lblFullName.Text = null;
                lblCompanyName.Text = null;
                lblGSM.Text = null;
                lblPhone.Text = null;
                lblMail.Text = null;
            }


        }
        private void RefreshListView()
        {
            lstvResult.Items.Clear();
            foreach (var item in _persons)
            {
                string[] row = { item.Fullname, item.GSM };
                var listViewItem = new ListViewItem(row);
                lstvResult.Items.Add(listViewItem);
            }
        }
        



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<PersonDto.Person> _persons = new List<PersonDto.Person>();
            string path = "persons.json";
            string PersonText = File.ReadAllText(path);
            _persons = JsonConvert.DeserializeObject<List<PersonDto.Person>>(PersonText);
            string searchingText = txtSearch.Text;
            if (cmbSearchCategory.SelectedItem == "Ad Soyad")
            {
                var searchResult = from item in _persons
                                   where item.Fullname.Contains(searchingText)
                                   select new { item.Fullname };
                lstvResult.Items.Clear();
                foreach (var result in searchResult)
                {
                    lstvResult.Items.Add(Convert.ToString(result));
                }
            }
            else if (cmbSearchCategory.SelectedItem == "Şirket Adı")
            {
                var searchResult = from item in _persons
                                   where item.CompanyName.Contains(searchingText)
                                   select new { item.CompanyName };
                lstvResult.Items.Clear();
                foreach (var result in searchResult)
                {
                    lstvResult.Items.Add(Convert.ToString(result));
                }
            }
            else if (cmbSearchCategory.SelectedItem == "GSM Numarası")
            {
                var searchResult = from item in _persons
                                   where item.GSM.Contains(searchingText)
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
                                   where item.Phone.Contains(searchingText)
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
                                   where item.Email.Contains(searchingText)
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
        
        }

    }
    public class PersonDtoValidator : AbstractValidator<PersonDto.Person>
    {
        public PersonDtoValidator()
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage("Mail bilgisi hatalı girildi").When(i => !string.IsNullOrEmpty(i.Email));
            RuleFor(c => c.Fullname).Length(3, 20).NotEmpty().NotNull().WithMessage("Ad Soyad bilgisi hatalı");
            RuleFor(c => c.GSM).Length(11).NotNull().NotEmpty().WithMessage("GSM Hatalı");
        }


    }