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
    public partial class UpdateForm : Form
    {
        public PersonDto.Person ReturnPerson { get; set; }
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        public UpdateForm()
        {
            InitializeComponent();
        }
        public string fullName;
        public string companyName;
        public string gsm;
        public string email;
        public string phone;

        private void Update_Load(object sender, EventArgs e)
        {
            txtNameSurname.Text = fullName;
            txtGSM.Text = gsm;
            txtMail.Text = email;
            txtPhone.Text=phone;
            txtCompany.Text = companyName;
            
        }
        public void update()
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
                    CompanyName = String.Empty
                };
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
            update();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                update();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}
