using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;


namespace MyPhoneAccount
{
    public partial class MainForm : Form
    {
        List<Person> _persons = new List<Person>();
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
            if (listView1.SelectedItems.Count == 0)
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
                var item = listView1.SelectedItems[0].Index;
                string path = @"persons.json";
                string PersonText = File.ReadAllText(path);
                _persons = JsonConvert.DeserializeObject<List<Person>>(PersonText);
                lblFullName.Text = "Ad Soyad : " + _persons[item].Fullname;
                lblCompanyName.Text = "Firma Adı : " +  _persons[item].CompanyName;
                lblGSM.Text = "GSM No : " + _persons[item].GSM;
                lblPhone.Text = "Sabit Telefon : " +  _persons[item].Phone;
                lblMail.Text = "E-Mail Adresi : " +  _persons[item].Email;
                lblNoPerson.Text = null;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Ad Soyad");
            listView1.Columns.Add("GSM");

            lblNoPerson.Text = "Kayıt Seçilmeli";
            lblFullName.Text = null;
            lblCompanyName.Text = null;
            lblGSM.Text = null;
            lblPhone.Text = null;
            lblMail.Text = null;


            string path = @"persons.json";
            if (!File.Exists(path))
            {
                listView1.Items.Add("Kişi yada Firma Eklenmemiş");
            }
            string PersonText = File.ReadAllText(path);
            _persons = JsonConvert.DeserializeObject<List<Person>>(PersonText);

            
            
            
            if (_persons==null)
            {
                _persons = new List<Person>();
                listView1.Items.Add("Kişi yada Firma Eklenmemiş");
            }
            else
            {
                foreach (var item in _persons)
                {
                    listView1.Items.Add(item.Fullname);
                }
            }

        }

        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0].Index;
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
            listView1.Items.Clear();
            foreach (var item in _persons)
            {
                string[] row = { item.Fullname, item.GSM };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }
        }
    }
}
