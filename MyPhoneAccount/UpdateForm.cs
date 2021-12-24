using FluentValidation.Results;
using MyPhoneAccount.Validators;
using System;
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
        OpenFileDialog file = new OpenFileDialog();
        public UpdateForm()
        {
            InitializeComponent();
        }
        public string fullName;
        public string companyName;
        public string gsm;
        public string email;
        public string phone;
        public string BeforePhotoWay;
        public string GoalFolder = @"ProfilePictures";
        public string UpdatePhotoWay;
        public string UpdatePhotoName;
        public bool UpdatePhoto, DeleteSelect;

        private void Update_Load(object sender, EventArgs e)
        {
            txtNameSurname.Text = fullName;
            txtGSM.Text = gsm;
            txtMail.Text = email;
            txtPhone.Text=phone;
            txtCompany.Text = companyName;
            pcbProfilePic.ImageLocation = BeforePhotoWay;
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
                    CompanyName = String.Empty,
                };
                if (UpdatePhoto)
                {
                    File.Copy(UpdatePhotoWay, GoalFolder + "\\" + person.Id + UpdatePhotoName);
                    person.AddedPhoto = true;
                    person.Photo = GoalFolder + "\\" + person.Id + UpdatePhotoName;
                    File.Delete(BeforePhotoWay);
                }
                else
                {
                    person.AddedPhoto = false;
                    person.Photo = BeforePhotoWay;
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            file.Filter = "PNG Dosyası |*.png| JPEG Dosyası |*.jpg";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.CheckFileExists = true;
            file.Title = "Dosya Seçiniz..";
            if (file.ShowDialog() == DialogResult.OK)
            {

                UpdatePhotoWay = file.FileName.ToString();
                UpdatePhotoName = file.SafeFileName.ToString();
                btnSelectPhoto.Text = UpdatePhotoName;
                pcbProfilePic.ImageLocation = UpdatePhotoWay;
                UpdatePhoto = true;
                DeleteSelect = false;
            }
            else
            {
                UpdatePhoto = false;
                UpdatePhotoWay = BeforePhotoWay;
                DeleteSelect = true;
            }
        }
        private void Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Close();
        }
    }
}
