using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            File.WriteAllText("persons.json", personJson);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Kişi/Firma", 20);
            listView1.Columns.Add("GSM-Tel", 11);
            listView1.Columns.Add("Mail", 20);
        }
    }
}
