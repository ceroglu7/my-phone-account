using FluentValidation.Results;
using MyPhoneAccount.Validators;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MyPhoneAccount
{
    public partial class AddNewUserForm : Form
    {
        public PersonDto.Person ReturnPerson { get; set; }
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;

        public AddNewUserForm()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            ReturnPerson = null;

            txtNameSurname.Text = string.Empty;
            txtGSM.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtCompany.Text = string.Empty;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            txtNameSurname.Enabled = true;
            txtMail.Enabled = true;
            txtGSM.Enabled = true;
            txtCompany.Enabled = false;
            txtPhone.Enabled = true;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            txtCompany.Enabled = true;
            txtPhone.Enabled = true;
            txtMail.Enabled = true;
            txtNameSurname.Enabled = true;
            txtGSM.Enabled = true;

        }
        public void Add()
        {
            try
            {
                PersonDto.Person person = new PersonDto.Person
                {
                    Fullname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNameSurname.Text),
                    GSM = txtGSM.Text,
                    Email = txtMail.Text,
                    Phone = txtPhone.Text,
                    IsCompany = false,
                    CompanyName=String.Empty
                };

                if (radioBtnCompany.Checked)
                {
                    person.CompanyName = txtCompany.Text;
                    person.IsCompany = true;
                }
                //Validation

                PersonDtoValidator validation = new PersonDtoValidator();
                ValidationResult result = validation.Validate(person);
                if (!result.IsValid)
                {
                    string errorMessage = "";
                    foreach (var error in result.Errors)
                    {
                        errorMessage += $"{error}  \n";
                    }
                    MessageBox.Show(errorMessage, "Hatalar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                //Validation

                ReturnPerson = person;

                this.DialogResult = DialogResult.OK;

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Add();

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Add();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void AddNewUserForm_Load(object sender, EventArgs e)
        {

        }

        private void txtGSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGSM_TextChanged(object sender, EventArgs e)
        {
            if (txtGSM.TextLength==11)
            {
                txtGSM.ForeColor = Color.Black;
            }
            else
            {
                txtGSM.ForeColor = Color.Red;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.TextLength == 11)
            {
                txtPhone.ForeColor = Color.Black;
            }
            else
            {
                txtPhone.ForeColor = Color.Red;
            }
        }
    }
}
