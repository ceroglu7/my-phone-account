using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace MyPhoneAccount
{
    public partial class AddNewUserForm : Form
    {
        public PersonDto.Person ReturnPerson { get; set; }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                PersonDto.Person person = new PersonDto.Person
                {
                    Fullname = txtNameSurname.Text,
                    GSM = txtGSM.Text,
                    Email = txtMail.Text,
                    Phone = txtPhone.Text
                };

                if (radioBtnCompany.Checked)
                    person.CompanyName = txtCompany.Text;

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
                    MessageBox.Show(errorMessage,"Hatalar",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

        private void AddNewUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
