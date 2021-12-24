using FluentValidation.Results;
using MyPhoneAccount.Validators;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MyPhoneAccount
{

    public partial class AddNewUserForm : Form
    {
        string PhotoWay, PhotoName;
        string GoalFolder = @"ProfilePictures";
        bool AddPhoto;
        public PersonDto.Person ReturnPerson { get; set; }
        OpenFileDialog file = new OpenFileDialog();
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
            txtGSM.Enabled = true;
            txtMail.Enabled = true;
            txtNameSurname.Enabled = true;
            txtPhone.Enabled = true;

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
                    CompanyName = String.Empty,
                };

                if (radioBtnCompany.Checked)
                {
                    person.CompanyName = txtCompany.Text;
                    person.IsCompany = true;
                }
                else
                {
                    person.CompanyName = string.Empty;
                    person.IsCompany = false;
                }
                if (AddPhoto)
                {
                    File.Copy(PhotoWay, GoalFolder + "\\" + person.Id + PhotoName);
                    person.AddedPhoto = true;
                    person.Photo = GoalFolder+ "\\" +person.Id+ PhotoName;
                   
                }
                else
                {
                    person.AddedPhoto = false;
                    person.Photo = GoalFolder + "\\"+"Default.png";
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

        public void btnPhoto_Click(object sender, EventArgs e)
        {
            PhotoWay = @"C:\Users\HP\Desktop\Default.png";
            file.Filter = "PNG Dosyası |*.png| JPEG Dosyası |*.jpg";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.CheckFileExists = true;
            file.Title = "Dosya Seçiniz..";
            if (file.ShowDialog() == DialogResult.OK)
            {
                
                PhotoWay = file.FileName.ToString() ;
                PhotoName = file.SafeFileName.ToString();
                btnPhoto.Text = PhotoName;
                AddPhoto = true;
            }
            else
            {
                AddPhoto = false;
            }
        }

        private void AddNewUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PhotoWay = string.Empty;
            PhotoName = string.Empty;
            btnPhoto.Text = "Fotoğraf Ekle";
        }

        
    }
}
